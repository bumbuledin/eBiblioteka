using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class Knjiga
    {
        public Knjiga()
        {
            Zaduzenja = new HashSet<Zaduzenje>();
            Rezervacije = new HashSet<Rezervacija>();
        }

        public int KnjigaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string GodinaIzdavanja { get; set; }
        public string InventarniBroj { get; set; }
        public int BrojStranica { get; set; }
        public int BrojKnjigaNaStanju { get; set; }
        public string SlikaPutanja { get; set; }
        public bool? Status { get; set; }
        public int AutorId { get; set; }
        public int IzdavacId { get; set; }
        public int KategorijaId { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Izdavac Izdavac { get; set; }
        public virtual Kategorija Kategorija { get; set; }

        public virtual ICollection<Zaduzenje> Zaduzenja { get; set; }
        public virtual ICollection<Rezervacija> Rezervacije { get; set; }

    }
}
