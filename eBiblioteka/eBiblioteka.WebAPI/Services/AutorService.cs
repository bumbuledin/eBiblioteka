using AutoMapper;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Exceptions;
using eBiblioteka.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Services
{
    public class AutorService : BaseCRUDService<Model.Autor, AutorSearchRequest, Database.Autor, AutorUpsertRequest, AutorUpsertRequest>
    {
        public AutorService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Autor>> Get(AutorSearchRequest request)
        {

            var query = _context.Autor.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                request.Ime = StringHelper.FirstLetterToUpperCase(request.Ime);
                query = query.Where(s => s.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                request.Prezime = StringHelper.FirstLetterToUpperCase(request.Prezime);
                query = query.Where(s => s.Prezime.StartsWith(request.Prezime));
            }


            var list = await query.OrderBy(s => s.Ime).OrderBy(d  => d.Prezime).ToListAsync();

            return _mapper.Map<List<Model.Autor>>(list);
        }

        public async override Task<Model.Autor> Insert(AutorUpsertRequest request)
        {
            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Autor {request.Ime} {request.Prezime}  je već dodan!");
            }

            var autor = _mapper.Map<Database.Autor>(request);

            autor.ImePrezime = autor.Ime + " " + autor.Prezime;
            await _context.Autor.AddAsync(autor);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Autor>(autor);
        }

        public async override Task<Model.Autor> Update(int id, AutorUpsertRequest request)
        {
            var entity = await _context.Autor.FindAsync(id);

            if (entity == null)
            {
                throw new UserException("Autor nije pronađen!");
            }

            if (!ProvjeriPromjene(entity, request))
            {
                throw new UserException("Niste izvršili nikakve promjene nad datim autorom.");
            }

            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Autor>(entity);
        }



        //Update function
        private async Task UpdateEntity(Database.Autor entity, AutorUpsertRequest request)
        {

            if (request.Ime != null && request.Ime != entity.Ime) entity.Ime = request.Ime;
            if (request.Prezime != null && request.Prezime != entity.Prezime) entity.Prezime = request.Prezime;
            if (request.Ime != entity.Ime || request.Prezime != entity.Prezime) entity.ImePrezime = request.Ime + " " + request.Prezime;
            if (request.GodinaRodjenja != null && request.GodinaRodjenja != entity.GodinaRodjenja) entity.GodinaRodjenja = request.GodinaRodjenja;


            await _context.SaveChangesAsync();
        }



        //Provjere
        public async Task<bool> ProvjeriDaLiPostoji(AutorUpsertRequest request)
        {
            return await _context.Autor.AnyAsync(s => s.Ime == request.Ime && s.Prezime == request.Prezime);
        }

        private bool ProvjeriPromjene(Database.Autor entity, AutorUpsertRequest request)
        {

            if (request.Ime != entity.Ime) return true;
            if (request.Prezime != null && request.Prezime != entity.Prezime) return true;
            if (request.GodinaRodjenja != entity.GodinaRodjenja) return true;


            return false;
        }

    }
}
