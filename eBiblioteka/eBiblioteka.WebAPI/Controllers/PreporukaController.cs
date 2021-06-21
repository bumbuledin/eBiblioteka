using eBiblioteka.WebAPI.Interfaces;
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
    public class PreporukaController : ControllerBase
    {
        private readonly IPreporukaService _service;

        public PreporukaController(IPreporukaService service)
        {
            _service = service;
        }

        [HttpGet("Preporuka/{id}")]
        public async Task<List<Model.Knjiga>> Preporuka(int id)
        {
            return await _service.Preporuka(id);
        }
    }
}
