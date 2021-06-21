using AutoMapper;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Exceptions;
using eBiblioteka.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Services
{
    public class RezervacijaService : BaseCRUDService<Model.Rezervacija, RezervacijaSearchRequest, Database.Rezervacija, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        private ImageHelper imageHelper = new ImageHelper();

        public RezervacijaService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Rezervacija>> Get(RezervacijaSearchRequest request)
        {

            var query = _context.Rezervacija.Include("Clan.KorisnickiNalog").Include("Knjiga.Autor").AsQueryable();

            if (request?.RezervacijaId.HasValue == true)
            {
                query = query.Where(s => s.RezervacijaId == request.RezervacijaId);
            }

            if (request?.ClanId.HasValue == true)
            {
                query = query.Where(s => s.ClanId == request.ClanId);
            }

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                request.Naziv = StringHelper.FirstLetterToUpperCase(request.Naziv);
                query = query.Where(s => s.Knjiga.Naziv.StartsWith(request.Naziv));
            }

            if (request?.DatumOd != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumRezervacije.Date, (DateTime)request.DatumOd.Value.Date) >= 0);
            }

            if (request?.DatumDo != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumRezervacije.Date, (DateTime)request.DatumDo.Value.Date) <= 0);
            }

            if (request.Status == true)
            {
                query = query.Where(s => s.Status == true);
            }

            var list = await query.OrderByDescending(s=> s.DatumRezervacije).ToListAsync();

            var result = _mapper.Map<List<Model.Rezervacija>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{item.Knjiga.SlikaPutanja}");
                item.Knjiga.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Rezervacija> GetById(int id)
        {
            var entity = await _context.Rezervacija.Include("Clan.KorisnickiNalog").Include("Knjiga.Autor").Where(s=> s.RezervacijaId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Rezervacija nije pronađena!");
            }

            var result = _mapper.Map<Model.Rezervacija>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{result.Knjiga.SlikaPutanja}");
            result.Knjiga.Slika = await imageHelper.FindImage(directory);

            return result;

        }

        public async override Task<Model.Rezervacija> Insert(RezervacijaUpsertRequest request)
        {

            if (await ProvjeriDaLiPostoji(request))
            {
                if(request.ClanMessage == null || request.ClanMessage == false)
                    throw new UserException("Član već posjeduje aktivnu rezervaciju za odabranu knjigu.");

                else
                    throw new UserException("Već posjedujete aktivnu rezervaciju za odabranu knjigu.");


            }
            if (await ProvjeriBrojRezervacijaIZaduzenja (request))
            {
                if (request.ClanMessage == null || request.ClanMessage == false)
                    throw new UserException("Član već posjeduje maximalne 3 aktivne rezervacije ili zaduženja.");

                else
                    throw new UserException("Već posjedujete maximalne 3 aktivne rezervacije ili zaduženja. Molimo vratite zadužene knjige, kako bi mogli izvršiti rezervaciju nove knjige!");

            }

            if (await ProvjeriPreostaloStanje(request) == false)
            {
                throw new UserException($"Svi primjerci knjige su izdati ili rezervisani. Broj primjeraka knjige na stanju je 0!");
            }

            var rezervacija = _mapper.Map<Database.Rezervacija>(request);

            await _context.Rezervacija.AddAsync(rezervacija);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Rezervacija>(rezervacija);
        }

        public async override Task<Model.Rezervacija> Update(int id, RezervacijaUpsertRequest request)
        {
            var entity = await _context.Rezervacija.Include("Clan.KorisnickiNalog").Include("Knjiga").Where(s => s.RezervacijaId == id).SingleOrDefaultAsync();


            if (entity == null)
            {
                throw new UserException("Rezervacija nije pronađene!");
            }

            if (!ProvjeriPromjene(entity, request))
            {
                throw new UserException("Niste izvršili nikakve promjene.");
            }

            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Rezervacija>(entity);
        }



        //Update function
        private async Task  UpdateEntity(Database.Rezervacija entity, RezervacijaUpsertRequest request)
        {
            if (request.Status != entity.Status) entity.Status = request.Status;
            await _context.SaveChangesAsync();
        }



        //Provjere
        public async Task<bool> ProvjeriDaLiPostoji(RezervacijaUpsertRequest request)
        {
            return await _context.Rezervacija.AnyAsync(s => s.ClanId == request.ClanId && s.KnjigaId == request.KnjigaId && s.Status == true);
        }

        public async Task<bool> ProvjeriBrojRezervacijaIZaduzenja(RezervacijaUpsertRequest request)
        {
            var brojZaduzenja = await _context.Zaduzenje.Where(s => s.ClanId == request.ClanId && s.Status == true).CountAsync();
            var brojRezervacija = await _context.Rezervacija.Where(s => s.ClanId == request.ClanId && s.Status == true).CountAsync();

            if ((brojRezervacija + brojZaduzenja) < 3)
                return false;
            else
                return true;
        }

        public async Task<bool> ProvjeriPreostaloStanje(RezervacijaUpsertRequest request)
        {
            var knjiga = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Include("Zaduzenja").Include("Rezervacije").Where(s => s.KnjigaId == request.KnjigaId).SingleOrDefaultAsync();

            var knjigamapper = _mapper.Map<Model.Knjiga>(knjiga);

            if (knjigamapper.PreostaloNaStanju <= 0)
                return false;
            else
                return true;

        }

        private bool ProvjeriPromjene(Database.Rezervacija entity, RezervacijaUpsertRequest request)
        {

            if (request.Status != entity.Status) return true;


            return false;
        }


    }
}
