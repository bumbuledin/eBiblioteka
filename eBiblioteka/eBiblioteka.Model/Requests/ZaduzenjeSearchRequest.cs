using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class ZaduzenjeSearchRequest
    {
        public int? ZaduzenjeId { get; set; }
        public int? ClanId { get; set; }
        public string ClanIme { get; set; }
        public string Knjiga { get; set; }
        public bool Status { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
    }
}
