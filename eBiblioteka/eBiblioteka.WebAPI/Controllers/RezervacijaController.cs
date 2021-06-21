using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Controllers
{
    public class ZaduzenjeController : BaseCRUDController<Model.Zaduzenje, ZaduzenjeSearchRequest, ZaduzenjeUpsertRequest, ZaduzenjeUpsertRequest>
    {
        public ZaduzenjeController(ICRUDService<Model.Zaduzenje, ZaduzenjeSearchRequest, ZaduzenjeUpsertRequest, ZaduzenjeUpsertRequest> service) : base(service)
        {
        }
    }
}
