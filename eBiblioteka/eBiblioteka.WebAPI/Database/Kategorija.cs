using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Kategorija
    {
        public Kategorija()
        {
            Knjige = new HashSet<Knjiga>();
        }
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Knjiga> Knjige { get; set; }

    }
}
