using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class RezervacijaUpsertRequest
    {
        public DateTime DatumRezervacije { get; set; }
        public bool? Status { get; set; }
        public int ClanId { get; set; }
        public int KnjigaId { get; set; }
        public bool? ClanMessage { get; set; }
    }
}
