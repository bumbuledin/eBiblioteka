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
    [Authorize(Roles = "Administrator, Uposlenik")]
    public class UlogaController : BaseController<Model.Uloga, object>
    {
        public UlogaController(IService<Uloga, object> service) : base(service)
        {
        }
    }
}
