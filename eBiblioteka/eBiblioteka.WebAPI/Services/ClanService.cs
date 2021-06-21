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
    public class ClanService : BaseCRUDService<Model.Clan, ClanSearchRequest, Database.Clan, ClanInsertRequest, ClanUpdateRequest>, IClanService
    {
        private ImageHelper imageHelper = new ImageHelper();

        public ClanService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Clan>> Get(ClanSearchRequest request)
        {

            var query =  _context.Clan.Include("Grad").Include("KorisnickiNalog").AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                request.Ime = StringHelper.FirstLetterToUpperCase(request.Ime);
                query = query.Where(s => s.KorisnickiNalog.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                request.Prezime = StringHelper.FirstLetterToUpperCase(request.Prezime);
                query = query.Where(s => s.KorisnickiNalog.Prezime.StartsWith(request.Prezime));
            }

            if (request.Status == true)
            {
                query = query.Where(s => s.Status == true);
            }

            var list = await query.ToListAsync();

            var result = _mapper.Map<List<Model.Clan>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Clan> GetById(int id)
        {
            var entity = await _context.Clan.Include("Grad").Include("KorisnickiNalog").Where(s => s.ClanId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Član nije pronađen!");
            }

            var result = _mapper.Map<Model.Clan>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Clan> Insert(ClanInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotrvda)
                throw new UserException("Lozinke se ne podudaraju!");

            if(await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Član {request.Ime} {request.Prezime}, datum rođenja ( {request.DatumRodjenja.ToString("dd/MM/yyyy")} ) je već dodan!");
            }

            if (await KorisnickoImeZauzeto(request.KorisnickoIme))
            {
                throw new UserException("Korisničko ime je zauzeto!");
            }

            if (request.GradId == 0)
            {
                throw new UserException("Molimo unesite ispravan GradId!");
            }

            var salt = HashGenerator.GenerateSalt();
            var hash = HashGenerator.GenerateHash(salt, request.Lozinka);

            var nalog = _mapper.Map<Database.KorisnickiNalog>(request);

            nalog.LozinkaSalt = salt;
            nalog.LozinkaHash = hash;
            nalog.DatumIzmjene = DateTime.Now;

            await _context.KorisnickiNalog.AddAsync(nalog);
            await _context.SaveChangesAsync();

            nalog.SlikaPutanja = await imageHelper.InsertImage("KorisnickiNalog", nalog.KorisnickiNalogId, request.SlikaPutanja, request.Slika);


            var clan = _mapper.Map<Database.Clan>(request);
            clan.KorisnickiNalogId = nalog.KorisnickiNalogId;
            clan.DatumUclanjenja = DateTime.Now;

            await _context.Clan.AddAsync(clan);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Clan>(clan);
        }

        public async override Task<Model.Clan> Update(int id, ClanUpdateRequest request)
        {
            var entity = await _context.Clan.Include("Grad").Include("KorisnickiNalog").Where(s => s.ClanId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Član nije pronađen!");
            }

            if (entity.KorisnickiNalog.KorisnickoIme == "mobile" && request.Status == false)
            {
                throw new UserException("Korisnički nalog mobile ne može biti neaktivan, jer se koristi za potrebe testiranja. Molimo postavite aktivnost na ¨Da¨, kako bi izvršili eventualne promjene u atributima");
            }

            if (request.Lozinka != null && request.LozinkaPotrvda != null)
                if (request.Lozinka != request.LozinkaPotrvda)
                    throw new UserException("Lozinke se ne podudaraju!");

            if (request.KorisnickoIme != entity.KorisnickiNalog.KorisnickoIme && await KorisnickoImeZauzeto(request.KorisnickoIme) == true)
            {
                throw new UserException("Korisničko ime je zauzeto");
            }

            if(ProvjeriPromjene(entity,request)==false)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");

            }
            await UpdateEntity (entity, request);
            var result = _mapper.Map<Model.Clan>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        // Za delete nisam brisao entitet nego samo promjenio status, jer brisanje povlaci za sobom i probleme brisanja uplata i zaduzenja,
        // što bi se svakako odrazilo na samu tačnost izvještaja i informacija u aplikaciji.
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Clan.Include("Grad").Include("KorisnickiNalog").Where(s => s.ClanId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Član nije pronađen!");
            }

            if(entity.KorisnickiNalog.KorisnickoIme == "mobile")
            {
                throw new UserException("Korisnicki nalog mobile nije moguće deaktivirati jer se koristi za potrebe testiranja.");
            }
            try
            {

                entity.KorisnickiNalog.Status = false;
                entity.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Model.Clan> Authenticate(AuthenticationRequest request)
        {
            var user = await _context.Clan.Include("KorisnickiNalog").Include("Grad").FirstOrDefaultAsync(s => s.KorisnickiNalog.KorisnickoIme == request.KorisnickoIme);

            if (user == null)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");
            }

            if(user.KorisnickiNalog.Status == false)
            {
                throw new UserException("Korisnički nalog je deaktiviran. Molimo kontaktirajte administratora.");

            }

            var newHash = HashGenerator.GenerateHash(user.KorisnickiNalog.LozinkaSalt, request.Password);

            if (newHash != user.KorisnickiNalog.LozinkaHash)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");

            }

            var result = _mapper.Map<Model.Clan>(user);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async Task<Model.Clan> UpdatePhoto(int ClanId, ClanUpdatePhotoRequest request)
        {
            var entity = await _context.Clan.Include("Grad").Include("KorisnickiNalog").Where(s => s.ClanId == ClanId).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Član nije pronađen!");
            }

            await UpdatePhotoClan(entity, request);

            var result = _mapper.Map<Model.Clan>(entity);
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{result.SlikaPutanja}");

            result.Slika = await imageHelper.FindImage(directory);
            return result;
        }

        public async Task<bool> UpdatePassword(int id, ClanUpdatePasswordRequest request)
        {
            var entity = await _context.Clan.Include("Grad").Include("KorisnickiNalog").Where(s => s.ClanId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Član nije pronađen!");
            }

            var hash = HashGenerator.GenerateHash(entity.KorisnickiNalog.LozinkaSalt, request.StaraLozinka);

            if(hash != entity.KorisnickiNalog.LozinkaHash)
            {
                throw new UserException("Niste unijeli ispravnu trenutnu lozinku!");

            }

            if(request.StaraLozinka == request.NovaLozinka)
            {
                throw new UserException("Nova lozinka ne može biti ista kao trenutna lozinka. Molimo unesite novu lozinku različitu od trenutne!");

            }

            if (request.NovaLozinka != request.NovaLozinkaPotvrda)
            {
                throw new UserException("Lozinke se ne podudaraju!");
            }

            var saltnew = HashGenerator.GenerateSalt();
            var hashnew = HashGenerator.GenerateHash(saltnew, request.NovaLozinka);

            entity.KorisnickiNalog.LozinkaSalt = saltnew;
            entity.KorisnickiNalog.LozinkaHash = hashnew;
            entity.KorisnickiNalog.DatumIzmjene = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<Model.ClanCounter> GetCounter(int id)
        {
            var user = await _context.Clan.Include("KorisnickiNalog").Include("Grad").Include("Rezervacije").Include("Zaduzenja").Where(s => s.ClanId == id).SingleOrDefaultAsync();

            if (user == null)
            {
                throw new UserException("Član nije pronađen!");

            }

            var brojZaduzenjaUkupno = user.Zaduzenja.Count;
            var brojAktivnihZaduzenja = user.Zaduzenja.Where(s => s.Status == true).Count();
            var brojAktivnihRezervacija = user.Rezervacije.Where(s => s.Status == true).Count();

            return new Model.ClanCounter() { BrojAktivnihRezervacija = brojAktivnihRezervacija, BrojAktivnihZaduzenja = brojAktivnihZaduzenja, BrojUkupnoZaduzenja = brojZaduzenjaUkupno };
        }


        //Update function
        private async Task UpdateEntity(Database.Clan entity, ClanUpdateRequest request)
        {

            if (request.Ime != null && request.Ime != entity.KorisnickiNalog.Ime) entity.KorisnickiNalog.Ime = request.Ime;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiNalog.Prezime) entity.KorisnickiNalog.Prezime = request.Prezime;
            if (request.DatumRodjenja != null && request.DatumRodjenja != entity.KorisnickiNalog.DatumRodjenja) entity.KorisnickiNalog.DatumRodjenja = request.DatumRodjenja;
            if (request.DatumUclanjenja != null && request.DatumUclanjenja != entity.DatumUclanjenja) entity.DatumUclanjenja = request.DatumUclanjenja;
            if (request.Ime != null && request.Ime != entity.KorisnickiNalog.Ime) entity.KorisnickiNalog.Ime = request.Ime;
            if (request.Adresa != null && request.Adresa != entity.KorisnickiNalog.Adresa) entity.KorisnickiNalog.Adresa = request.Adresa;
            if (request.Email != null && request.Email != entity.KorisnickiNalog.Email) entity.KorisnickiNalog.Email = request.Email;
            if (request.Telefon != null && request.Telefon != entity.KorisnickiNalog.Telefon) entity.KorisnickiNalog.Telefon = request.Telefon;
            if (request.KorisnickoIme != null && request.KorisnickoIme != entity.KorisnickiNalog.KorisnickoIme) entity.KorisnickiNalog.KorisnickoIme = request.KorisnickoIme;
            if (request.GradId != 0 && request.GradId != entity.GradId) entity.GradId = request.GradId;
            if (request.Status != null && request.Status != entity.Status) entity.Status = request.Status;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiNalog.SlikaPutanja) entity.KorisnickiNalog.SlikaPutanja = await imageHelper.ReplaceImage("KorisnickiNalog", entity.KorisnickiNalogId, entity.KorisnickiNalog.SlikaPutanja, request.SlikaPutanja, request.Slika);
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0 && request.LozinkaPotrvda.Length > 0 && request.Lozinka == request.LozinkaPotrvda)
            {
                var salt = HashGenerator.GenerateSalt();
                var hash = HashGenerator.GenerateHash(salt, request.Lozinka);

                entity.KorisnickiNalog.LozinkaSalt = salt;
                entity.KorisnickiNalog.LozinkaHash = hash;
            }

            entity.KorisnickiNalog.DatumIzmjene = DateTime.Now;

           await _context.SaveChangesAsync();
        }

        private async Task UpdatePhotoClan(Database.Clan entity, ClanUpdatePhotoRequest request)
        {
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiNalog.SlikaPutanja) entity.KorisnickiNalog.SlikaPutanja = await imageHelper.ReplaceImage("KorisnickiNalog", entity.KorisnickiNalogId, entity.KorisnickiNalog.SlikaPutanja, request.SlikaPutanja, request.Slika);

            entity.KorisnickiNalog.DatumIzmjene = DateTime.Now;
            await _context.SaveChangesAsync();

        }



        //Provjere
        public async Task<bool> KorisnickoImeZauzeto(string korisnickoIme)
        {
            return await _context.KorisnickiNalog.AnyAsync(s => s.KorisnickoIme == korisnickoIme);
        }

        public async Task<bool> ProvjeriDaLiPostoji(ClanInsertRequest request)
        {
            return await _context.Clan.AnyAsync(s => s.KorisnickiNalog.Ime == request.Ime && s.KorisnickiNalog.Prezime == request.Prezime && s.KorisnickiNalog.DatumRodjenja == request.DatumRodjenja && s.KorisnickiNalog.Status == true);
        }

        private bool ProvjeriPromjene(Database.Clan entity, ClanUpdateRequest request)
        {

            if (request.Ime != entity.KorisnickiNalog.Ime) return true;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiNalog.Prezime) return true;
            if (request.DatumRodjenja != entity.KorisnickiNalog.DatumRodjenja) return true;
            if (request.DatumUclanjenja != entity.DatumUclanjenja) return true;
            if (request.Ime != entity.KorisnickiNalog.Ime) return true;
            if (request.Adresa != entity.KorisnickiNalog.Adresa) return true;
            if (request.Email != entity.KorisnickiNalog.Email) return true;
            if (request.Telefon != entity.KorisnickiNalog.Telefon) return true;
            if (request.KorisnickoIme != entity.KorisnickiNalog.KorisnickoIme) return true;
            if (request.GradId != entity.GradId) return true;
            if (request.Status != entity.Status) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiNalog.SlikaPutanja) return true;
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0  && request.LozinkaPotrvda.Length > 0) return true;

            return false;
        }

        

    }
}
