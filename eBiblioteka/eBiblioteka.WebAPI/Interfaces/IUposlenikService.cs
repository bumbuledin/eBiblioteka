using eBiblioteka.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IUposlenikService: ICRUDService<Model.Uposlenik,UposlenikSearchRequest,UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        Task<Model.Uposlenik> Authenticate(AuthenticationRequest request);

        Task<bool> Delete(int id);

    }
}
