using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class KorisnickiNalog
    {
        public int KorisnickiNalogId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public bool? Status { get; set; }
        public string SlikaPutanja { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }
        public virtual Clan Clan { get; set; }

    }
}
