using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Autor
    {
        public Autor()
        {
            Knjige = new HashSet<Knjiga>();
        }
        public int AutorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime { get; set; }
        public string GodinaRodjenja { get; set; }
        public virtual ICollection<Knjiga> Knjige { get; set; }

    }
}
