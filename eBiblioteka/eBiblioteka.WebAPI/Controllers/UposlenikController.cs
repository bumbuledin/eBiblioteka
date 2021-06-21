using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UposlenikController : BaseCRUDController<Model.Uposlenik, UposlenikSearchRequest, UposlenikInsertRequest, UposlenikUpdateRequest>
    {
        private readonly IUposlenikService _uposlenikService;

        public UposlenikController(IUposlenikService service) : base(service)
        {
            _uposlenikService = service;
        }

        [Authorize(Roles = "Administrator, Uposlenik")]
        [HttpPost("Authenticate")]
        public async Task<Model.Uposlenik> Authenticate(AuthenticationRequest request)
        {
            return await _uposlenikService.Authenticate(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _uposlenikService.Delete(id);
        }

    }
}
