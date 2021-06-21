using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Interfaces
{
    public interface IKorisnickiNalog
    {
        Task<Model.AuthKorisnickiNalog> Authenticiraj(string KorisnickoIme, string Lozinka);
    }
}
