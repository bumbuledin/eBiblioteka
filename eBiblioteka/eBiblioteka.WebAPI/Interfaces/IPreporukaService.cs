using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IPreporukaService
    {
        Task<List<Model.Knjiga>> Preporuka(int id);
    }
}
