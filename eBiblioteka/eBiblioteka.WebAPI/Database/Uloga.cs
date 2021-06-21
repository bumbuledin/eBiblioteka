using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Uloga
    {
        public Uloga()
        {
            UposleniciUloge = new HashSet<UposlenikUloga>();
        }
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<UposlenikUloga> UposleniciUloge { get; set; }
    }
}
