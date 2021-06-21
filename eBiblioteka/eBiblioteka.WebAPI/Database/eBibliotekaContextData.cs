using eBiblioteka.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public partial class eBibliotekaContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            #region Vrsta uplate
            modelBuilder.Entity<VrstaUplate>().HasData(new VrstaUplate()
            {
                VrstaUplateId = 1,
                Naziv = "Mjesečna uplata",
            });

            modelBuilder.Entity<VrstaUplate>().HasData(new VrstaUplate()
            {
                VrstaUplateId = 2,
                Naziv = "Godišnja uplata",
            });
            #endregion

            #region Grad
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 1,
                Naziv = "Mostar"
            });

            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 2,
                Naziv = "Sarajevo"
            });

            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 3,
                Naziv = "Bugojno"
            });

            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 4,
                Naziv = "Tuzla"
            });
            #endregion

            #region KorisnickiNalog

            KorisnickiNalog a1 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 1,
                Ime = "Desktop",
                Prezime = "Korisnik",
                Email = "desktop@desktop.com",
                Telefon = "061-222-333",
                DatumRodjenja = new DateTime(1991, 05, 23),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "desktop",
                DatumIzmjene = new DateTime(2021, 04, 12)
            };
            a1.LozinkaSalt = HashGenerator.GenerateSalt();
            a1.LozinkaHash = HashGenerator.GenerateHash(a1.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a1);

            KorisnickiNalog a2 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 2,
                Ime = "Uposlenik",
                Prezime = "Korisnik",
                Email = "uposlenik@uposlenik.com",
                Telefon = "061-111-333",
                DatumRodjenja = new DateTime(1995, 12, 03),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };
            a2.LozinkaSalt = HashGenerator.GenerateSalt();
            a2.LozinkaHash = HashGenerator.GenerateHash(a2.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a2);

            KorisnickiNalog a3 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 3,
                Ime = "Uposlenik1",
                Prezime = "Korisnik1",
                Email = "uposlenik1@uposlenik1.com",
                Telefon = "061-111-4444",
                DatumRodjenja = new DateTime(1985, 05, 13),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik1",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };
            a3.LozinkaSalt = HashGenerator.GenerateSalt();
            a3.LozinkaHash = HashGenerator.GenerateHash(a3.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a3);

            KorisnickiNalog a4 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 4,
                Ime = "Uposlenik2",
                Prezime = "Korisnik2",
                Email = "uposlenik2@uposlenik2.com",
                Telefon = "062-333-333",
                DatumRodjenja = new DateTime(1982, 05, 03),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik2",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };
            a4.LozinkaSalt = HashGenerator.GenerateSalt();
            a4.LozinkaHash = HashGenerator.GenerateHash(a4.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a4);

            KorisnickiNalog a5 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 5,
                Ime = "Uposlenik3",
                Prezime = "Korisnik3",
                Email = "uposlenik3@uposlenik3.com",
                Telefon = "063-123-323",
                DatumRodjenja = new DateTime(1989, 07, 21),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik3",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };
            a5.LozinkaSalt = HashGenerator.GenerateSalt();
            a5.LozinkaHash = HashGenerator.GenerateHash(a5.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a5);

            KorisnickiNalog a6 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 6,
                Ime = "Uposlenik4",
                Prezime = "Korisnik4",
                Email = "uposlenik4@uposlenik4.com",
                Telefon = "063-423-444",
                DatumRodjenja = new DateTime(1999, 07, 11),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik4",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a6.LozinkaSalt = HashGenerator.GenerateSalt();
            a6.LozinkaHash = HashGenerator.GenerateHash(a6.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a6);

            KorisnickiNalog a7 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 7,
                Ime = "Uposlenik5",
                Prezime = "Korisnik5",
                Email = "uposlenik5@uposlenik5.com",
                Telefon = "062-223-666",
                DatumRodjenja = new DateTime(1992, 07, 18),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "uposlenikavatar.png",
                KorisnickoIme = "uposlenik5",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a7.LozinkaSalt = HashGenerator.GenerateSalt();
            a7.LozinkaHash = HashGenerator.GenerateHash(a7.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a7);

            KorisnickiNalog a8 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 8,
                Ime = "Mobile",
                Prezime = "Korisnik",
                Email = "mobile@mobile.com",
                Telefon = "062-223-666",
                DatumRodjenja = new DateTime(1999, 07, 18),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mojaslika.jpg",
                KorisnickoIme = "mobile",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a8.LozinkaSalt = HashGenerator.GenerateSalt();
            a8.LozinkaHash = HashGenerator.GenerateHash(a8.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a8);

            KorisnickiNalog a9 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 9,
                Ime = "Clan",
                Prezime = "Korisnik",
                Email = "clan@clan.com",
                Telefon = "063-223-666",
                DatumRodjenja = new DateTime(1999, 07, 18),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a9.LozinkaSalt = HashGenerator.GenerateSalt();
            a9.LozinkaHash = HashGenerator.GenerateHash(a9.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a9);

            KorisnickiNalog a10 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 10,
                Ime = "Clan1",
                Prezime = "Korisnik1",
                Email = "clan1@clan1.com",
                Telefon = "061-123-966",
                DatumRodjenja = new DateTime(2001, 03, 08),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan1",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a10.LozinkaSalt = HashGenerator.GenerateSalt();
            a10.LozinkaHash = HashGenerator.GenerateHash(a10.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a10);

            KorisnickiNalog a11 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 11,
                Ime = "Clan2",
                Prezime = "Korisnik2",
                Email = "clan2@clan2.com",
                Telefon = "061-123-966",
                DatumRodjenja = new DateTime(1992, 11, 16),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan2",
                DatumIzmjene = new DateTime(2021, 05, 22)
            };

            a11.LozinkaSalt = HashGenerator.GenerateSalt();
            a11.LozinkaHash = HashGenerator.GenerateHash(a11.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a11);

            KorisnickiNalog a12 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 12,
                Ime = "Clan3",
                Prezime = "Korisnik3",
                Email = "clan3@clan3.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1995, 12, 06),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan3",
                DatumIzmjene = new DateTime(2021, 03, 04)
            };


            a12.LozinkaSalt = HashGenerator.GenerateSalt();
            a12.LozinkaHash = HashGenerator.GenerateHash(a12.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a12);

            KorisnickiNalog a13 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 13,
                Ime = "Clan4",
                Prezime = "Korisnik4",
                Email = "clan4@clan4.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1998, 02, 06),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan4",
                DatumIzmjene = new DateTime(2021, 03, 07)
            };

            a13.LozinkaSalt = HashGenerator.GenerateSalt();
            a13.LozinkaHash = HashGenerator.GenerateHash(a13.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a13);

            KorisnickiNalog a14 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 14,
                Ime = "Clan5",
                Prezime = "Korisnik5",
                Email = "clan5@clan5.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1998, 08, 16),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan5",
                DatumIzmjene = new DateTime(2021, 05, 07)
            };

            a14.LozinkaSalt = HashGenerator.GenerateSalt();
            a14.LozinkaHash = HashGenerator.GenerateHash(a14.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a14);

            KorisnickiNalog a15 = new KorisnickiNalog()
            {
                KorisnickiNalogId = 15,
                Ime = "Clan6",
                Prezime = "Korisnik6",
                Email = "clan6@clan6.com",
                Telefon = "061-223-122",
                DatumRodjenja = new DateTime(1995, 03, 11),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "clanavatar.png",
                KorisnickoIme = "clan6",
                DatumIzmjene = new DateTime(2021, 06, 03)
            };

            a15.LozinkaSalt = HashGenerator.GenerateSalt();
            a15.LozinkaHash = HashGenerator.GenerateHash(a15.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiNalog>().HasData(a15);
            #endregion

            #region Clan

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 1,
                DatumUclanjenja = new DateTime(2020, 01, 03),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 8
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 2,
                DatumUclanjenja = new DateTime(2020, 01, 10),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 9
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 3,
                DatumUclanjenja = new DateTime(2020, 05, 10),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 10
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 4,
                DatumUclanjenja = new DateTime(2020, 10, 04),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 11
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 5,
                DatumUclanjenja = new DateTime(2020, 10, 04),
                Status = false,
                GradId = 1,
                KorisnickiNalogId = 12
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 6,
                DatumUclanjenja = new DateTime(2020, 12, 07),
                Status = false,
                GradId = 1,
                KorisnickiNalogId = 13
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 7,
                DatumUclanjenja = new DateTime(2021, 05, 07),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 14
            });

            modelBuilder.Entity<Clan>().HasData(new Clan()
            {
                ClanId = 8,
                DatumUclanjenja = new DateTime(2021, 06, 03),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 15
            });
            #endregion

            #region Uposlenik

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 1,
                DatumZaposlenja = new DateTime(2021, 03, 12),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 1
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 2,
                DatumZaposlenja = new DateTime(2021, 01, 22),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 2
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 3,
                DatumZaposlenja = new DateTime(2020, 11, 12),
                Status = true,
                GradId = 2,
                KorisnickiNalogId = 3
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 4,
                DatumZaposlenja = new DateTime(2020, 01, 03),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 4
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 5,
                DatumZaposlenja = new DateTime(2020, 03, 13),
                Status = true,
                GradId = 1,
                KorisnickiNalogId = 5
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 6,
                DatumZaposlenja = new DateTime(2019, 06, 11),
                Status = false,
                GradId = 1,
                KorisnickiNalogId = 6
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 7,
                DatumZaposlenja = new DateTime(2019, 06, 11),
                Status = false,
                GradId = 1,
                KorisnickiNalogId = 7
            });

            #endregion

            #region Uloga

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaId = 1,
                Naziv = "Administrator"
            });

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaId = 2,
                Naziv = "Uposlenik"
            });

            #endregion

            #region UposlenikUloga

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 1,
                UposlenikId = 1,
                UlogaId = 1,
                DatumIzmjene = new DateTime(2021, 03, 12)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 2,
                UposlenikId = 1,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 03, 12)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 3,
                UposlenikId = 2,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 4,
                UposlenikId = 3,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 5,
                UposlenikId = 4,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 6,
                UposlenikId = 5,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 7,
                UposlenikId = 6,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 8,
                UposlenikId = 7,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            #endregion

            #region Kategorija

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 1,
                Naziv = "Drama"
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 2,
                Naziv = "Roman"
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 3,
                Naziv = "Fantazija"
            });
            #endregion

            #region Izdavac

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 1,
                Naziv = "Scholastic Press",
                KontaktEmail = "contact@scholasticpress.com"

            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 2,
                Naziv = "Northwestern University Press",
                KontaktEmail = "contact@nup.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 3,
                Naziv = "Connectum",
                KontaktEmail = "kontakt@connectum.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 4,
                Naziv = "Dereta",
                KontaktEmail = "kontakt@dereta.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 5,
                Naziv = "Sezam book",
                KontaktEmail = "kontakt@sezambook.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 6,
                Naziv = "Plato",
                KontaktEmail = "plato@plato.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 7,
                Naziv = "Laguna",
                KontaktEmail = "laguna@laguna.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 8,
                Naziv = "Vulkan",
                KontaktEmail = "kontakt@vulkan.com"
            });

            modelBuilder.Entity<Izdavac>().HasData(new Izdavac()
            {
                IzdavacId = 9,
                Naziv = "Fraktura",
                KontaktEmail = "fraktura@fraktura.com"
            });


            #endregion

            #region Autor

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 1,
                Ime = "Suzanne",
                Prezime = "Collins",
                ImePrezime = "Suzanne Collins",
                GodinaRodjenja = "1962"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 2,
                Ime = "Meša",
                Prezime = "Selimović",
                ImePrezime = "Meša Selimović",
                GodinaRodjenja = "1910"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 3,
                Ime = "Ivo",
                Prezime = "Andrić",
                ImePrezime = "Ivo Andrić",
                GodinaRodjenja = "1892"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 4,
                Ime = "Ernesto",
                Prezime = "Sabato",
                ImePrezime = "Ernesto Sabato",
                GodinaRodjenja = "1911"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 5,
                Ime = "Dejan",
                Prezime = "Aleksić",
                ImePrezime = "Dejan Aleksić",
                GodinaRodjenja = "1972"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 6,
                Ime = "Nikolas",
                Prezime = "Sparks",
                ImePrezime = "Nikolas Sparks",
                GodinaRodjenja = "1965"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 7,
                Ime = "Uve",
                Prezime = "Jonzon",
                ImePrezime = "Uve Jonzon",
                GodinaRodjenja = "1934"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 8,
                Ime = "Stephen",
                Prezime = "King",
                ImePrezime = "Stephen King",
                GodinaRodjenja = "1947"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 9,
                Ime = "Stina",
                Prezime = "Džekson",
                ImePrezime = "Stina Džekson",
                GodinaRodjenja = "1947"
            });

            modelBuilder.Entity<Autor>().HasData(new Autor()
            {
                AutorId = 10,
                Ime = "Ognjen",
                Prezime = "Spahić",
                ImePrezime = "Ognjen Spahić",
                GodinaRodjenja = "1977"
            });
            #endregion

            #region Knjiga

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 1,
                Naziv = "Igre gladi",
                GodinaIzdavanja = "2008",
                InventarniBroj = "000001",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 374,
                Status = true,
                AutorId = 1,
                IzdavacId = 1,
                KategorijaId = 3,
                Opis = "U ne tako dalekoj budućnosti Sjedinjene Američke Države su propale, izmučene sušom, požarima, glađu i ratom. Na njihovu se mjestu iz pepela uzdigao Panem, država podijeljena na vladajući Kapitol i dvanaest okruga. U znak odmazde zbog davnašnjeg ustanka, Kapitol svake godine nasumično odabire dvoje mladih predstavnika iz svakog okruga kako bi sudjelovali na Igrama gladi. Kada malena Prim bude izvučena kao predstavnica rudarskog okruga, njena starija sestra, šesnaestogodišnja Katniss, javit će se dobrovoljno kako bi je zamijenila. Katniss i njezin suborac Peeta, sin pekara čije se borilačke vještine naoko mogu mjeriti s onima štruce kruha, suprotstavit će se predstavnicima drugih okruga, među kojima su i Karijeristi, borci daleko snažniji od njih, koji za taj nastup treniraju cijeli svoj život. Uzbudljiv put mladih nenadanih junaka Suzanne Collins ispričala je u britkoj trilogiji koja broji nastavke: Igre gladi, Lov na vatru i Sjaj slobode.",
                SlikaPutanja = "igregladi.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 2,
                Naziv = "Lov na vatru",
                GodinaIzdavanja = "2009",
                InventarniBroj = "000002",
                BrojKnjigaNaStanju = 8,
                BrojStranica = 391,
                Status = true,
                AutorId = 1,
                IzdavacId = 1,
                KategorijaId = 3,
                Opis = "Lov na vatru je drugi dio trilogije Igre gladi. Roman koji nastavlja da prati život nevjerovatne tinejdžerke Ketnis Evedin. Ona i Pita Melark su, čudesnom igrom slučajeva, preživjele nevjerovatne Igre gladi. Srećna što će ponovo biti sa svojom porodicom i dugogodišnjim prijateljem Gejlom, Ketnis ni ne sluti šta je u stvari čeka. Njena pobjeda je izazvala velike pobune u distriktima protiv surovog Kapitola. Igre gladi poprimaju široke razmjere. Kako umiriti pobunu? Ko će Ketnisi pružiti podršku, a ko će joj okrenuti leđa?",
                SlikaPutanja = "lovnavatru.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 3,
                Naziv = "Derviš i smrt",
                GodinaIzdavanja = "1966",
                InventarniBroj = "000003",
                BrojKnjigaNaStanju = 10,
                BrojStranica = 473,
                Status = true,
                AutorId = 2,
                IzdavacId = 2,
                KategorijaId = 2,
                Opis = "Derviš i smrt je psihološki roman Meše Selimovića pisan u razdoblju od 1962. do 1966. godine i smatra se njegovim najuspješnijim djelom. Glavni lik romana je sredovječni derviš Ahmed Nurudin, upravitelj jednog derviškog samostana u osmanskoj Bosni. Promjene u njegov skroman i miran život unosi vijest da mu je brat uhićen iz političkih razloga. Pokušavajući pomoći bratu sam se suočava s vlašću i društvom pri čemu biva potresen njegov dotadašnji svjetonazor i način života. Osim psihološke problematike, u romanu su izražena i mnoga filozofska pitanja vezana uz ljudski život, društvo i politiku, a također je izložena i analiza društvenog i političkog stanja u Bosni za vrijeme Osmanskog Carstva.",
                SlikaPutanja = "dervisismrt.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 4,
                Naziv = "Tvrđava",
                GodinaIzdavanja = "1970",
                InventarniBroj = "000004",
                BrojKnjigaNaStanju = 6,
                BrojStranica = 316,
                Status = true,
                AutorId = 2,
                IzdavacId = 3,
                KategorijaId = 2,
                Opis = "Glavni junak romana, Ahmet Šabo, želi pronaći most do drugih ljudi, da izađe iz tvrđave, jer zna, razdvaja nas i uništava mržnja, održat će nas samo ljubav, ili makar vjera da je moguće ma kakvo sporazumijevanje među pojedincima i zajednicom. Vođen tom vjerom i željom, on ostaje vedar i moralno čist. Najčešće se o Dervišu i o Tvrđavi govori u paru, gotovo kao da je riječ o dijelovima istog ciklusa, o nastavcima. A ipak, mada je riječ o romanima iz kojih se zrcali slična vizija svijeta, oni se suštinski razlikuju. Tvrđava je, usprkos svemu, vedriji roman: u Dervišu je smrt besmisao kao i život, dok Tvrđava smisao nudi u ljubavi (kraj pretposljednjeg poglavlja Tvrđave kao da je direktna antiteza čuvenom kraju Derviša i smrti: Odlučio sam se za ljubav. Manje je istinito, i manje vjerovatno, ali je plemenitije. I ljepše: tako sve ima više smisla. I smrt. I život.), a životna linija vodilja Ahmeta Šabe jest ono što negdje ističe upravo Meša Selimović: ostati neuprljan u jednom prljavom svijetu.",
                SlikaPutanja = "tvrdjava.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 5,
                Naziv = "Travnička hronika",
                GodinaIzdavanja = "1945",
                InventarniBroj = "000005",
                BrojKnjigaNaStanju = 4,
                BrojStranica = 550,
                Status = true,
                AutorId = 3,
                IzdavacId = 4,
                KategorijaId = 2,
                Opis = "Travnička hronika (1945) je istorijski roman pisan za vrijeme Drugog svetskog rata, ostvaren po modelu evropskog realističkog romana. Obuhvata vrijeme od 1807. do 1814. godine i po tome predstavlja klasičan roman više od bilo kojeg drugog Andrićevog romanesknog ostvarenja. Roman je ispripovijedan u trećem licu i sklopljen je od prologa, epiloga i 28 poglavlja. Razlika između travničke i višegradske hronike jeste u tome što se roman Na Drini ćuprija mahom zasniva na fikcionalnoj nadogradnji usmenih legendi dok je Travnička hronika nastala imaginiranjem vrlo bogate dokumentarne građe. Hronika o Travniku je beletristički sedmogodišnji ljetopis koji obrađuje vrijeme boravka stranih konzula u tom vezirskom gradu. Počinje dolaskom francuskog konzula, a završava se odlaskom drugopostavljenog austrijskog konzula. Prema poetičkom pravilu koje važi za sve Andrićeve romane (izuzimajući donekle Gospođicu) i ovaj roman okrenut je istoriji. U procesu stvaranja Travničke hronike Andrić se služio bogatom dokumentarnom građom iz oblasti istorije civilizacije, etnologije i autentičnu spisima o istorijskim ličnostima koje su predstavljene u romanu. Istorija je utkana tako reći, u svaku rečenicu (do te mjere, ponekad, da bi se mogle staviti, pri dnu stranice referencije izvora), dajući joj na taj način izvjesnu autentičnost i životnost, napisao je Mithad Šamić u studiji Istorijski izvori Travničke hronike.Od svih Andrićevih djela hronika o vezirskom gradu ima najviše likova. Ključni lik djela je francuski konzul Žan Davil, Parižanin tanane prirode, pjesnik po osjećanju svijeta. Ta istorijski verifiikovana ličnost je kao prototip poslužio Andriću za oblikovanje književnog lika u kojem se kao u osetljivom mediju projektuju slike bosanske sredine, običaja i navika bosanskog svijeta.U Travničkoj hronici sudarila su se četiri svijeta, različita po vjeri, kulturi, istoriji, običajima. Emisari zapadnih i istočnih svjetova našli su se na prostoru Bosne sa namjerom da nikada i ne pokušaju da se približe i razumiju. Najbliži saradnici francuskog i austrijskog konzula i vezira i stanovnici tamnog bosanskog vilajeta, Davna, Rota, turski ćehaja, teftedar Baki, kao i travničke kasablije, u neprestanim su međusobnim sukobima i stalno iskazuju mračne ljudske nagone.",
                SlikaPutanja = "travnickahronika.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 6,
                Naziv = "Na Drini ćuprija",
                GodinaIzdavanja = "1945",
                InventarniBroj = "000006",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 318,
                Status = true,
                AutorId = 3,
                IzdavacId = 4,
                KategorijaId = 2,
                Opis = "Roman Na Drini ćuprija u kojem se uglavnom dosljedno hronološki opisuje svakodnevni život višegradske kasabe je, zapravo, višegradska hronika, pandan Travničkoj hronici i Omerpaši Latasu koji je sarajevska hronika: u sklopu toga hronikalnog troknjižja Ivo Andrić pripovjeda o turskim vremenima u Bosni.Roman počinje dugim geografskim opisom višegradskog kraja i navođenjem više legendi o nastanku mosta, od kojih je posebna markantna ona o uziđivanju hrišćanske djece u jedan od stubova. Porijeklo legende je u nacionalnom mitu i epskoj viziji svijeta koja je književni ekvivalent toga mita. Legende su po pravilu paralelne, imaju hrišćansku i muslimansku verziju.Kraj romana pada u 1914. godinu kada su trupe austrougarske monarhije, u povlačenju, ozbiljno oštetile most. Sa rušenjem mosta izdiše i Alihodža, jedan od najčešće pominjanih likova, koji simbolizuje kraj starih vremena. Između početka i kraja romana, između građenja i rušenja mosta, širi se pripovjedački luk dug četiri stotine godine u kojem, u formi vrlo razvijenih epizoda, zapravo, celih priča, Andrić niže sudbine višegradskih ljudi, svih vera",
                SlikaPutanja = "nadrinicuprija.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 7,
                Naziv = "Prokleta avlija",
                GodinaIzdavanja = "1954",
                InventarniBroj = "000007",
                BrojKnjigaNaStanju = 8,
                BrojStranica = 130,
                Status = true,
                AutorId = 3,
                IzdavacId = 4,
                KategorijaId = 2,
                Opis = "Kratki roman Prokleta avlija, čije pisanje je Andrić započeo između dva svjetska rata, a dovršio ga i objavio 1954. godine, smatra se piščevim remek-djelom. Komponovan je narativnim postupkom upričavanja priče (prstenasta, okvirna strktura). Ima više pripovjedača koji jedan od drugoga preuzimaju kazivačku poziciju. Pripovijedanje u ovom romanu može se predstaviti i slikom koncentričnih krugova koji se skupljaju do samog jezgra priče. Kao i svi drugi Andrićevi romani, izuzimajući Gospođicu, i Prokleta avlija okrenuta je istoriji, ali na drukčiji način od višegradske, travničke i sarajevske hronike. Roman je ispripovijedan smirenim, nepristrasnim tonom, kojim se odmjereno i sugestivno teži objektivizaciji, kako je to kod Andrića već običaj i pravilo. Do centralne, istorijske priče iz XI vijeka o tragičnoj sudbini Džem-sultana, Andrić nas dovodi posredno. O Džem-sultanu pripovijeda mladi polu -Turčin Ćamil, koji u njemu vidi svog sudbinskog srodnika i preteču. O Ćamilu pripovijeda prestravljeni Jevrejin Haim, a svi oni su samo uspomena fra Petra na dane provedene u stambolskom zatvoru, prokletoj avliji. A tu uspomenu, opet, grli luk sjećanja bezimenog mladića (pisca?), koji, gledajući u zimski dan na fra-Petrov grob, vraća u sebi cijeli tok priče.Svi protagonisti Proklete avlije, ma koliko različiti, čuvaju u sebi iskustvo sužnja, pa i svijet, makar i nesvjesno, osjećaju kao ograničen, tjeskoban prostor. Kao da je samo postojanje tamnovanje. (Naslov romana simbolički je ključ čitanja.) Uskomješanost zatvora u koji se sliva zli talog imperije koja je prešla svoj vrhunac, ali gdje, igrom slučaja, zalutaju i ljudi koji su samo drukčiji od ostalih, postaje neka vrsta zamjene za svijet on traje u vremenu i ne obazire se na pojedinačne ljudske sudbine koje ga tvore. Svi su sporedni i nevažni zapisuje Andrić. Avlija živi sama za sebe, sa stotinu promjena, i uvijek ista.",
                SlikaPutanja = "prokletaavlija.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 8,
                Naziv = "Gospođica",
                GodinaIzdavanja = "1945",
                InventarniBroj = "000008",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 191,
                Status = true,
                AutorId = 3,
                IzdavacId = 5,
                KategorijaId = 2,
                Opis = "Iako je objavljen iste godine (1945) kad i Na Drini ćuprija i Travnička hronika, roman Gospođica nema karakteristike romana-hronike sastavljenog iz niza odvojenih proznih struktura, bez jasno definisanog glavnog junaka, već je koncipiran kao romaneskna struktura u kojoj središnju ulogu ima jedan lik. Međutim, ni ovde, kao ni u višegradskoj i travničkoj hronici, neće biti pripovedanja u ich-formi, već je reč o prividno neutralnom pripovedačevom glasu u trećem licu, koji se, tokom većeg dijela romana drži tačke gledišta vrlo bliske vizuri glavnog lika - Rajke Radaković. Ovaj pripovedačev glas povremeno se udaljava od središta svesti centralne junakinje, i to uvjek onda kada čitaoca treba uputiti u pojedinosti vezane za sudbine drugih likova koji se u romanu javljaju. Život Rajke Radaković protekao je u znaku jedne strasti - ljubavi prema novcu. Ali, Rajka nije građena kao tip tvrdice, izmedju ostalog i zbog toga što Andrić kao pisac nije bio sklon stvaranju tipova. On, u stvari, uvek naglašava posebnost svake ljudske sudbine, a za Rajku će posebno podvući da je mimo drugih ljudi, kruška divljakuša, kako za nju kaže njena tetka...",
                SlikaPutanja = "gospodjica.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 9,
                Naziv = "Ostrvo",
                GodinaIzdavanja = "1974",
                InventarniBroj = "000009",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 177,
                Status = true,
                AutorId = 2,
                IzdavacId = 3,
                KategorijaId = 2,
                Opis = "Dvoje ljudi na usamljenom ostrvu pokušavaju da povrate smisao koji je bespovratno istekao iz života; da nadoknade godine provedene u ispraznosti i simulakrumu života koji je, sopstvenom rutinom, opustošio samog sebe - to bi bio kratak kroki sadržaj romana Ostrvo.Čovjek i žena pokušavaju da nađu zamjenu za vjeru u život posmatrajući jedno drugo; svako sa svoje strane samotnog ostrva duše izgubljene negdje između dostignutog i nedostingnutog, bića i nebića.",
                SlikaPutanja = "ostrvo.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 10,
                Naziv = "Sjaj slobode",
                GodinaIzdavanja = "2010",
                InventarniBroj = "000010",
                BrojKnjigaNaStanju = 8,
                BrojStranica = 312,
                Status = true,
                AutorId = 1,
                IzdavacId = 1,
                KategorijaId = 3,
                Opis = "Sjaj slobode je posljednji dio trilogije Igre gladi. Nevjerovatan kraj jedne fantastične avanture. Ketnis je preživjela igre gladi po drugi put. Iako je dva puta bila na krvavoj pozornici, Kapitol joj ni sada ne da mira. On je bijesan zbog nemira u Distriktu 12 i smatra da je jedini krivac Ketnis. Međutim, sada nije samo Ketnis u opasnosti već i njena porodica i svi njeni prijatelji… Igrama je došao kraj, a pobjednik je …",
                SlikaPutanja = "sjajslobode.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 11,
                Naziv = "Otpor",
                GodinaIzdavanja = "2000",
                InventarniBroj = "000011",
                BrojKnjigaNaStanju = 4,
                BrojStranica = 118,
                Status = true,
                AutorId = 4,
                IzdavacId = 6,
                KategorijaId = 1,
                Opis = "Otpor je knjiga u kojoj Sabato kao budni posmatrač ljudske egzistencije poziva na pobunu protiv čovekovog duhovnog pada i gubitka međuljudske bliskosti koja dolazi kao posledica uništavanja kulturnih vrednosti na kojima su počivale generacije.Piščeva duboka zabrinutost za čoveka koji, usled gubitka povezanosti sa drugim ljudima i uzdizanjem svog sopstvenog ja, vodi život na granici beznađa, podstiče čitaoca na promišljanja o vlastitiom životu i idealima kojima savremeni čovek teži. Šta za čoveka predstavlja sreća i koliko je spreman da u nju uključi i druge ljude? Da li je uživanje u materijalnom postalo osnovni čovekov ideal i ko je glavni krivac za to? Ovo su samo neka od pitanja koja autor iznosi pred čitaoca u nadi da će podstaći promene koje će čoveka vratiti istinskim humanističkim vrednostima, a spremnost da se otvorimo za drugog čitavim bićem jedan je od preduslova koji su neophodni za čovekovu istinsku sreću.",
                SlikaPutanja = "otpor.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 12,
                Naziv = "O junacima i grobovima",
                GodinaIzdavanja = "2000",
                InventarniBroj = "000012",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 561,
                Status = true,
                AutorId = 4,
                IzdavacId = 6,
                KategorijaId = 1,
                Opis = "Roman je nastao 1961. godine i autoru je doneo svetsku slavu. Sastoji se od četiri dela. U prva dva, Zmaj i princeza i Nevidljiva lica, opisuje se čudna ljubavna vezu između Martina, osetljivog mladića koji ima narušene odnose s roditeljima, i Alejandre, zagonetne devojke čudnog ponašanja, poreklom iz stare, nekada ugledne argentinske porodice. Treći deo, Izveštaj o slepima, opisuje morbidno istraživanje Fernanda Vidala Olmosa, okrutnog paranoika opsednutog slepcima i zlom. Poslednji deo, Nepoznati bog, bavi se Martinom i Brunom nakon tragedije najavljene na početku, njihovim savladavanjem životnih teškoća.U ovakvu, vremenski ispresecanu, radnju upliću se epizode iz argentinske istorije i razvijaju autorove političke, moralne, metafizičke, religijske, estetske ideje i stavovi.ovu istinsku sreću.",
                SlikaPutanja = "junacigrobovi.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 13,
                Naziv = "Abadon, anđeo uništenja",
                GodinaIzdavanja = "2002",
                InventarniBroj = "000013",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 474,
                Status = true,
                AutorId = 4,
                IzdavacId = 6,
                KategorijaId = 1,
                Opis = "Predstaviti ovaj ili ovakav roman čitateljima jest potez i želja koja izmiče uvriježenim pravilima strukture recenzije, kritike, prikaza pa ću svoje nastojanje da ga približim potencijalnim čitateljima nazvati - čitanje romana Abadon, anđeo uništenja .Zašto? Pisati recenziju romana koji je jedan od najkompleksnijih i kompletnijih književnih postignuća, iz pera autora čiji su eseji o književnosti sam vrh filozofskih i poetskih promišljanja, pretenciozan je pothvat pa on u samoj ideji promašuje cilj. Vrednovanje ovoga sveobuhvatnog romana izlišno je. To je vrh književnog stvaralaštva u 20 stoljeću. Ili barem jedan od sjajnih vrhova s kojih imate pogled na dolinu radosti i suza kolektivne povijesti i svijesti.",
                SlikaPutanja = "abadon.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 14,
                Naziv = "Petlja",
                GodinaIzdavanja = "2012",
                InventarniBroj = "000014",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 224,
                Status = true,
                AutorId = 5,
                IzdavacId = 7,
                KategorijaId = 1,
                Opis = "Pripovedana glasom mlade buntovne žene, raspete između poljuljanih vrednosnih stavova i traganja za samoostvarenjem, ova snažna i uzbudljiva priča vodi nas kroz lavirinte skučenih životnih izbora, koja često dovodi do korenitog preispitivanja i preobražaja ličnosti. Nepristajanje da se bude ono što od nas naprave drugi osnovni je motivacioni pokretač postupaka glavne junakinje.Bežeći od sopstvene sudbine, Dina je, usled svoje nakrive naravi i otpora prema konvencijama, posle jednog sukoba sa graničnom policijom završila u grčkom zatvoru. Čekajući da bude prevezena u sud, ona se priseća svih onih prelomnih trenutaka u životu koji su je posredno ili neposredno dovde doveli: odnosa prema roditeljima i nedruželjubivoj stvarnosti, prijateljstva sa Nikodimom, jedinim nepatvorenim prijateljem, sukoba i kompromisa sa Svetislavom, vlasnikom lanca kladionica i moćnim likom iz podzemlja, kome će se surovo osvetiti… Njen lik je psihološki postupno i uverljivo izgrađen do samog katartičnog kraja, a njena istovremeno destruktivna i autodestruktivna priroda ogleda se u odbacivanju oveštalih istina i uvreženih navika.",
                SlikaPutanja = "petlja.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 15,
                Naziv = "Povratak",
                GodinaIzdavanja = "2002",
                InventarniBroj = "000015",
                BrojKnjigaNaStanju = 5,
                BrojStranica = 204,
                Status = true,
                AutorId = 6,
                IzdavacId = 7,
                KategorijaId = 1,
                Opis = "Trevor Benson nikad nije nameravao da se vrati u Nju Bern u Severnoj Karolini. Radio je u Avganistanu kao ortopedski hirurg sve dok jednog dana ispred bolnice nije eksplodirala minobacačka granata. Zadobivši teške povrede, vratio se u domovinu, a trošna, drvena kućica koju je nasledio od dede izgleda mu kao dobro mesto za oporavak, baš kao i bilo koje drugo.U Nju Bernu brine o dedinim voljenim košnicama i priprema se za drugu specijalizaciju na fakultetu. Kada sretne Natali Masterson, zamenika šerifa, neplanirano će se kod njega probuditi osećanja koja ne može da ignoriše. Iako je očigledno da je i on njoj drag, Natali je povremeno neočekivano veoma suzdržana prema njemu. Trevor počinje da se pita šta je uzrok takvom njenom ponašanju.U život mu ulazi još jedna tajnovita osoba, tinejdžerka Kali koja živi u obližnjem kampu za prikolice. Tvrdeći da joj je sedamnaest godina, ona radi u prodavnici mešovite robe i izbegava društvo. Otkrivši da se svojevremeno sprijateljila s njegovim dedom, Trevor se nada da Kali može da rasvetli misteriozne okolnosti pod kojima je njegov deda umro, ali ona nudi skromne nagoveštaje sve dok se ne ispostavi da je Kalina prošlost isprepletena sa starčevom smrću više nego što je Trevor mogao da pretpostavi.U nastojanju da otkrije Nataline i Kaline tajne, Trevor će naučiti šta zaista znače ljubav i opraštanje... i da se u životu, da bismo krenuli dalje, često moram vratiti na mesto gde je sve počelo.",
                SlikaPutanja = "povratak.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 16,
                Naziv = "Svaki dan u godini 1",
                GodinaIzdavanja = "2020",
                InventarniBroj = "000016",
                BrojKnjigaNaStanju = 6,
                BrojStranica = 472,
                Status = true,
                AutorId = 7,
                IzdavacId = 7,
                KategorijaId = 1,
                Opis = "Gezina Krespal, rođena 1933. u gradiću Jerihovu na severu Nemačke, već šestu godinu živi na Menhetnu zaposlena kao prevoditeljka u velikoj banci. Detinjstvo je provela pod nacizmom, mladost u Istočnoj Nemačkoj, iskusila je život u Zapadnoj Nemačkoj i odbacila ga, a u Njujork je stigla s jednim ciljem: da zarađuje dovoljno za podizanje maloletne ćerke Mari. Obeležena svojom prošlošću, mlada Nemica ne može da se prilagodi američkom svetu sa istom lakoćom kao i njena desetogodišnja ćerka. Živost Gezininih utisaka, njeno opsesivno gomilanje informacija iz Njujork tajmsa čine je svedokom američke istorije šezdesetih, obeležene Vijetnamskim ratom, rasnim pitanjem i svakodnevnim nasiljem kojim je preplavljena crna hronika. Paralelno s tim, Gezina pokušava da rekonstruiše svoju traumatičnu prošlost u Nemačkoj između tridesetih i pedesetih.",
                SlikaPutanja = "svakidanugodinii.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 17,
                Naziv = "Svaki dan u godini 2",
                GodinaIzdavanja = "2020",
                InventarniBroj = "000017",
                BrojKnjigaNaStanju = 4,
                BrojStranica = 512,
                Status = true,
                AutorId = 7,
                IzdavacId = 7,
                KategorijaId = 1,
                Opis = "Koliko puta će još nada sebi graditi temelj od samog racionalnog kamena, a iracionalnim zidovima izdvajati prostor u kome se kasnije udobno nastanjuje razočaranje. Zašto nas ponavljanje ne čini vatrostalnim.Nemačka imigrantkinja Gezina Krespal, koja živi u Njujorku sa maloletnom ćerkom Mari, zaposlena je kao prevoditeljka u jednoj međunarodnoj banci. U dnevniku koji započinje 21. avgusta 1967. i završava 20. avgusta 1968. mlada Nemica beleži utiske iz svakodnevnog života u Americi, uključujući i aktuelne političke događaje o kojima se informiše čitajući Njujork tajms. Istovremeno, ona pokušava da rekonstruiše svoju traumatičnu prošlost u nemačkoj pokrajini Maklenburg – Zapadna Pomeranija u vreme nacionalsocijalizma, Drugog svetskog rata, dolaska Sovjeta i Nemačke Demokratske Republike.Tako je sastavljena simfonija 20. veka, u kojoj se spajaju glasovi prošlosti i istorije u nastajanju. U varijaciji tonova i stilova smenjuju se doslovni citati iz Njujork tajmsa, Gezinini dijalozi sa Mari, autentični dokumenti poput spiskova za streljanje, dijalozi u kurzivu sa mrtvima ili odsutnima, Gezinin dnevnik beležen na magnetofonskoj traci...U drugom tomu Jonzonovog romana, horskog dela koje je obeležilo savremenu književnost kao malo koje drugo, izdvaja se nezaboravni solo Gezinine majke nastradale u Kristalnoj noći – tragične figure koja oličava sudbinu cele jedne generacije.",
                SlikaPutanja = "svakidanugodiniii.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 18,
                Naziv = "Zmajeve oči",
                GodinaIzdavanja = "2017",
                InventarniBroj = "000018",
                BrojKnjigaNaStanju = 7,
                BrojStranica = 384,
                Status = true,
                AutorId = 8,
                IzdavacId = 8,
                KategorijaId = 3,
                Opis = "Nekada davno u kraljevstvu po imenu Delajn živeo je jedan kralj koji je imao dva sina. Roland Dobri nije bio ni najbolji ni najgori kralj koji je vladao tom zemljom. Svi koji su ga poznavali i koji su videli njegovo sivo lice i drhtave ruke dok je primao zvanice na dvoru slagali su se u proceni da će novi kralj biti krunisan za najviše pet godina. Razgovarali su o budućem kralju, Rolandovom najstarijem sinu, Piteru.Ali jedan čovek je smišljao, planirao i pripremao nešto drugo: kako da omogući da Rolandov mlađi sin, Tomas, bude krunisan. Taj čovek bio je Fleg, kraljev čarobnjak.Uzbudljiva priča o herojskim avanturama, o zmajevima i prinčevima, o tajanstvenim miševima i ljudima, iz pera majstora pripovedača.",
                SlikaPutanja = "zmajeveoci.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 19,
                Naziv = "Kraj bdenja",
                GodinaIzdavanja = "2017",
                InventarniBroj = "000019",
                BrojKnjigaNaStanju = 3,
                BrojStranica = 334,
                Status = true,
                AutorId = 8,
                IzdavacId = 8,
                KategorijaId = 3,
                Opis = "Spektakularno finale bestseler trilogije koja je započela knjigom Gospodin Mercedes.Bil Hodžiz upravlja agencijom Ko nađe - njegovo, zajedno sa partnerkom Holi Gibni. Nakon što ga bivši partner pozove da mu pomogne, Bil je zaintrigiran tajanstvenim slovom Z ispisanim na mestu zločina.Sličnih slučajeva je sve više, a Hodžiz je zapanjen otkrićem da dokazi ukazuju na Brejdija Hartsfilda, zloglasnog Mercedes Ubicu. To bi trebalo da bude nemoguće, zato što Brejdi trune u bolničkoj sobi, u naizgled nesvesnom stanju.Ali Brejdi Hartsfild poseduje nove smrtonosne moći. Planira da se osveti, i to ne samo Hodžizu i njegovim prijateljima već i čitavom gradu.Sat otkucava na sasvim neočekivan način...",
                SlikaPutanja = "krajbdenja.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 20,
                Naziv = "Srebrni put",
                GodinaIzdavanja = "2012",
                InventarniBroj = "000020",
                BrojKnjigaNaStanju = 6,
                BrojStranica = 334,
                Status = true,
                AutorId = 9,
                IzdavacId = 6,
                KategorijaId = 2,
                Opis = "Pre tri godine, Leleova ćerka nestala je u zabačenom delu severne Švedske. Lele od tada svako leto provodi vozeći se Srebrnim putem, u mahnitoj potrazi za njom. Upada na napuštena seoska imanja i odlazi do najudaljenijih sporednih puteva ne bi li pronašao bilo kakav trag.U selo Glimeštresk, koje se nalazi duž Srebrnog puta, stiže sedamnaestogodišnja Meja sa svojom majkom, nadajući se novom početku. Ona je istih godina kao Leleova ćerka u vreme nestanka.Kada nestane još jedna devojka, životi Lelea i Meje isprepletaće se na tragičan način koji niko od njih nije mogao ni da zamisli.Debitantski roman Stine Džekson potresno je delo velike literarne snage i favorit kritičara od prvog dana. Srebrni put je priča o ljubavi, bolu, neodustajanju i pronalaženju snage da se nastavi dalje. Jer i najmračnije putovanje jednom mora da se završi.",
                SlikaPutanja = "srebreniput.jpg"

            });

            modelBuilder.Entity<Knjiga>().HasData(new Knjiga()
            {
                KnjigaId = 21,
                Naziv = "Pod oba Sunca",
                GodinaIzdavanja = "2020",
                InventarniBroj = "000021",
                BrojKnjigaNaStanju = 3,
                BrojStranica = 160,
                Status = true,
                AutorId = 10,
                IzdavacId = 9,
                KategorijaId = 2,
                Opis = "Na osamljenom svjetioniku nekadašnji kapetan prve klase Branimir Bato Lončar i njegova žena Danica žive jednoličnu svakodnevicu koju katkad uznemire zalutali turist ili barka u opasnosti. Bato je postao svjetioničarem jer se nije želio pridružiti agresiji na Dubrovačko primorje. Danica u nametnutoj osami oplakuje svoju neplodnost. Jednoga ljeta Nevena i Mitar, par u krizi srednjih godina, razapinju šator pred svjetionikom. Zajednička večera promijenit će sve u njihovim životima.Pod oba Sunca, roman ispripovijedan kroz glasove četvero protagonista, priča je o krugu života koji iscrtavamo sami i pokušajima da iz tog kruga iskoračimo. Ognjen Spahić iznova pokazuje svu raskoš pripovjednoga talenta i zavidnu sposobnost da stvori moćne, pamtljive likove duboko obojene lokalnom poviješću. Pod oba Sunca roman je o ljudima u okovima vlastitih odluka kojih se nikako ne mogu osloboditi.",
                SlikaPutanja = "podobasunca.jpg"

            });
            #endregion

            #region Uplata

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 1,
                DatumUplate = new DateTime(2020, 01, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 2,
                DatumUplate = new DateTime(2020, 02, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 3,
                DatumUplate = new DateTime(2020, 03, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 4,
                DatumUplate = new DateTime(2020, 04, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 5,
                DatumUplate = new DateTime(2020, 05, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 6,
                DatumUplate = new DateTime(2020, 06, 01),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 7,
                DatumUplate = new DateTime(2020, 07, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 8,
                DatumUplate = new DateTime(2020, 08, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 9,
                DatumUplate = new DateTime(2020, 09, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 10,
                DatumUplate = new DateTime(2020, 10, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 11,
                DatumUplate = new DateTime(2020, 11, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 12,
                DatumUplate = new DateTime(2020, 12, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 13,
                DatumUplate = new DateTime(2021, 01, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 14,
                DatumUplate = new DateTime(2021, 02, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 15,
                DatumUplate = new DateTime(2021, 03, 02),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 16,
                DatumUplate = new DateTime(2021, 05, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 17,
                DatumUplate = new DateTime(2021, 06, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 1
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 18,
                DatumUplate = new DateTime(2020, 01, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 19,
                DatumUplate = new DateTime(2020, 02, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 20,
                DatumUplate = new DateTime(2020, 03, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 21,
                DatumUplate = new DateTime(2020, 04, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 22,
                DatumUplate = new DateTime(2020, 05, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 23,
                DatumUplate = new DateTime(2020, 06, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 24,
                DatumUplate = new DateTime(2020, 07, 08),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 25,
                DatumUplate = new DateTime(2020, 08, 08),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 26,
                DatumUplate = new DateTime(2020, 09, 08),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 27,
                DatumUplate = new DateTime(2020, 10, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 28,
                DatumUplate = new DateTime(2020, 11, 08),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 29,
                DatumUplate = new DateTime(2020, 12, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 30,
                DatumUplate = new DateTime(2021, 01, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 31,
                DatumUplate = new DateTime(2021, 02, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 32,
                DatumUplate = new DateTime(2021, 03, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 33,
                DatumUplate = new DateTime(2021, 04, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 34,
                DatumUplate = new DateTime(2021, 05, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 35,
                DatumUplate = new DateTime(2021, 06, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 2
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 36,
                DatumUplate = new DateTime(2020, 05, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 37,
                DatumUplate = new DateTime(2020, 06, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 38,
                DatumUplate = new DateTime(2020, 07, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 39,
                DatumUplate = new DateTime(2020, 08, 11),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 40,
                DatumUplate = new DateTime(2020, 09, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 41,
                DatumUplate = new DateTime(2020, 10, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 42,
                DatumUplate = new DateTime(2020, 11, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 43,
                DatumUplate = new DateTime(2020, 12, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 44,
                DatumUplate = new DateTime(2021, 01, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 45,
                DatumUplate = new DateTime(2021, 02, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 46,
                DatumUplate = new DateTime(2021, 03, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 47,
                DatumUplate = new DateTime(2021, 04, 10),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 48,
                DatumUplate = new DateTime(2020, 05, 09),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 49,
                DatumUplate = new DateTime(2021, 06, 08),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 3
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 50,
                DatumUplate = new DateTime(2020, 10, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 51,
                DatumUplate = new DateTime(2020, 11, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 52,
                DatumUplate = new DateTime(2020, 12, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 53,
                DatumUplate = new DateTime(2021, 01, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 54,
                DatumUplate = new DateTime(2021, 02, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 55,
                DatumUplate = new DateTime(2021, 03, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 56,
                DatumUplate = new DateTime(2021, 04, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 57,
                DatumUplate = new DateTime(2021, 05, 05),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 58,
                DatumUplate = new DateTime(2021, 06, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 4
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 59,
                DatumUplate = new DateTime(2020, 10, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 5
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 60,
                DatumUplate = new DateTime(2020, 11, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 5
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 61,
                DatumUplate = new DateTime(2020, 12, 04),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 5
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 62,
                DatumUplate = new DateTime(2020, 12, 07),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 6
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 63,
                DatumUplate = new DateTime(2021, 01, 07),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 6
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 64,
                DatumUplate = new DateTime(2021, 02, 07),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 6
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 65,
                DatumUplate = new DateTime(2021, 05, 07),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 7
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 66,
                DatumUplate = new DateTime(2021, 06, 06),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 7
            });

            modelBuilder.Entity<Uplata>().HasData(new Uplata()
            {
                UplataId = 67,
                DatumUplate = new DateTime(2021, 06, 03),
                IznosUplate = new decimal(25.00),
                VrstaUplateId = 1,
                ClanId = 8
            });
            #endregion

            #region Zaduzenje

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 1,
                KnjigaId = 1,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 01, 12),
                DatumVracanja = new DateTime(2020, 01, 28),
                ClanId=1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 2,
                KnjigaId = 4,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 01, 16),
                DatumVracanja = new DateTime(2020, 02, 02),
                ClanId = 1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 3,
                KnjigaId = 10,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 04, 01),
                DatumVracanja = new DateTime(2020, 04, 15),
                ClanId = 1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 4,
                KnjigaId = 12,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 06, 10),
                DatumVracanja = new DateTime(2020, 07, 15),
                ClanId = 1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 5,
                KnjigaId = 18,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 12, 10),
                DatumVracanja = new DateTime(2020, 12, 25),
                ClanId = 1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 6,
                KnjigaId = 13,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 05, 10),
                DatumVracanja = new DateTime(2020, 05, 25),
                ClanId = 2
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 7,
                KnjigaId = 3,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 08, 08),
                DatumVracanja = new DateTime(2020, 08, 21),
                ClanId = 2
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 8,
                KnjigaId = 4,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 11, 03),
                DatumVracanja = new DateTime(2020, 11, 21),
                ClanId = 2
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 9,
                KnjigaId = 9,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 01, 06),
                DatumVracanja = new DateTime(2021, 01, 19),
                ClanId = 3
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 10,
                KnjigaId = 7,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 01, 16),
                DatumVracanja = new DateTime(2021, 01, 30),
                ClanId = 3
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 11,
                KnjigaId = 19,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 01, 03),
                DatumVracanja = new DateTime(2021, 01, 30),
                ClanId = 4
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 12,
                KnjigaId = 5,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 02, 01),
                DatumVracanja = new DateTime(2021, 02, 13),
                ClanId = 4
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 13,
                KnjigaId = 17,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 12, 14),
                DatumVracanja = new DateTime(2020, 12, 21),
                ClanId = 5
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 14,
                KnjigaId = 4,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 02, 11),
                DatumVracanja = new DateTime(2021, 02, 21),
                ClanId = 5
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 15,
                KnjigaId = 12,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 03, 17),
                DatumVracanja = new DateTime(2021, 04, 02),
                ClanId = 5
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 16,
                KnjigaId = 16,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 02, 17),
                DatumVracanja = new DateTime(2021, 03, 02),
                ClanId = 6
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 17,
                KnjigaId = 11,
                Status = false,
                DatumZaduzenja = new DateTime(2021, 03, 28),
                DatumVracanja = new DateTime(2021, 04, 12),
                ClanId = 6
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 18,
                KnjigaId = 14,
                Status = false,
                DatumZaduzenja = new DateTime(2020, 12, 28),
                DatumVracanja = new DateTime(2021, 01, 12),
                ClanId = 6
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 20,
                KnjigaId = 20,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 05, 05),
                DatumVracanja = null,
                ClanId = 1
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 21,
                KnjigaId = 7,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 04, 25),
                DatumVracanja = null,
                ClanId = 2
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 22,
                KnjigaId = 2,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 04, 29),
                DatumVracanja = null,
                ClanId = 2
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 23,
                KnjigaId = 11,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 04, 20),
                DatumVracanja = null,
                ClanId = 3
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 24,
                KnjigaId = 15,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 05, 20),
                DatumVracanja = null,
                ClanId = 7
            });

            modelBuilder.Entity<Zaduzenje>().HasData(new Zaduzenje()
            {
                ZaduzenjeId = 25,
                KnjigaId = 6,
                Status = true,
                DatumZaduzenja = new DateTime(2021, 05, 29),
                DatumVracanja = null,
                ClanId = 7
            });
            #endregion

            #region Rezervacija

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 1,
                KnjigaId = 1,
                Status = false,
                DatumRezervacije = new DateTime(2020, 01, 11),
                ClanId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 2,
                KnjigaId = 4,
                Status = false,
                DatumRezervacije = new DateTime(2020, 01, 15),
                ClanId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 3,
                KnjigaId = 10,
                Status = false,
                DatumRezervacije = new DateTime(2020, 06, 09),
                ClanId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 4,
                KnjigaId = 3,
                Status = false,
                DatumRezervacije = new DateTime(2020, 08, 07),
                ClanId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 5,
                KnjigaId = 4,
                Status = false,
                DatumRezervacije = new DateTime(2020, 11, 03),
                ClanId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 6,
                KnjigaId = 9,
                Status = false,
                DatumRezervacije = new DateTime(2021, 01, 05),
                ClanId = 3
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 7,
                KnjigaId = 7,
                Status = false,
                DatumRezervacije = new DateTime(2021, 01, 15),
                ClanId = 3
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 8,
                KnjigaId = 19,
                Status = false,
                DatumRezervacije = new DateTime(2021, 01, 02),
                ClanId = 4
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 9,
                KnjigaId = 5,
                Status = false,
                DatumRezervacije = new DateTime(2021, 02, 01),
                ClanId = 4
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 10,
                KnjigaId = 17,
                Status = false,
                DatumRezervacije = new DateTime(2020, 12, 13),
                ClanId = 5
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 11,
                KnjigaId = 14,
                Status = false,
                DatumRezervacije = new DateTime(2020, 12, 28),
                ClanId = 6
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 12,
                KnjigaId = 14,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 09),
                ClanId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 13,
                KnjigaId = 20,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 07),
                ClanId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 14,
                KnjigaId = 2,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 07),
                ClanId = 3
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 15,
                KnjigaId = 13,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 05),
                ClanId = 4
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 16,
                KnjigaId = 8,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 05),
                ClanId = 4
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 17,
                KnjigaId = 15,
                Status = false,
                DatumRezervacije = new DateTime(2021, 05, 19),
                ClanId = 7
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 18,
                KnjigaId = 13,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 05),
                ClanId = 8
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 19,
                KnjigaId = 2,
                Status = true,
                DatumRezervacije = new DateTime(2021, 06, 07),
                ClanId = 8
            });
            #endregion
        }
    }
}
