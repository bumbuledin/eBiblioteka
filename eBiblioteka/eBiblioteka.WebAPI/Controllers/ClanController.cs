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
    [Authorize]
    public class ClanController : BaseCRUDController<Model.Clan, ClanSearchRequest, ClanInsertRequest, ClanUpdateRequest>
    {
        private readonly IClanService _clanService;

        public ClanController(IClanService service) : base(service)
        {
            _clanService = service;
        }

        [Authorize(Roles ="Clan")]
        [HttpPost("Authenticate")]
        public async Task<Model.Clan> Authenticate(AuthenticationRequest request)
        {
            return await _clanService.Authenticate(request);
        }

        [Authorize(Roles = "Clan")]
        [HttpPut("UpdatePhoto/{id}")]
        public async Task<Model.Clan> UpdatePhoto(int id,ClanUpdatePhotoRequest request)
        {
            return await _clanService.UpdatePhoto(id,request);
        }

        [Authorize(Roles = "Clan")]
        [HttpPut("UpdatePassword/{id}")]
        public async Task<bool> UpdatePassword(int id, ClanUpdatePasswordRequest request)
        {
            return await _clanService.UpdatePassword(id, request);
        }

        [Authorize(Roles = "Administrator, Uposlenik")]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _clanService.Delete(id);
        }

        [HttpGet("GetCounter/{id}")]
        public async Task<Model.ClanCounter> GetCounter(int id)
        {
            return await _clanService.GetCounter(id);
        }
    }
}
