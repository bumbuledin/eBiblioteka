using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class KategorijaController : BaseCRUDController<Model.Kategorija, JednaVarijablaSearchRequest, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>
    {
        public KategorijaController(ICRUDService<Model.Kategorija, JednaVarijablaSearchRequest, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest> service) : base(service)
        {
        }
    }
}
