﻿using eBiblioteka.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public async Task<T> Insert([FromBody] TInsert request)
        {
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public async Task<T> Update(int id, [FromBody] TUpdate request)
        {
            return await _crudService.Update(id, request);
        }


    }
}
