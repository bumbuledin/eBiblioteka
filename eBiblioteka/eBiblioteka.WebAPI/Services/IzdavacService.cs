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
    public class IzdavacService : BaseCRUDService<Model.Izdavac, IzdavacSearchRequest, Database.Izdavac, IzdavacUpsertRequest, IzdavacUpsertRequest>
    {
        public IzdavacService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async override Task<List<Model.Izdavac>> Get(IzdavacSearchRequest request)
        {

            var query = _context.Izdavac.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                request.Naziv = StringHelper.FirstLetterToUpperCase(request.Naziv);
                query = query.Where(s => s.Naziv.StartsWith(request.Naziv));
            }


            var list = await query.OrderByDescending(s => s.IzdavacId).ToListAsync();

            return _mapper.Map<List<Model.Izdavac>>(list);
        }

        public async override Task<Model.Izdavac> Insert(IzdavacUpsertRequest request)
        {
            if (await ProvjeriDaLiPostoji(request.Naziv,request.KontaktEmail))
            {
                throw new UserException($"Izdavač {request.Naziv} je već dodan!");

            }

            var izdavac = _mapper.Map<Database.Izdavac>(request);

            await _context.Izdavac.AddAsync(izdavac);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Izdavac>(izdavac);
        }

        public async override Task<Model.Izdavac> Update(int id, IzdavacUpsertRequest request)
        {
            var entity = await _context.Izdavac.FindAsync(id);

            if (entity == null)
            {
                throw new UserException("Izdavač nije pronađen!");
            }

            if (!ProvjeriPromjene(entity, request))
            {
                throw new UserException("Niste izvršili nikakve promjene nad datim izdavačom.");
            }

            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Izdavac>(entity);
        }


        //Update function
        private async Task UpdateEntity(Database.Izdavac entity, IzdavacUpsertRequest request)
        {

            if (request.Naziv != null && request.Naziv != entity.Naziv) entity.Naziv = request.Naziv;
            if (request.KontaktEmail != null && request.KontaktEmail != entity.KontaktEmail) entity.KontaktEmail = request.KontaktEmail;

            await _context.SaveChangesAsync();
        }


        //Provjere
        public async Task<bool> ProvjeriDaLiPostoji(string naziv, string email)
        {
            return await _context.Izdavac.AnyAsync(s => s.Naziv == naziv && s.KontaktEmail == email);
        }

        private bool ProvjeriPromjene(Database.Izdavac entity, IzdavacUpsertRequest request)
        {

            if (request.Naziv != entity.Naziv) return true;
            if (request.KontaktEmail != null && request.KontaktEmail != entity.KontaktEmail) return true;

            return false;
        }

    }
}
