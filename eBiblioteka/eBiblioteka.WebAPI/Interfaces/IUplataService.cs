using eBiblioteka.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IUplataService: ICRUDService<Model.Uplata, UplataSearchRequest,UplataUpsertRequest, UplataUpsertRequest>
    {
        Task<bool> Delete(int id);
    }
}
