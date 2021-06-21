using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IService<TModel, TSearch>
    {
        Task<List<TModel>> Get(TSearch search);
        Task<TModel> GetById(int id);
    }
}
