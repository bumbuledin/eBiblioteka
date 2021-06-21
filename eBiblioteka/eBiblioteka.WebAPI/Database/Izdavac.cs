using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Izdavac
    {
        public Izdavac()
        {
            Knjige = new HashSet<Knjiga>();
        }
        public int IzdavacId { get; set; }
        public string Naziv { get; set; }
        public string KontaktEmail { get; set; }
        public virtual ICollection<Knjiga> Knjige { get; set; }
    }
}
