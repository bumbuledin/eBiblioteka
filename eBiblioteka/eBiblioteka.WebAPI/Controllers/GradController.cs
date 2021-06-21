using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class GradController : BaseCRUDController<Model.Grad, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>
    {
        public GradController(ICRUDService<Model.Grad, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest> service) : base(service)
        {
        }
    }
}
