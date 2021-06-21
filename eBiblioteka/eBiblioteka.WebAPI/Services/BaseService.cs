using AutoMapper;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Exceptions;
using eBiblioteka.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        public readonly IMapper _mapper;
        public readonly eBibliotekaContext _context;
        public BaseService(eBibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<List<TModel>> Get(TSearch search)
        {
            var list = await _context.Set<TDatabase>().ToListAsync();

            return _mapper.Map<List<TModel>>(list);
        }

        public virtual async Task<TModel> GetById(int id)
        {
            var entity = await _context.Set<TDatabase>().FindAsync(id);

            if (entity == null)
                throw new UserException(typeof(TDatabase).Name + " nije pronađen.");

            return _mapper.Map<TModel>(entity);
        }
    }
}
