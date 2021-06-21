using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class Clan
    {
        public int ClanId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public DateTime DatumUclanjenja { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        public bool? Status { get; set; }
        public virtual Model.Grad Grad { get; set; }

        //Koristio sam jsonignore kako atribut ne bih prikazivao na api-u, nego samo u desktop aplikaciji 
        //za combo box.
        [JsonIgnore]
        public string ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }
    }
}
