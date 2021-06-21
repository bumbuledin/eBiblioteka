using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Uplata
    {
        public int UplataId { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal IznosUplate { get; set; }
        public int VrstaUplateId { get; set; }
        public int ClanId { get; set; }
        public virtual Clan Clan { get; set; }
        public virtual VrstaUplate VrstaUplate { get; set; }
    }
}
