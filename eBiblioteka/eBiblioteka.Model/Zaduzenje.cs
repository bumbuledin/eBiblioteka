using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class Zaduzenje
    {
        public int ZaduzenjeId { get; set; }
        public DateTime DatumZaduzenja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public bool Status { get; set; }
        public int ClanId { get; set; }
        public int KnjigaId { get; set; }

        public virtual Model.Clan Clan { get; set; }
        public virtual Model.Knjiga Knjiga { get; set; }

        //Koristio sam jsonignore kako atribut ne bih prikazivao na api-u, nego samo u desktop aplikaciji 
        //za combo box.
        [JsonIgnore]
        public string ImePrezimeClana
        {
            get { return Clan.ImePrezime; }
        }

        [JsonIgnore]
        public string NazivKnjige
        {
            get { return Knjiga.Naziv; }
        }
    }
}
