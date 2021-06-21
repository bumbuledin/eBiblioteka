using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class RezervacijaSearchRequest
    {
        public int? RezervacijaId { get; set; }
        public int? ClanId { get; set; }
        public string Naziv { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public bool Status { get; set; }
    }
}
