using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime { get; set; }
        public string GodinaRodjenja { get; set; }
    }
}
