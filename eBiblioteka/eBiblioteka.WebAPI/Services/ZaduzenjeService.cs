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
    public class ZaduzenjeService : BaseCRUDService<Model.Zaduzenje, ZaduzenjeSearchRequest, Database.Zaduzenje, ZaduzenjeUpsertRequest, ZaduzenjeUpsertRequest>
    {
        private ImageHelper imageHelper = new ImageHelper();

        public ZaduzenjeService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Zaduzenje>> Get(ZaduzenjeSearchRequest request)
        {

            var query = _context.Zaduzenje.Include("Clan.KorisnickiNalog").Include("Knjiga.Autor").AsQueryable();

            if (request?.ZaduzenjeId.HasValue == true)
            {
                query = query.Where(s => s.ZaduzenjeId == request.ZaduzenjeId);
            }

            if (request?.ClanId.HasValue == true)
            {
                query = query.Where(s => s.ClanId == request.ClanId);
            }

            if (!string.IsNullOrWhiteSpace(request?.ClanIme))
            {
                request.ClanIme = StringHelper.FirstLetterToUpperCase(request.ClanIme);
                query = query.Where(s => s.Clan.KorisnickiNalog.Ime.StartsWith(request.ClanIme));
            }

            if (!string.IsNullOrWhiteSpace(request?.Knjiga))
            {
                request.Knjiga = StringHelper.FirstLetterToUpperCase(request.Knjiga);
                query = query.Where(s => s.Knjiga.Naziv.StartsWith(request.Knjiga));
            }

            if (request.Status == true)
            {
                query = query.Where(s => s.Status == true);
            }

            if (request?.DatumOd != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumZaduzenja.Date, (DateTime)request.DatumOd.Value.Date) >= 0);
            }

            if (request?.DatumDo != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumZaduzenja.Date, (DateTime)request.DatumDo.Value.Date) <= 0);
            }

            var list = await query.OrderByDescending(s=> s.DatumZaduzenja).ToListAsync();

            var result = _mapper.Map<List<Model.Zaduzenje>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{item.Knjiga.SlikaPutanja}");
                item.Knjiga.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Zaduzenje> GetById(int id)
        {
            var entity = await _context.Zaduzenje.Include("Clan.KorisnickiNalog").Include("Knjiga").Where(s => s.ZaduzenjeId == id).SingleOrDefaultAsync();


            if (entity == null)
            {
                throw new UserException("Zaduženje nije pronađeno!");
            }

            var result = _mapper.Map<Model.Zaduzenje>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{result.Knjiga.SlikaPutanja}");
            result.Knjiga.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Zaduzenje> Insert(ZaduzenjeUpsertRequest request)
        {
            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException("Član već posjeduje aktivno zaduženje za tu knjigu.");
            }
            if(request.ProvjeriBrojZaduzenjaRezervacija == true && await ProvjeriBrojRezervacijaIZaduzenja(request))
            {
                throw new UserException("Član već posjeduje maximalne 3 aktivne rezervacije ili zaduženja.");
            }
            if(await ProvjeriPreostaloStanje(request) == false)
            {
                throw new UserException($"Svi primjerci knjige su izdati ili rezervisani. Broj primjeraka knjige na stanju je 0!");
            }
            var zaduzenje = _mapper.Map<Database.Zaduzenje>(request);

            await _context.Zaduzenje.AddAsync(zaduzenje);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Zaduzenje>(zaduzenje);
        }

        public async override Task<Model.Zaduzenje> Update(int id, ZaduzenjeUpsertRequest request)
        {
            var entity = await _context.Zaduzenje.Include("Clan.KorisnickiNalog").Include("Knjiga").Where(s => s.ZaduzenjeId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Zaduženje nije pronađeno!");
            }

            if (!ProvjeriPromjene(entity, request))
            {
                throw new UserException("Niste izvršili nikakve promjene.");
            }

            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Zaduzenje>(entity);
        }



        //Update function
        private async Task UpdateEntity(Database.Zaduzenje entity, ZaduzenjeUpsertRequest request)
        {

            if (request.DatumVracanja != null && request.DatumVracanja != entity.DatumVracanja) entity.DatumVracanja = request.DatumVracanja;
            if (request.Status != entity.Status) entity.Status = request.Status;
            await _context.SaveChangesAsync();
        }



        //Provjere
        public async Task<bool> ProvjeriDaLiPostoji(ZaduzenjeUpsertRequest request)
        {
            return await _context.Zaduzenje.AnyAsync(s => s.ClanId == request.ClanId && s.KnjigaId == request.KnjigaId && s.Status == true);
        }
        public async Task<bool> ProvjeriPreostaloStanje(ZaduzenjeUpsertRequest request)
        {
            var knjiga = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Include("Zaduzenja").Include("Rezervacije").Where(s => s.KnjigaId == request.KnjigaId).SingleOrDefaultAsync();

            var knjigamapper = _mapper.Map<Model.Knjiga>(knjiga);

            if (knjigamapper.PreostaloNaStanju <= 0)
                return false;
            else
                return true;

        }
        public async Task<bool> ProvjeriBrojRezervacijaIZaduzenja(ZaduzenjeUpsertRequest request)
        {
            var brojZaduzenja = await _context.Zaduzenje.Where(s => s.ClanId == request.ClanId && s.Status == true).CountAsync();
            var brojRezervacija = await _context.Rezervacija.Where(s => s.ClanId == request.ClanId && s.Status == true).CountAsync();

            if ((brojRezervacija + brojZaduzenja) < 3)
                return false;
            else
                return true;
        }
        private bool ProvjeriPromjene(Database.Zaduzenje entity, ZaduzenjeUpsertRequest request)
        {

            if (request.DatumZaduzenja != entity.DatumZaduzenja) return true;
            if (request.DatumVracanja != entity.DatumVracanja) return true;
            if (request.KnjigaId != entity.KnjigaId) return true;
            if (request.ClanId != entity.ClanId) return true;
            if (request.Status != entity.Status) return true;


            return false;
        }

    }
}
