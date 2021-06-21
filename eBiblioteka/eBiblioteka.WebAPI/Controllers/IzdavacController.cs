using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class IzdavacController : BaseCRUDController<Model.Izdavac, IzdavacSearchRequest, IzdavacUpsertRequest, IzdavacUpsertRequest>
    {
        public IzdavacController(ICRUDService<Model.Izdavac, IzdavacSearchRequest, IzdavacUpsertRequest, IzdavacUpsertRequest> service) : base(service)
        {
        }
    }
}
