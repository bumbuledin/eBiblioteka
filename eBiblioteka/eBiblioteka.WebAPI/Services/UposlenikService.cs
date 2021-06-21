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
    public class UposlenikService : BaseCRUDService<Model.Uposlenik, UposlenikSearchRequest, Database.Uposlenik, UposlenikInsertRequest, UposlenikUpdateRequest>, IUposlenikService
    {
        private ImageHelper imageHelper = new ImageHelper();

        public UposlenikService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<Model.Uposlenik> Authenticate(AuthenticationRequest request)
        {
            var user =  await _context.Uposlenik.Include("UposlenikUloga.Uloga").Include("KorisnickiNalog").FirstOrDefaultAsync(s => s.KorisnickiNalog.KorisnickoIme == request.KorisnickoIme);

            if (user == null)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");
            }

            if (user.KorisnickiNalog.Status == false)
            {
                throw new UserException("Korisnički nalog je deaktiviran. Molimo kontaktirajte administratora.");

            }

            var newHash = HashGenerator.GenerateHash(user.KorisnickiNalog.LozinkaSalt, request.Password);

            if (newHash != user.KorisnickiNalog.LozinkaHash)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");

            }

            return _mapper.Map<Model.Uposlenik>(user);
        }

        public async override Task<List<Model.Uposlenik>> Get(UposlenikSearchRequest request)
        {
            var query = _context.Uposlenik.Include("Grad").Include("KorisnickiNalog").Include("UposlenikUloga.Uloga").AsQueryable();

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

            var result = _mapper.Map<List<Model.Uposlenik>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        public async override Task<Model.Uposlenik> GetById(int id)
        {
            var entity = await _context.Uposlenik.Include("Grad").Include("KorisnickiNalog").Include("UposlenikUloga.Uloga").Where(s => s.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uposlenik nije pronađen!");
            }

            var result = _mapper.Map<Model.Uposlenik>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "KorisnickiNalog", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Uposlenik> Insert(UposlenikInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotrvda)
                throw new UserException("Lozinke se ne podudaraju!");

            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Uposlenik {request.Ime} {request.Prezime}, datum rođenja ( {request.DatumRodjenja.ToString("dd/MM/yyyy")} ) je već dodan!");
            }

            if (await KorisnickoImeZauzeto(request.KorisnickoIme))
            {
                throw new UserException("Korisničko ime je zauzeto!");
            }

            if(request.GradId == 0)
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

            var uposlenik = _mapper.Map<Database.Uposlenik>(request);
            uposlenik.KorisnickiNalogId = nalog.KorisnickiNalogId;
            uposlenik.DatumZaposlenja = DateTime.Now;

            await _context.Uposlenik.AddAsync(uposlenik);
            await _context.SaveChangesAsync();

            foreach (var uloga in request.Uloge)
            {
                await _context.UposlenikUloga.AddAsync(new UposlenikUloga()
                {
                    DatumIzmjene = DateTime.Now,
                    UposlenikId = uposlenik.UposlenikId,
                    UlogaId = uloga
                });
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Uposlenik>(uposlenik);
        }

        public async override Task<Model.Uposlenik> Update(int id, UposlenikUpdateRequest request)
        {
            var entity = await _context.Uposlenik.Include("Grad").Include("KorisnickiNalog").Include("UposlenikUloga.Uloga").Where(s => s.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uposlenik nije pronađen!");
            }

            if (request.KorisnickoIme != entity.KorisnickiNalog.KorisnickoIme && await KorisnickoImeZauzeto(request.KorisnickoIme) == true)
            {
                throw new UserException("Korisničko ime je zauzeto");
            }

            if(request.Lozinka != null && request.LozinkaPotrvda != null)
                if (request.Lozinka != request.LozinkaPotrvda)
                    throw new UserException("Lozinke se ne podudaraju!");


            if (ProvjeriPromjene(entity, request) == false && ProvjeriPromjeneUloga(entity,request)==true)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");
            }

            await UpdateEntity(entity, request);

            //Ukoliko je izvrsena izmjena nad ulogama uposlenika, brišemo postojeće te dodajemo nove ili novu.
            if(ProvjeriPromjeneUloga(entity,request)==false)
            {
                if(await ProvjeriAdministratore(entity,request))
                {
                    throw new UserException("Odabrani uposlenik je posljednji administrator u sistemu. Uklanjanje uloge administrator nije moguće. Molimo selektirajte ulogu ¨Administrator¨.");
                }
                foreach (var item in entity.UposlenikUloga)
                {
                    _context.UposlenikUloga.Remove(item);
                }

                await _context.SaveChangesAsync();

                foreach (var uloga in request.Uloge)
                {
                   await _context.UposlenikUloga.AddAsync(new UposlenikUloga()
                    {
                        DatumIzmjene = DateTime.Now,
                        UposlenikId = entity.UposlenikId,
                        UlogaId = uloga
                    });
                }

                await _context.SaveChangesAsync();

            }
            return _mapper.Map<Model.Uposlenik>(entity);
        }

        // Za delete nisam brisao entitet nego samo promjenio status, jer brisanje povlaci za sobom i probleme brisanja uplata i zaduzenja,
        // što bi se svakako odrazilo na samu tačnost izvještaja i informacija u aplikaciji.
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Uposlenik.Include("Grad").Include("KorisnickiNalog").Where(s => s.UposlenikId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uposlenik nije pronađen!");
            }
            try
            {
                var uloge = _context.UposlenikUloga.Where(x => x.UposlenikId == entity.UposlenikId);

                if (await uloge.AnyAsync(s => s.Uloga.Naziv == "Administrator"))
                    throw new UserException("Nije moguće deaktivirati uposlenika sa ulogom administrator.");

                
                entity.KorisnickiNalog.Status = false;
                entity.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //Update function
        private async Task UpdateEntity(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {

            if (request.Ime != null && request.Ime != entity.KorisnickiNalog.Ime) entity.KorisnickiNalog.Ime = request.Ime;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiNalog.Prezime) entity.KorisnickiNalog.Prezime = request.Prezime;
            if (request.DatumRodjenja != null && request.DatumRodjenja != entity.KorisnickiNalog.DatumRodjenja) entity.KorisnickiNalog.DatumRodjenja = request.DatumRodjenja;
            if (request.DatumZaposlenja != null && request.DatumZaposlenja != entity.DatumZaposlenja) entity.DatumZaposlenja = request.DatumZaposlenja;
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



        // Provjere
        public async Task<bool> KorisnickoImeZauzeto(string korisnickoIme)
        {
            return await _context.KorisnickiNalog.AnyAsync(s => s.KorisnickoIme == korisnickoIme);
        }
        public async Task<bool> ProvjeriDaLiPostoji(UposlenikInsertRequest request)
        {
            return await _context.Uposlenik.AnyAsync(s => s.KorisnickiNalog.Ime == request.Ime && s.KorisnickiNalog.Prezime == request.Prezime && s.KorisnickiNalog.DatumRodjenja == request.DatumRodjenja && s.KorisnickiNalog.Status == true);
        }
        private bool ProvjeriPromjene(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {

            if (request.Ime != entity.KorisnickiNalog.Ime) return true;
            if (request.Prezime != null && request.Prezime != entity.KorisnickiNalog.Prezime) return true;
            if (request.DatumRodjenja != entity.KorisnickiNalog.DatumRodjenja) return true;
            if (request.DatumZaposlenja != entity.DatumZaposlenja) return true;
            if (request.Ime != entity.KorisnickiNalog.Ime) return true;
            if (request.Adresa != entity.KorisnickiNalog.Adresa) return true;
            if (request.Email != entity.KorisnickiNalog.Email) return true;
            if (request.Telefon != entity.KorisnickiNalog.Telefon) return true;
            if (request.KorisnickoIme != entity.KorisnickiNalog.KorisnickoIme) return true;
            if (request.GradId != entity.GradId) return true;
            if (request.Status != entity.Status) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.KorisnickiNalog.SlikaPutanja) return true;
            if (request.Lozinka != null && request.LozinkaPotrvda != null && request.Lozinka.Length > 0 && request.LozinkaPotrvda.Length > 0) return true;


            return false;
        }
        private bool ProvjeriPromjeneUloga(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {
           
            var list = entity.UposlenikUloga.Select(x => x.UlogaId).ToList();
            var list2 = request.Uloge.ToList();

            var inListButNotInList2 = list.Except(list2);
            var inList2ButNotInList = list2.Except(list);

            return !inListButNotInList2.Any() && !inList2ButNotInList.Any();
        }

        private async Task<bool> ProvjeriAdministratore(Database.Uposlenik entity, UposlenikUpdateRequest request)
        {
            var administratorUloga = entity.UposlenikUloga.Any(s => s.Uloga.Naziv == "Administrator");

            if(administratorUloga != false)
            {
                var brojAdministratora = await _context.UposlenikUloga.Where(s => s.Uposlenik.Status == true && s.Uloga.Naziv == "Administrator").CountAsync();

                var ulogaAdministrator = await _context.Uloga.Where(s => s.Naziv == "Administrator").SingleOrDefaultAsync();

                int brojac = 0;

                foreach (var uloga in request.Uloge)
                {
                    if (uloga == ulogaAdministrator.UlogaId)
                        brojac++;
                }

                if (brojac == 0 && brojAdministratora == 1)
                    return true;
            }

            return false;
        }
    }

}
