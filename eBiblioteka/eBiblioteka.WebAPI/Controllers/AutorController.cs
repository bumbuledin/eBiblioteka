using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class AutorController : BaseCRUDController<Model.Autor, AutorSearchRequest, AutorUpsertRequest, AutorUpsertRequest>
    {
        public AutorController(ICRUDService<Model.Autor, AutorSearchRequest, AutorUpsertRequest, AutorUpsertRequest> service) : base(service)
        {
        }
    }
}
