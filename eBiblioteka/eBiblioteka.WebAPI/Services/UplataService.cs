using AutoMapper;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Exceptions;
using eBiblioteka.WebAPI.Helpers;
using eBiblioteka.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Services
{
    public class UplataService : BaseCRUDService<Model.Uplata, UplataSearchRequest, Database.Uplata, UplataUpsertRequest, UplataUpsertRequest>, IUplataService
    {
        public UplataService(eBibliotekaContext context, IMapper mapper) : base(context, mapper)
        {

        }

        

        public async override Task<List<Model.Uplata>> Get(UplataSearchRequest request)
        {

            var query = _context.Uplata.Include("VrstaUplate").Include("Clan.KorisnickiNalog").AsQueryable();

            if (request?.ClanId.HasValue == true )
            {
                query = query.Where(s => s.ClanId == request.ClanId);
            }

            if(request?.DatumOd != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumUplate.Date, (DateTime)request.DatumOd.Value.Date) >= 0);
            }

            if (request?.DatumDo != null)
            {
                query = query.Where(s => DateTime.Compare(s.DatumUplate.Date, (DateTime)request.DatumDo.Value.Date) <= 0);
            }

            var list = await query.OrderByDescending(s=> s.DatumUplate).ToListAsync();

            return _mapper.Map<List<Model.Uplata>>(list);
        }

        public async override Task<Model.Uplata> GetById(int id)
        {
            var entity = await _context.Uplata.Include("VrstaUplate").Include("Clan.KorisnickiNalog").Where(s=> s.UplataId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Uplata nije pronađena!");
            }


            return _mapper.Map<Model.Uplata>(entity);
        }

        public async override Task<Model.Uplata> Insert(UplataUpsertRequest request)
        {
            var uplata = _mapper.Map<Database.Uplata>(request);

            await _context.Uplata.AddAsync(uplata);
            await _context.SaveChangesAsync();

            var uplatawithchildren = await _context.Uplata.Include("Clan").Include("VrstaUplate").Where(s => s.UplataId == uplata.UplataId).SingleOrDefaultAsync();
            return _mapper.Map<Model.Uplata>(uplata);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Uplata.FindAsync(id);


            if (entity == null)
            {
                throw new UserException("Uplata nije pronađena!");
            }

            try
            {
                _context.Uplata.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
