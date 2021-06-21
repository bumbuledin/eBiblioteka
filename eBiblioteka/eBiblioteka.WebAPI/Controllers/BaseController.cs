using eBiblioteka.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<TModel, TSearch> : ControllerBase
    {
        private readonly IService<TModel, TSearch> _service;


        public BaseController(IService<TModel, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<TModel>> Get([FromQuery] TSearch search)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public async Task<TModel> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}
