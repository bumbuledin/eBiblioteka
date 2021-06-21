using AutoMapper;
using eBiblioteka.Model;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Interfaces;
using eBiblioteka.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eBiblioteka.WebAPI.Exceptions;

namespace eBiblioteka.WebAPI.Services
{
    public class KoirsnickiNalogService : IKorisnickiNalog
    {
        private readonly eBibliotekaContext _context;
        private readonly IMapper _mapper;

        public KoirsnickiNalogService(eBibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Model.AuthKorisnickiNalog> Authenticiraj(string KorisnickoIme, string Lozinka)
        {
            var user =  await _context.KorisnickiNalog.Include("Uposlenik.UposlenikUloga.Uloga").Include("Clan").FirstOrDefaultAsync(s => s.KorisnickoIme == KorisnickoIme);

            if(user == null)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");
            }

            var newHash = HashGenerator.GenerateHash(user.LozinkaSalt, Lozinka);

            if (newHash != user.LozinkaHash)
            {
                throw new UserException("Pogrešano korisničko ime ili lozinka");

            }

            return  _mapper.Map<Model.AuthKorisnickiNalog>(user);
        }
    }
}
