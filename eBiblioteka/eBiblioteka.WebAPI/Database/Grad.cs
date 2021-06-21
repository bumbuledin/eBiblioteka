using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Grad
    {
        public Grad()
        {
            Clanovi = new HashSet<Clan>();
            Uposlenici = new HashSet<Uposlenik>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Clan> Clanovi { get; set; }

        public virtual ICollection<Uposlenik> Uposlenici { get; set; }
    }
}
