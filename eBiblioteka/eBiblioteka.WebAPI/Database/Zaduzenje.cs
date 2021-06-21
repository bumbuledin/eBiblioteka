using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Zaduzenje
    {
        public int ZaduzenjeId { get; set; }
        public DateTime DatumZaduzenja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public bool? Status { get; set; }
        public int ClanId { get; set; }
        public int KnjigaId { get; set; }
        public virtual Clan Clan { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}
