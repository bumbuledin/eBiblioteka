using eBiblioteka.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisnickiNalog _nalogService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IKorisnickiNalog nalogService)
            : base(options, logger, encoder, clock)
        {
            _nalogService = nalogService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            Model.AuthKorisnickiNalog user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                user = await _nalogService.Authenticiraj(username, password);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Pogrešano korisničko ime ili lozinka");

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.KorisnickoIme),
                new Claim(ClaimTypes.Name, user.Ime),
                new Claim(ClaimTypes.Surname, user.Prezime)
            };

            // Pošto uposlenik i clan imaju zajednicku tabelu korisnicki nalog, provjeravamo da li je koirsnicki nalog od uposlenika ili clana
            // te ukoliko je uposlenik, dodajemo njegove uloge koje mogu biti Administrator ili Uposlenik
            if (user.Uposlenik != null)
            {
                foreach (var role in user.Uposlenik.UposlenikUloga)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Uloga.Naziv));
                }
            }
            // Za clana sam dodao ulogu clan bez tabele, jer nema potrebe praviti tabelu sa ulogom koju koristim samo prilikom logiranja,
            // tj. da zabranim korisnicima logiranje u mobilnu aplikaciju, ako nisu članovi ( ovo se odnosi na problem da se pokuša logovanje
            // u mobilnoj aplikaciji sa nalogom uposlenika! )

            if(user.Clan != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Clan"));
            }
               
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
