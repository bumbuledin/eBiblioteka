using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class KnjigaController : BaseCRUDController<Model.Knjiga, KnjigaSearchRequest, KnjigaUpsertRequest, KnjigaUpsertRequest>
    {
        private IKnjigaService _service;
        public KnjigaController(IKnjigaService service) : base(service)
        {
            _service = service;
        }

        [Authorize(Roles = "Administrator, Uposlenik")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }

    }
}
