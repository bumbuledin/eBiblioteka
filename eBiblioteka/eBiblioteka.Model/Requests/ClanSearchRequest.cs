using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class ClanSearchRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Status { get; set; }
    }
}
