using AutoMapper;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Exceptions;
using eBiblioteka.WebAPI.Helpers;
using eBiblioteka.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Services
{
    public class KnjigaService : BaseCRUDService<Model.Knjiga, KnjigaSearchRequest, Database.Knjiga, KnjigaUpsertRequest, KnjigaUpsertRequest>, IKnjigaService
    {
        private ImageHelper imageHelper = new ImageHelper();
        public KnjigaService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Knjiga>> Get(KnjigaSearchRequest request)
        {

            var query = _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Include("Zaduzenja").Include("Rezervacije").Where(s=> s.Status == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                request.Naziv = StringHelper.FirstLetterToUpperCase(request.Naziv);
                query = query.Where(s => s.Naziv.StartsWith(request.Naziv));
            }

            if (!string.IsNullOrWhiteSpace(request?.ImePrezime))
            {
                request.ImePrezime = StringHelper.FirstLetterToUpperCase(request.ImePrezime);
                query = query.Where(s => s.Autor.ImePrezime.StartsWith(request.ImePrezime));
            }

            var list = await query.ToListAsync();

            var result = _mapper.Map<List<Model.Knjiga>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }
       
        public async override Task<Model.Knjiga> GetById(int id)
        {
            var entity = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Where(s => s.KnjigaId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Knjiga nije pronađena!");
            }

            if(entity.Status == false)
            {
                throw new UserException("Knjiga je već obrisana");
            }

            var result = _mapper.Map<Model.Knjiga>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);


            return result;
        }

        public async override Task<Model.Knjiga> Insert(KnjigaUpsertRequest request)
        {
            if(await ProvjeriDaLiPostoji(request))
            {
                var naslov = await _context.Autor.FindAsync(request.AutorId);
                throw new UserException($"Knjiga ¨{request.Naziv}¨ od autora {naslov.ImePrezime} je već dodana.");
            }

            var entity = _mapper.Map<Database.Knjiga>(request);
            await _context.Knjiga.AddAsync(entity);
            await _context.SaveChangesAsync();

            //Morao sam uraditi 2 snimanja, jer se slika veze za id od knjige, pa da bih dobio id morao sam prvo objekat spremiti u bazu
            entity.SlikaPutanja = await imageHelper.InsertImage("Knjiga", entity.KnjigaId, request.SlikaPutanja, request.Slika);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Knjiga>(entity);
        }

        public async override Task<Model.Knjiga> Update(int id, KnjigaUpsertRequest request)
        {
            var entity = await _context.Knjiga.FindAsync(id);

            if (entity == null)
            {
                throw new UserException("Knjiga nije pronađena!");
            }

            if (ProvjeriPromjene(entity, request) == false)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");

            }
            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Knjiga>(entity);
        }

        // Za delete nisam brisao entitet nego samo promjenio status kako korisniku ne bih prikazivao iste te knjige, jer brisanje povlaci za sobom i probleme brisanja rezervacija i zaduzenja,
        // što bi se svakako odrazilo na samu tačnost izvještaja i informacija u aplikaciji.
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Where(s => s.KnjigaId == id).SingleOrDefaultAsync();


            if (entity == null)
            {
                throw new UserException("Knjiga nije pronađena!");
            }

            if (entity.Status == false)
            {
                throw new UserException("Knjiga je već obrisana");
            }
            try
            {

                entity.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        //Update function
        private async Task UpdateEntity(Database.Knjiga entity, KnjigaUpsertRequest request)
        {

            if (request.Naziv != null && request.Naziv != entity.Naziv) entity.Naziv = request.Naziv;
            if (request.Opis != null && request.Opis != entity.Opis) entity.Opis = request.Opis;
            if (request.GodinaIzdavanja != null && request.GodinaIzdavanja != entity.GodinaIzdavanja) entity.GodinaIzdavanja = request.GodinaIzdavanja;
            if (request.InventarniBroj != null && request.InventarniBroj != entity.InventarniBroj) entity.InventarniBroj = request.InventarniBroj;
            if (request.BrojStranica != entity.BrojStranica) entity.BrojStranica = request.BrojStranica;
            if (request.BrojKnjigaNaStanju != entity.BrojKnjigaNaStanju) entity.BrojKnjigaNaStanju = request.BrojKnjigaNaStanju;
            if (request.AutorId != entity.AutorId) entity.AutorId = request.AutorId;
            if (request.IzdavacId != entity.IzdavacId) entity.IzdavacId = request.IzdavacId;
            if (request.KategorijaId != entity.KategorijaId) entity.KategorijaId = request.KategorijaId;
            if (request.SlikaPutanja != null && request.Slika != null  && request.SlikaPutanja != entity.SlikaPutanja) entity.SlikaPutanja = await imageHelper.ReplaceImage("Knjiga", entity.KnjigaId, entity.SlikaPutanja, request.SlikaPutanja, request.Slika);

            await _context.SaveChangesAsync();
        }


        //Provjere

        public async Task<bool> ProvjeriDaLiPostoji(KnjigaUpsertRequest request)
        {
            return await _context.Knjiga.AnyAsync(s=> s.Naziv == request.Naziv && s.AutorId == request.AutorId && s.Status == true);
        }
        private bool ProvjeriPromjene(Database.Knjiga entity, KnjigaUpsertRequest request)
        {
            if (request.Naziv != entity.Naziv) return true;
            if (request.Opis != entity.Opis) return true;
            if (request.GodinaIzdavanja != entity.GodinaIzdavanja) return true;
            if (request.InventarniBroj != entity.InventarniBroj) return true;
            if (request.BrojStranica != entity.BrojStranica) return true;
            if (request.BrojKnjigaNaStanju != entity.BrojKnjigaNaStanju) return true;
            if (request.AutorId != entity.AutorId) return true;
            if (request.IzdavacId != entity.IzdavacId) return true;
            if (request.KategorijaId != entity.KategorijaId) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.SlikaPutanja) return true;

            return false;
        }

    }
}
