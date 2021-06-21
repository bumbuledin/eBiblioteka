﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class AuthKorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public virtual Model.Uposlenik Uposlenik { get; set; }
        public virtual Model.Clan Clan { get; set; }
    }
}
