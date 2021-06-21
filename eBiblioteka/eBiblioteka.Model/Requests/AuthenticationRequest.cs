using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class AuthenticationRequest
    {
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
    }
}
