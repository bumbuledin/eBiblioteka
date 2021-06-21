using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Clan
    {
        public Clan()
        {
            Zaduzenja = new HashSet<Zaduzenje>();
            Rezervacije = new HashSet<Rezervacija>();
            Uplate = new HashSet<Uplata>();
        }

        public int ClanId { get; set; }
        public DateTime DatumUclanjenja { get; set; }
        public bool? Status { get; set; }
        public int GradId { get; set; }
        public int KorisnickiNalogId { get; set; }

        public virtual KorisnickiNalog KorisnickiNalog { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual ICollection<Zaduzenje> Zaduzenja { get; set; }
        public virtual ICollection<Rezervacija> Rezervacije { get; set; }
        public virtual ICollection<Uplata> Uplate { get; set; }

    }
}
