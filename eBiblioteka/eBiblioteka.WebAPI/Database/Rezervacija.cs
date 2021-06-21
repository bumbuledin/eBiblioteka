using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public bool? Status { get; set; }
        public int ClanId { get; set; }
        public int KnjigaId { get; set; }
        public virtual Clan Clan { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}
