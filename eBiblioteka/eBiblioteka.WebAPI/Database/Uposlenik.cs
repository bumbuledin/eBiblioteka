using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Uposlenik
    {
        public Uposlenik()
        {
            UposlenikUloga = new HashSet<UposlenikUloga>();
        }

        public int UposlenikId { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public bool? Status { get; set; }
        public int GradId { get; set; }
        public int KorisnickiNalogId { get; set; }
        public virtual KorisnickiNalog KorisnickiNalog { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual ICollection<UposlenikUloga> UposlenikUloga { get; set; }
    }
}
