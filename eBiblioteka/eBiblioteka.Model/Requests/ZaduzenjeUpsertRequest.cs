using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class ZaduzenjeUpsertRequest
    { 
        public int ClanId { get; set; }
        public int KnjigaId { get; set; }
        public DateTime DatumZaduzenja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        // prilikom mijenjanja statusa rezervacije u zaduzenje, kako bi mogao dodati zaduzenje bez uslova od 3 aktivna.
        public bool? ProvjeriBrojZaduzenjaRezervacija { get; set; }
        public bool? Status { get; set; }
    }
}
