using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Status { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
    }
}
