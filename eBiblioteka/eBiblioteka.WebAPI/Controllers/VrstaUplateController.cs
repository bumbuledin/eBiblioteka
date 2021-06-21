using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class VrstaUplateController : BaseCRUDController<Model.VrstaUplate, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>
    {
        public VrstaUplateController(ICRUDService<Model.VrstaUplate, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest> service) : base(service)
        {
        }
    }
}
