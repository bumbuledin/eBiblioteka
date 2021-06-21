using eBiblioteka.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IKnjigaService: ICRUDService<Model.Knjiga,KnjigaSearchRequest,KnjigaUpsertRequest, KnjigaUpsertRequest>
    {
        Task<bool> Delete(int id);
    }
}
