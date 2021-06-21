using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eBiblioteka.WebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    ImePrezime = table.Column<string>(nullable: true),
                    GodinaRodjenja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradId);
                });

            migrationBuilder.CreateTable(
                name: "Izdavac",
                columns: table => new
                {
                    IzdavacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    KontaktEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavac", x => x.IzdavacId);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaId);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    KorisnickiNalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    SlikaPutanja = table.Column<string>(nullable: true),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    LozinkaHash = table.Column<string>(nullable: true),
                    LozinkaSalt = table.Column<string>(nullable: true),
                    DatumIzmjene = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.KorisnickiNalogId);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaUplate",
                columns: table => new
                {
                    VrstaUplateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaUplate", x => x.VrstaUplateId);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    KnjigaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    GodinaIzdavanja = table.Column<string>(nullable: true),
                    InventarniBroj = table.Column<string>(nullable: true),
                    BrojStranica = table.Column<int>(nullable: false),
                    BrojKnjigaNaStanju = table.Column<int>(nullable: false),
                    SlikaPutanja = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    AutorId = table.Column<int>(nullable: false),
                    IzdavacId = table.Column<int>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.KnjigaId);
                    table.ForeignKey(
                        name: "FK_Knjiga_Autor",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knjiga_Izdavac",
                        column: x => x.IzdavacId,
                        principalTable: "Izdavac",
                        principalColumn: "IzdavacId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knjiga_Kategorija",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    ClanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUclanjenja = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    GradId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.ClanId);
                    table.ForeignKey(
                        name: "FK_Clan_Grad",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clan_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    GradId = table.Column<int>(nullable: false),
                    KorisnickiNalogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikId);
                    table.ForeignKey(
                        name: "FK_Uposlenik_Grad",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uposlenik_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    ClanId = table.Column<int>(nullable: false),
                    KnjigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Clan",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Knjiga",
                        column: x => x.KnjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "KnjigaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    IznosUplate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VrstaUplateId = table.Column<int>(nullable: false),
                    ClanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataId);
                    table.ForeignKey(
                        name: "FK_Uplata_Clan",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uplata_VrstaUplate",
                        column: x => x.VrstaUplateId,
                        principalTable: "VrstaUplate",
                        principalColumn: "VrstaUplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaduzenje",
                columns: table => new
                {
                    ZaduzenjeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumZaduzenja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: true, defaultValue: true),
                    ClanId = table.Column<int>(nullable: false),
                    KnjigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaduzenje", x => x.ZaduzenjeId);
                    table.ForeignKey(
                        name: "FK_Zaduzenja_Clan",
                        column: x => x.ClanId,
                        principalTable: "Clan",
                        principalColumn: "ClanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zaduzenje_Knjiga",
                        column: x => x.KnjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "KnjigaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UposlenikUloga",
                columns: table => new
                {
                    UposlenikUlogaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(nullable: false),
                    UlogaId = table.Column<int>(nullable: false),
                    DatumIzmjene = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikUloga", x => x.UposlenikUlogaId);
                    table.ForeignKey(
                        name: "FK_UposlenikUloga_Uloga_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UposlenikUloga_Uposlenik_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AutorId", "GodinaRodjenja", "Ime", "ImePrezime", "Prezime" },
                values: new object[,]
                {
                    { 1, "1962", "Suzanne", "Suzanne Collins", "Collins" },
                    { 10, "1977", "Ognjen", "Ognjen Spahić", "Spahić" },
                    { 8, "1947", "Stephen", "Stephen King", "King" },
                    { 7, "1934", "Uve", "Uve Jonzon", "Jonzon" },
                    { 6, "1965", "Nikolas", "Nikolas Sparks", "Sparks" },
                    { 9, "1947", "Stina", "Stina Džekson", "Džekson" },
                    { 4, "1911", "Ernesto", "Ernesto Sabato", "Sabato" },
                    { 3, "1892", "Ivo", "Ivo Andrić", "Andrić" },
                    { 2, "1910", "Meša", "Meša Selimović", "Selimović" },
                    { 5, "1972", "Dejan", "Dejan Aleksić", "Aleksić" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mostar" },
                    { 2, "Sarajevo" },
                    { 3, "Bugojno" },
                    { 4, "Tuzla" }
                });

            migrationBuilder.InsertData(
                table: "Izdavac",
                columns: new[] { "IzdavacId", "KontaktEmail", "Naziv" },
                values: new object[,]
                {
                    { 6, "plato@plato.com", "Plato" },
                    { 8, "kontakt@vulkan.com", "Vulkan" },
                    { 7, "laguna@laguna.com", "Laguna" },
                    { 5, "kontakt@sezambook.com", "Sezam book" },
                    { 9, "fraktura@fraktura.com", "Fraktura" },
                    { 3, "kontakt@connectum.com", "Connectum" },
                    { 2, "contact@nup.com", "Northwestern University Press" },
                    { 1, "contact@scholasticpress.com", "Scholastic Press" },
                    { 4, "kontakt@dereta.com", "Dereta" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "KategorijaId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Roman" },
                    { 3, "Fantazija" }
                });

            migrationBuilder.InsertData(
                table: "KorisnickiNalog",
                columns: new[] { "KorisnickiNalogId", "Adresa", "DatumIzmjene", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "SlikaPutanja", "Status", "Telefon" },
                values: new object[,]
                {
                    { 15, "Adresa BB", new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan6@clan6.com", "Clan6", "clan6", "WFxwSBWY7URkLwvSz+8sJHvWPKE=", "szxpFqQdWkM6G50ZTiBKyw==", "Korisnik6", "clanavatar.png", true, "061-223-122" },
                    { 14, "Adresa BB", new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan5@clan5.com", "Clan5", "clan5", "RSqC/dKdUf1UwK1QA3e4GLsvcCI=", "S10EgH+2uSrcy5x7XoFL1A==", "Korisnik5", "clanavatar.png", true, "061-923-922" },
                    { 13, "Adresa BB", new DateTime(2021, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan4@clan4.com", "Clan4", "clan4", "cwsOw0+QAAJ1H8mFS8D+WDSpxnE=", "9DtBqF/dbUE+pEI3WlaKzg==", "Korisnik4", "clanavatar.png", false, "061-923-922" },
                    { 12, "Adresa BB", new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan3@clan3.com", "Clan3", "clan3", "FZQorMBRD17wfsDzi7+lgmdUOT4=", "NE7m6/0/5hday1+ybcNcPw==", "Korisnik3", "clanavatar.png", false, "061-923-922" },
                    { 11, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan2@clan2.com", "Clan2", "clan2", "c98b09cU4lIIizDHRxMPo1YDNIo=", "PdXvp61EdNHq1rARRiaw1Q==", "Korisnik2", "clanavatar.png", true, "061-123-966" },
                    { 10, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan1@clan1.com", "Clan1", "clan1", "S0BJQsXIq58DiJWf2uKhStgixdw=", "pPl3dmzt1MzB4Q0iWQQgMw==", "Korisnik1", "clanavatar.png", true, "061-123-966" },
                    { 9, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "clan@clan.com", "Clan", "clan", "TtR7Z5pyRfvW9JCb9wgkz2ZvL+8=", "HaUQcGcjeG7uC5LPVpLs3A==", "Korisnik", "clanavatar.png", true, "063-223-666" },
                    { 6, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik4@uposlenik4.com", "Uposlenik4", "uposlenik4", "HgM3p5EOK2Y15guqwmesRJ9T5so=", "O4+Hi4laLWd4vpArIDkynw==", "Korisnik4", "uposlenikavatar.png", false, "063-423-444" },
                    { 7, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik5@uposlenik5.com", "Uposlenik5", "uposlenik5", "um8N75b+RoLvaw98Aiv0sJ+4IpI=", "kIAvl+vZM64txHLXpNv9OA==", "Korisnik5", "uposlenikavatar.png", false, "062-223-666" },
                    { 5, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik3@uposlenik3.com", "Uposlenik3", "uposlenik3", "ypFVYMoh+N0sUk2V/DjOImrAn5o=", "Zf1EXq8LzHRViTV2ag1dwg==", "Korisnik3", "uposlenikavatar.png", true, "063-123-323" },
                    { 4, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik2@uposlenik2.com", "Uposlenik2", "uposlenik2", "DZSvF4nhEOS0jcbxKsrMWlyV3I0=", "UhD4/ldQ7BAh4urwT93CqQ==", "Korisnik2", "uposlenikavatar.png", true, "062-333-333" },
                    { 3, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik1@uposlenik1.com", "Uposlenik1", "uposlenik1", "t/TnyjfVMGPn6uUDP0BivDhUZxs=", "uc02/kEdEYs29rpQ4NPK8Q==", "Korisnik1", "uposlenikavatar.png", true, "061-111-4444" },
                    { 2, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "uposlenik@uposlenik.com", "Uposlenik", "uposlenik", "PMkgOjHc4T75FMEHJehP36ZPOGM=", "H2eScCiIW3TJiTQr0+UHhw==", "Korisnik", "uposlenikavatar.png", true, "061-111-333" },
                    { 1, "Adresa BB", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop@desktop.com", "Desktop", "desktop", "gxUT7N7Wby+cU235GtQvkbxM9E8=", "h02FztAHXRewxJyZ2aoLLA==", "Korisnik", "uposlenikavatar.png", true, "061-222-333" },
                    { 8, "Adresa BB", new DateTime(2021, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile@mobile.com", "Mobile", "mobile", "9j1UFAKCo0rDHL4u5HgKFZtzACo=", "1xsr6lhVRmvR2eN/83C7wQ==", "Korisnik", "mojaslika.jpg", true, "062-223-666" }
                });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaId", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Administrator", null },
                    { 2, "Uposlenik", null }
                });

            migrationBuilder.InsertData(
                table: "VrstaUplate",
                columns: new[] { "VrstaUplateId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Mjesečna uplata" },
                    { 2, "Godišnja uplata" }
                });

            migrationBuilder.InsertData(
                table: "Clan",
                columns: new[] { "ClanId", "DatumUclanjenja", "GradId", "KorisnickiNalogId", "Status" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15, true },
                    { 6, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13, false },
                    { 5, new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12, false },
                    { 4, new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11, true },
                    { 3, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, true },
                    { 2, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9, true },
                    { 1, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8, true },
                    { 7, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14, true }
                });

            migrationBuilder.InsertData(
                table: "Knjiga",
                columns: new[] { "KnjigaId", "AutorId", "BrojKnjigaNaStanju", "BrojStranica", "GodinaIzdavanja", "InventarniBroj", "IzdavacId", "KategorijaId", "Naziv", "Opis", "SlikaPutanja", "Status" },
                values: new object[,]
                {
                    { 19, 8, 3, 334, "2017", "000019", 8, 3, "Kraj bdenja", "Spektakularno finale bestseler trilogije koja je započela knjigom Gospodin Mercedes.Bil Hodžiz upravlja agencijom Ko nađe - njegovo, zajedno sa partnerkom Holi Gibni. Nakon što ga bivši partner pozove da mu pomogne, Bil je zaintrigiran tajanstvenim slovom Z ispisanim na mestu zločina.Sličnih slučajeva je sve više, a Hodžiz je zapanjen otkrićem da dokazi ukazuju na Brejdija Hartsfilda, zloglasnog Mercedes Ubicu. To bi trebalo da bude nemoguće, zato što Brejdi trune u bolničkoj sobi, u naizgled nesvesnom stanju.Ali Brejdi Hartsfild poseduje nove smrtonosne moći. Planira da se osveti, i to ne samo Hodžizu i njegovim prijateljima već i čitavom gradu.Sat otkucava na sasvim neočekivan način...", "krajbdenja.jpg", true },
                    { 18, 8, 7, 384, "2017", "000018", 8, 3, "Zmajeve oči", "Nekada davno u kraljevstvu po imenu Delajn živeo je jedan kralj koji je imao dva sina. Roland Dobri nije bio ni najbolji ni najgori kralj koji je vladao tom zemljom. Svi koji su ga poznavali i koji su videli njegovo sivo lice i drhtave ruke dok je primao zvanice na dvoru slagali su se u proceni da će novi kralj biti krunisan za najviše pet godina. Razgovarali su o budućem kralju, Rolandovom najstarijem sinu, Piteru.Ali jedan čovek je smišljao, planirao i pripremao nešto drugo: kako da omogući da Rolandov mlađi sin, Tomas, bude krunisan. Taj čovek bio je Fleg, kraljev čarobnjak.Uzbudljiva priča o herojskim avanturama, o zmajevima i prinčevima, o tajanstvenim miševima i ljudima, iz pera majstora pripovedača.", "zmajeveoci.jpg", true },
                    { 10, 1, 8, 312, "2010", "000010", 1, 3, "Sjaj slobode", "Sjaj slobode je posljednji dio trilogije Igre gladi. Nevjerovatan kraj jedne fantastične avanture. Ketnis je preživjela igre gladi po drugi put. Iako je dva puta bila na krvavoj pozornici, Kapitol joj ni sada ne da mira. On je bijesan zbog nemira u Distriktu 12 i smatra da je jedini krivac Ketnis. Međutim, sada nije samo Ketnis u opasnosti već i njena porodica i svi njeni prijatelji… Igrama je došao kraj, a pobjednik je …", "sjajslobode.jpg", true },
                    { 1, 1, 5, 374, "2008", "000001", 1, 3, "Igre gladi", "U ne tako dalekoj budućnosti Sjedinjene Američke Države su propale, izmučene sušom, požarima, glađu i ratom. Na njihovu se mjestu iz pepela uzdigao Panem, država podijeljena na vladajući Kapitol i dvanaest okruga. U znak odmazde zbog davnašnjeg ustanka, Kapitol svake godine nasumično odabire dvoje mladih predstavnika iz svakog okruga kako bi sudjelovali na Igrama gladi. Kada malena Prim bude izvučena kao predstavnica rudarskog okruga, njena starija sestra, šesnaestogodišnja Katniss, javit će se dobrovoljno kako bi je zamijenila. Katniss i njezin suborac Peeta, sin pekara čije se borilačke vještine naoko mogu mjeriti s onima štruce kruha, suprotstavit će se predstavnicima drugih okruga, među kojima su i Karijeristi, borci daleko snažniji od njih, koji za taj nastup treniraju cijeli svoj život. Uzbudljiv put mladih nenadanih junaka Suzanne Collins ispričala je u britkoj trilogiji koja broji nastavke: Igre gladi, Lov na vatru i Sjaj slobode.", "igregladi.jpg", true },
                    { 21, 10, 3, 160, "2020", "000021", 9, 2, "Pod oba Sunca", "Na osamljenom svjetioniku nekadašnji kapetan prve klase Branimir Bato Lončar i njegova žena Danica žive jednoličnu svakodnevicu koju katkad uznemire zalutali turist ili barka u opasnosti. Bato je postao svjetioničarem jer se nije želio pridružiti agresiji na Dubrovačko primorje. Danica u nametnutoj osami oplakuje svoju neplodnost. Jednoga ljeta Nevena i Mitar, par u krizi srednjih godina, razapinju šator pred svjetionikom. Zajednička večera promijenit će sve u njihovim životima.Pod oba Sunca, roman ispripovijedan kroz glasove četvero protagonista, priča je o krugu života koji iscrtavamo sami i pokušajima da iz tog kruga iskoračimo. Ognjen Spahić iznova pokazuje svu raskoš pripovjednoga talenta i zavidnu sposobnost da stvori moćne, pamtljive likove duboko obojene lokalnom poviješću. Pod oba Sunca roman je o ljudima u okovima vlastitih odluka kojih se nikako ne mogu osloboditi.", "podobasunca.jpg", true },
                    { 20, 9, 6, 334, "2012", "000020", 6, 2, "Srebrni put", "Pre tri godine, Leleova ćerka nestala je u zabačenom delu severne Švedske. Lele od tada svako leto provodi vozeći se Srebrnim putem, u mahnitoj potrazi za njom. Upada na napuštena seoska imanja i odlazi do najudaljenijih sporednih puteva ne bi li pronašao bilo kakav trag.U selo Glimeštresk, koje se nalazi duž Srebrnog puta, stiže sedamnaestogodišnja Meja sa svojom majkom, nadajući se novom početku. Ona je istih godina kao Leleova ćerka u vreme nestanka.Kada nestane još jedna devojka, životi Lelea i Meje isprepletaće se na tragičan način koji niko od njih nije mogao ni da zamisli.Debitantski roman Stine Džekson potresno je delo velike literarne snage i favorit kritičara od prvog dana. Srebrni put je priča o ljubavi, bolu, neodustajanju i pronalaženju snage da se nastavi dalje. Jer i najmračnije putovanje jednom mora da se završi.", "srebreniput.jpg", true },
                    { 2, 1, 8, 391, "2009", "000002", 1, 3, "Lov na vatru", "Lov na vatru je drugi dio trilogije Igre gladi. Roman koji nastavlja da prati život nevjerovatne tinejdžerke Ketnis Evedin. Ona i Pita Melark su, čudesnom igrom slučajeva, preživjele nevjerovatne Igre gladi. Srećna što će ponovo biti sa svojom porodicom i dugogodišnjim prijateljem Gejlom, Ketnis ni ne sluti šta je u stvari čeka. Njena pobjeda je izazvala velike pobune u distriktima protiv surovog Kapitola. Igre gladi poprimaju široke razmjere. Kako umiriti pobunu? Ko će Ketnisi pružiti podršku, a ko će joj okrenuti leđa?", "lovnavatru.jpg", true },
                    { 8, 3, 5, 191, "1945", "000008", 5, 2, "Gospođica", "Iako je objavljen iste godine (1945) kad i Na Drini ćuprija i Travnička hronika, roman Gospođica nema karakteristike romana-hronike sastavljenog iz niza odvojenih proznih struktura, bez jasno definisanog glavnog junaka, već je koncipiran kao romaneskna struktura u kojoj središnju ulogu ima jedan lik. Međutim, ni ovde, kao ni u višegradskoj i travničkoj hronici, neće biti pripovedanja u ich-formi, već je reč o prividno neutralnom pripovedačevom glasu u trećem licu, koji se, tokom većeg dijela romana drži tačke gledišta vrlo bliske vizuri glavnog lika - Rajke Radaković. Ovaj pripovedačev glas povremeno se udaljava od središta svesti centralne junakinje, i to uvjek onda kada čitaoca treba uputiti u pojedinosti vezane za sudbine drugih likova koji se u romanu javljaju. Život Rajke Radaković protekao je u znaku jedne strasti - ljubavi prema novcu. Ali, Rajka nije građena kao tip tvrdice, izmedju ostalog i zbog toga što Andrić kao pisac nije bio sklon stvaranju tipova. On, u stvari, uvek naglašava posebnost svake ljudske sudbine, a za Rajku će posebno podvući da je mimo drugih ljudi, kruška divljakuša, kako za nju kaže njena tetka...", "gospodjica.jpg", true },
                    { 12, 4, 5, 561, "2000", "000012", 6, 1, "O junacima i grobovima", "Roman je nastao 1961. godine i autoru je doneo svetsku slavu. Sastoji se od četiri dela. U prva dva, Zmaj i princeza i Nevidljiva lica, opisuje se čudna ljubavna vezu između Martina, osetljivog mladića koji ima narušene odnose s roditeljima, i Alejandre, zagonetne devojke čudnog ponašanja, poreklom iz stare, nekada ugledne argentinske porodice. Treći deo, Izveštaj o slepima, opisuje morbidno istraživanje Fernanda Vidala Olmosa, okrutnog paranoika opsednutog slepcima i zlom. Poslednji deo, Nepoznati bog, bavi se Martinom i Brunom nakon tragedije najavljene na početku, njihovim savladavanjem životnih teškoća.U ovakvu, vremenski ispresecanu, radnju upliću se epizode iz argentinske istorije i razvijaju autorove političke, moralne, metafizičke, religijske, estetske ideje i stavovi.ovu istinsku sreću.", "junacigrobovi.jpg", true },
                    { 13, 4, 5, 474, "2002", "000013", 6, 1, "Abadon, anđeo uništenja", "Predstaviti ovaj ili ovakav roman čitateljima jest potez i želja koja izmiče uvriježenim pravilima strukture recenzije, kritike, prikaza pa ću svoje nastojanje da ga približim potencijalnim čitateljima nazvati - čitanje romana Abadon, anđeo uništenja .Zašto? Pisati recenziju romana koji je jedan od najkompleksnijih i kompletnijih književnih postignuća, iz pera autora čiji su eseji o književnosti sam vrh filozofskih i poetskih promišljanja, pretenciozan je pothvat pa on u samoj ideji promašuje cilj. Vrednovanje ovoga sveobuhvatnog romana izlišno je. To je vrh književnog stvaralaštva u 20 stoljeću. Ili barem jedan od sjajnih vrhova s kojih imate pogled na dolinu radosti i suza kolektivne povijesti i svijesti.", "abadon.jpg", true },
                    { 14, 5, 5, 224, "2012", "000014", 7, 1, "Petlja", "Pripovedana glasom mlade buntovne žene, raspete između poljuljanih vrednosnih stavova i traganja za samoostvarenjem, ova snažna i uzbudljiva priča vodi nas kroz lavirinte skučenih životnih izbora, koja često dovodi do korenitog preispitivanja i preobražaja ličnosti. Nepristajanje da se bude ono što od nas naprave drugi osnovni je motivacioni pokretač postupaka glavne junakinje.Bežeći od sopstvene sudbine, Dina je, usled svoje nakrive naravi i otpora prema konvencijama, posle jednog sukoba sa graničnom policijom završila u grčkom zatvoru. Čekajući da bude prevezena u sud, ona se priseća svih onih prelomnih trenutaka u životu koji su je posredno ili neposredno dovde doveli: odnosa prema roditeljima i nedruželjubivoj stvarnosti, prijateljstva sa Nikodimom, jedinim nepatvorenim prijateljem, sukoba i kompromisa sa Svetislavom, vlasnikom lanca kladionica i moćnim likom iz podzemlja, kome će se surovo osvetiti… Njen lik je psihološki postupno i uverljivo izgrađen do samog katartičnog kraja, a njena istovremeno destruktivna i autodestruktivna priroda ogleda se u odbacivanju oveštalih istina i uvreženih navika.", "petlja.jpg", true },
                    { 15, 6, 5, 204, "2002", "000015", 7, 1, "Povratak", "Trevor Benson nikad nije nameravao da se vrati u Nju Bern u Severnoj Karolini. Radio je u Avganistanu kao ortopedski hirurg sve dok jednog dana ispred bolnice nije eksplodirala minobacačka granata. Zadobivši teške povrede, vratio se u domovinu, a trošna, drvena kućica koju je nasledio od dede izgleda mu kao dobro mesto za oporavak, baš kao i bilo koje drugo.U Nju Bernu brine o dedinim voljenim košnicama i priprema se za drugu specijalizaciju na fakultetu. Kada sretne Natali Masterson, zamenika šerifa, neplanirano će se kod njega probuditi osećanja koja ne može da ignoriše. Iako je očigledno da je i on njoj drag, Natali je povremeno neočekivano veoma suzdržana prema njemu. Trevor počinje da se pita šta je uzrok takvom njenom ponašanju.U život mu ulazi još jedna tajnovita osoba, tinejdžerka Kali koja živi u obližnjem kampu za prikolice. Tvrdeći da joj je sedamnaest godina, ona radi u prodavnici mešovite robe i izbegava društvo. Otkrivši da se svojevremeno sprijateljila s njegovim dedom, Trevor se nada da Kali može da rasvetli misteriozne okolnosti pod kojima je njegov deda umro, ali ona nudi skromne nagoveštaje sve dok se ne ispostavi da je Kalina prošlost isprepletena sa starčevom smrću više nego što je Trevor mogao da pretpostavi.U nastojanju da otkrije Nataline i Kaline tajne, Trevor će naučiti šta zaista znače ljubav i opraštanje... i da se u životu, da bismo krenuli dalje, često moram vratiti na mesto gde je sve počelo.", "povratak.jpg", true },
                    { 16, 7, 6, 472, "2020", "000016", 7, 1, "Svaki dan u godini 1", "Gezina Krespal, rođena 1933. u gradiću Jerihovu na severu Nemačke, već šestu godinu živi na Menhetnu zaposlena kao prevoditeljka u velikoj banci. Detinjstvo je provela pod nacizmom, mladost u Istočnoj Nemačkoj, iskusila je život u Zapadnoj Nemačkoj i odbacila ga, a u Njujork je stigla s jednim ciljem: da zarađuje dovoljno za podizanje maloletne ćerke Mari. Obeležena svojom prošlošću, mlada Nemica ne može da se prilagodi američkom svetu sa istom lakoćom kao i njena desetogodišnja ćerka. Živost Gezininih utisaka, njeno opsesivno gomilanje informacija iz Njujork tajmsa čine je svedokom američke istorije šezdesetih, obeležene Vijetnamskim ratom, rasnim pitanjem i svakodnevnim nasiljem kojim je preplavljena crna hronika. Paralelno s tim, Gezina pokušava da rekonstruiše svoju traumatičnu prošlost u Nemačkoj između tridesetih i pedesetih.", "svakidanugodinii.jpg", true },
                    { 17, 7, 4, 512, "2020", "000017", 7, 1, "Svaki dan u godini 2", "Koliko puta će još nada sebi graditi temelj od samog racionalnog kamena, a iracionalnim zidovima izdvajati prostor u kome se kasnije udobno nastanjuje razočaranje. Zašto nas ponavljanje ne čini vatrostalnim.Nemačka imigrantkinja Gezina Krespal, koja živi u Njujorku sa maloletnom ćerkom Mari, zaposlena je kao prevoditeljka u jednoj međunarodnoj banci. U dnevniku koji započinje 21. avgusta 1967. i završava 20. avgusta 1968. mlada Nemica beleži utiske iz svakodnevnog života u Americi, uključujući i aktuelne političke događaje o kojima se informiše čitajući Njujork tajms. Istovremeno, ona pokušava da rekonstruiše svoju traumatičnu prošlost u nemačkoj pokrajini Maklenburg – Zapadna Pomeranija u vreme nacionalsocijalizma, Drugog svetskog rata, dolaska Sovjeta i Nemačke Demokratske Republike.Tako je sastavljena simfonija 20. veka, u kojoj se spajaju glasovi prošlosti i istorije u nastajanju. U varijaciji tonova i stilova smenjuju se doslovni citati iz Njujork tajmsa, Gezinini dijalozi sa Mari, autentični dokumenti poput spiskova za streljanje, dijalozi u kurzivu sa mrtvima ili odsutnima, Gezinin dnevnik beležen na magnetofonskoj traci...U drugom tomu Jonzonovog romana, horskog dela koje je obeležilo savremenu književnost kao malo koje drugo, izdvaja se nezaboravni solo Gezinine majke nastradale u Kristalnoj noći – tragične figure koja oličava sudbinu cele jedne generacije.", "svakidanugodiniii.jpg", true },
                    { 9, 2, 5, 177, "1974", "000009", 3, 2, "Ostrvo", "Dvoje ljudi na usamljenom ostrvu pokušavaju da povrate smisao koji je bespovratno istekao iz života; da nadoknade godine provedene u ispraznosti i simulakrumu života koji je, sopstvenom rutinom, opustošio samog sebe - to bi bio kratak kroki sadržaj romana Ostrvo.Čovjek i žena pokušavaju da nađu zamjenu za vjeru u život posmatrajući jedno drugo; svako sa svoje strane samotnog ostrva duše izgubljene negdje između dostignutog i nedostingnutog, bića i nebića.", "ostrvo.jpg", true },
                    { 11, 4, 4, 118, "2000", "000011", 6, 1, "Otpor", "Otpor je knjiga u kojoj Sabato kao budni posmatrač ljudske egzistencije poziva na pobunu protiv čovekovog duhovnog pada i gubitka međuljudske bliskosti koja dolazi kao posledica uništavanja kulturnih vrednosti na kojima su počivale generacije.Piščeva duboka zabrinutost za čoveka koji, usled gubitka povezanosti sa drugim ljudima i uzdizanjem svog sopstvenog ja, vodi život na granici beznađa, podstiče čitaoca na promišljanja o vlastitiom životu i idealima kojima savremeni čovek teži. Šta za čoveka predstavlja sreća i koliko je spreman da u nju uključi i druge ljude? Da li je uživanje u materijalnom postalo osnovni čovekov ideal i ko je glavni krivac za to? Ovo su samo neka od pitanja koja autor iznosi pred čitaoca u nadi da će podstaći promene koje će čoveka vratiti istinskim humanističkim vrednostima, a spremnost da se otvorimo za drugog čitavim bićem jedan je od preduslova koji su neophodni za čovekovu istinsku sreću.", "otpor.jpg", true },
                    { 3, 2, 10, 473, "1966", "000003", 2, 2, "Derviš i smrt", "Derviš i smrt je psihološki roman Meše Selimovića pisan u razdoblju od 1962. do 1966. godine i smatra se njegovim najuspješnijim djelom. Glavni lik romana je sredovječni derviš Ahmed Nurudin, upravitelj jednog derviškog samostana u osmanskoj Bosni. Promjene u njegov skroman i miran život unosi vijest da mu je brat uhićen iz političkih razloga. Pokušavajući pomoći bratu sam se suočava s vlašću i društvom pri čemu biva potresen njegov dotadašnji svjetonazor i način života. Osim psihološke problematike, u romanu su izražena i mnoga filozofska pitanja vezana uz ljudski život, društvo i politiku, a također je izložena i analiza društvenog i političkog stanja u Bosni za vrijeme Osmanskog Carstva.", "dervisismrt.jpg", true },
                    { 4, 2, 6, 316, "1970", "000004", 3, 2, "Tvrđava", "Glavni junak romana, Ahmet Šabo, želi pronaći most do drugih ljudi, da izađe iz tvrđave, jer zna, razdvaja nas i uništava mržnja, održat će nas samo ljubav, ili makar vjera da je moguće ma kakvo sporazumijevanje među pojedincima i zajednicom. Vođen tom vjerom i željom, on ostaje vedar i moralno čist. Najčešće se o Dervišu i o Tvrđavi govori u paru, gotovo kao da je riječ o dijelovima istog ciklusa, o nastavcima. A ipak, mada je riječ o romanima iz kojih se zrcali slična vizija svijeta, oni se suštinski razlikuju. Tvrđava je, usprkos svemu, vedriji roman: u Dervišu je smrt besmisao kao i život, dok Tvrđava smisao nudi u ljubavi (kraj pretposljednjeg poglavlja Tvrđave kao da je direktna antiteza čuvenom kraju Derviša i smrti: Odlučio sam se za ljubav. Manje je istinito, i manje vjerovatno, ali je plemenitije. I ljepše: tako sve ima više smisla. I smrt. I život.), a životna linija vodilja Ahmeta Šabe jest ono što negdje ističe upravo Meša Selimović: ostati neuprljan u jednom prljavom svijetu.", "tvrdjava.jpg", true },
                    { 5, 3, 4, 550, "1945", "000005", 4, 2, "Travnička hronika", "Travnička hronika (1945) je istorijski roman pisan za vrijeme Drugog svetskog rata, ostvaren po modelu evropskog realističkog romana. Obuhvata vrijeme od 1807. do 1814. godine i po tome predstavlja klasičan roman više od bilo kojeg drugog Andrićevog romanesknog ostvarenja. Roman je ispripovijedan u trećem licu i sklopljen je od prologa, epiloga i 28 poglavlja. Razlika između travničke i višegradske hronike jeste u tome što se roman Na Drini ćuprija mahom zasniva na fikcionalnoj nadogradnji usmenih legendi dok je Travnička hronika nastala imaginiranjem vrlo bogate dokumentarne građe. Hronika o Travniku je beletristički sedmogodišnji ljetopis koji obrađuje vrijeme boravka stranih konzula u tom vezirskom gradu. Počinje dolaskom francuskog konzula, a završava se odlaskom drugopostavljenog austrijskog konzula. Prema poetičkom pravilu koje važi za sve Andrićeve romane (izuzimajući donekle Gospođicu) i ovaj roman okrenut je istoriji. U procesu stvaranja Travničke hronike Andrić se služio bogatom dokumentarnom građom iz oblasti istorije civilizacije, etnologije i autentičnu spisima o istorijskim ličnostima koje su predstavljene u romanu. Istorija je utkana tako reći, u svaku rečenicu (do te mjere, ponekad, da bi se mogle staviti, pri dnu stranice referencije izvora), dajući joj na taj način izvjesnu autentičnost i životnost, napisao je Mithad Šamić u studiji Istorijski izvori Travničke hronike.Od svih Andrićevih djela hronika o vezirskom gradu ima najviše likova. Ključni lik djela je francuski konzul Žan Davil, Parižanin tanane prirode, pjesnik po osjećanju svijeta. Ta istorijski verifiikovana ličnost je kao prototip poslužio Andriću za oblikovanje književnog lika u kojem se kao u osetljivom mediju projektuju slike bosanske sredine, običaja i navika bosanskog svijeta.U Travničkoj hronici sudarila su se četiri svijeta, različita po vjeri, kulturi, istoriji, običajima. Emisari zapadnih i istočnih svjetova našli su se na prostoru Bosne sa namjerom da nikada i ne pokušaju da se približe i razumiju. Najbliži saradnici francuskog i austrijskog konzula i vezira i stanovnici tamnog bosanskog vilajeta, Davna, Rota, turski ćehaja, teftedar Baki, kao i travničke kasablije, u neprestanim su međusobnim sukobima i stalno iskazuju mračne ljudske nagone.", "travnickahronika.jpg", true },
                    { 6, 3, 5, 318, "1945", "000006", 4, 2, "Na Drini ćuprija", "Roman Na Drini ćuprija u kojem se uglavnom dosljedno hronološki opisuje svakodnevni život višegradske kasabe je, zapravo, višegradska hronika, pandan Travničkoj hronici i Omerpaši Latasu koji je sarajevska hronika: u sklopu toga hronikalnog troknjižja Ivo Andrić pripovjeda o turskim vremenima u Bosni.Roman počinje dugim geografskim opisom višegradskog kraja i navođenjem više legendi o nastanku mosta, od kojih je posebna markantna ona o uziđivanju hrišćanske djece u jedan od stubova. Porijeklo legende je u nacionalnom mitu i epskoj viziji svijeta koja je književni ekvivalent toga mita. Legende su po pravilu paralelne, imaju hrišćansku i muslimansku verziju.Kraj romana pada u 1914. godinu kada su trupe austrougarske monarhije, u povlačenju, ozbiljno oštetile most. Sa rušenjem mosta izdiše i Alihodža, jedan od najčešće pominjanih likova, koji simbolizuje kraj starih vremena. Između početka i kraja romana, između građenja i rušenja mosta, širi se pripovjedački luk dug četiri stotine godine u kojem, u formi vrlo razvijenih epizoda, zapravo, celih priča, Andrić niže sudbine višegradskih ljudi, svih vera", "nadrinicuprija.jpg", true },
                    { 7, 3, 8, 130, "1954", "000007", 4, 2, "Prokleta avlija", "Kratki roman Prokleta avlija, čije pisanje je Andrić započeo između dva svjetska rata, a dovršio ga i objavio 1954. godine, smatra se piščevim remek-djelom. Komponovan je narativnim postupkom upričavanja priče (prstenasta, okvirna strktura). Ima više pripovjedača koji jedan od drugoga preuzimaju kazivačku poziciju. Pripovijedanje u ovom romanu može se predstaviti i slikom koncentričnih krugova koji se skupljaju do samog jezgra priče. Kao i svi drugi Andrićevi romani, izuzimajući Gospođicu, i Prokleta avlija okrenuta je istoriji, ali na drukčiji način od višegradske, travničke i sarajevske hronike. Roman je ispripovijedan smirenim, nepristrasnim tonom, kojim se odmjereno i sugestivno teži objektivizaciji, kako je to kod Andrića već običaj i pravilo. Do centralne, istorijske priče iz XI vijeka o tragičnoj sudbini Džem-sultana, Andrić nas dovodi posredno. O Džem-sultanu pripovijeda mladi polu -Turčin Ćamil, koji u njemu vidi svog sudbinskog srodnika i preteču. O Ćamilu pripovijeda prestravljeni Jevrejin Haim, a svi oni su samo uspomena fra Petra na dane provedene u stambolskom zatvoru, prokletoj avliji. A tu uspomenu, opet, grli luk sjećanja bezimenog mladića (pisca?), koji, gledajući u zimski dan na fra-Petrov grob, vraća u sebi cijeli tok priče.Svi protagonisti Proklete avlije, ma koliko različiti, čuvaju u sebi iskustvo sužnja, pa i svijet, makar i nesvjesno, osjećaju kao ograničen, tjeskoban prostor. Kao da je samo postojanje tamnovanje. (Naslov romana simbolički je ključ čitanja.) Uskomješanost zatvora u koji se sliva zli talog imperije koja je prešla svoj vrhunac, ali gdje, igrom slučaja, zalutaju i ljudi koji su samo drukčiji od ostalih, postaje neka vrsta zamjene za svijet on traje u vremenu i ne obazire se na pojedinačne ljudske sudbine koje ga tvore. Svi su sporedni i nevažni zapisuje Andrić. Avlija živi sama za sebe, sa stotinu promjena, i uvijek ista.", "prokletaavlija.jpg", true }
                });

            migrationBuilder.InsertData(
                table: "Uposlenik",
                columns: new[] { "UposlenikId", "DatumZaposlenja", "GradId", "KorisnickiNalogId", "Status" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, true },
                    { 2, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, true },
                    { 6, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, false },
                    { 7, new DateTime(2019, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7, false },
                    { 1, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, true },
                    { 3, new DateTime(2020, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, true },
                    { 5, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, true }
                });

            migrationBuilder.InsertData(
                table: "Rezervacija",
                columns: new[] { "RezervacijaId", "ClanId", "DatumRezervacije", "KnjigaId", "Status" },
                values: new object[,]
                {
                    { 7, 3, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false },
                    { 13, 2, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, true },
                    { 19, 8, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 10, 5, new DateTime(2020, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, false },
                    { 14, 3, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 16, 4, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, true },
                    { 12, 1, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, true },
                    { 5, 2, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { 2, 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { 3, 1, new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false },
                    { 6, 3, new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, false },
                    { 11, 6, new DateTime(2020, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, false },
                    { 8, 4, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, false },
                    { 17, 7, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, false },
                    { 9, 4, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false },
                    { 15, 4, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, true },
                    { 18, 8, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, true },
                    { 1, 1, new DateTime(2020, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false },
                    { 4, 2, new DateTime(2020, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false }
                });

            migrationBuilder.InsertData(
                table: "Uplata",
                columns: new[] { "UplataId", "ClanId", "DatumUplate", "IznosUplate", "VrstaUplateId" },
                values: new object[,]
                {
                    { 54, 4, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 55, 4, new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 34, 2, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 57, 4, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 35, 2, new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 33, 2, new DateTime(2021, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 32, 2, new DateTime(2021, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 31, 2, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 56, 4, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 67, 8, new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 39, 3, new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 37, 3, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 51, 4, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 52, 4, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 53, 4, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 49, 3, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 48, 3, new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 47, 3, new DateTime(2021, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 46, 3, new DateTime(2021, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 45, 3, new DateTime(2021, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 44, 3, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 43, 3, new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 42, 3, new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 41, 3, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 40, 3, new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 30, 2, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 38, 3, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 36, 3, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 29, 2, new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 22, 2, new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 27, 2, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 10, 1, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 9, 1, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 8, 1, new DateTime(2020, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 7, 1, new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 6, 1, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 5, 1, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 4, 1, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 3, 1, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 2, 1, new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 1, 1, new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 62, 6, new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 63, 6, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 64, 6, new DateTime(2021, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 65, 7, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 66, 7, new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 11, 1, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 28, 2, new DateTime(2020, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 12, 1, new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 14, 1, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 26, 2, new DateTime(2020, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 25, 2, new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 24, 2, new DateTime(2020, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 23, 2, new DateTime(2020, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 21, 2, new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 20, 2, new DateTime(2020, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 19, 2, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 18, 2, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 58, 4, new DateTime(2021, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 59, 5, new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 60, 5, new DateTime(2020, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 61, 5, new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 17, 1, new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 16, 1, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 15, 1, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 13, 1, new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 },
                    { 50, 4, new DateTime(2020, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1 }
                });

            migrationBuilder.InsertData(
                table: "UposlenikUloga",
                columns: new[] { "UposlenikUlogaId", "DatumIzmjene", "UlogaId", "UposlenikId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 4, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 5, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 6, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 7, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 8, new DateTime(2021, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "Zaduzenje",
                columns: new[] { "ZaduzenjeId", "ClanId", "DatumVracanja", "DatumZaduzenja", "KnjigaId", "Status" },
                values: new object[,]
                {
                    { 10, 3, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, false },
                    { 25, 7, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true },
                    { 24, 7, null, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true },
                    { 18, 6, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, false },
                    { 17, 6, new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, false },
                    { 16, 6, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, false },
                    { 1, 1, new DateTime(2020, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false },
                    { 23, 3, null, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, true },
                    { 15, 5, new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, false },
                    { 13, 5, new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, false },
                    { 2, 1, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { 3, 1, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false },
                    { 4, 1, new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, false },
                    { 5, 1, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, false },
                    { 12, 4, new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false },
                    { 11, 4, new DateTime(2021, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, false },
                    { 20, 1, null, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, true },
                    { 6, 2, new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, false },
                    { 7, 2, new DateTime(2020, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false },
                    { 21, 2, null, new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true },
                    { 22, 2, null, new DateTime(2021, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 9, 3, new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, false },
                    { 14, 5, new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false },
                    { 8, 2, new DateTime(2020, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clan_GradId",
                table: "Clan",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Clan_KorisnickiNalogId",
                table: "Clan",
                column: "KorisnickiNalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_AutorId",
                table: "Knjiga",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_IzdavacId",
                table: "Knjiga",
                column: "IzdavacId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_KategorijaId",
                table: "Knjiga",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ClanId",
                table: "Rezervacija",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KnjigaId",
                table: "Rezervacija",
                column: "KnjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_ClanId",
                table: "Uplata",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_VrstaUplateId",
                table: "Uplata",
                column: "VrstaUplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_GradId",
                table: "Uposlenik",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_KorisnickiNalogId",
                table: "Uposlenik",
                column: "KorisnickiNalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikUloga_UlogaId",
                table: "UposlenikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikUloga_UposlenikId",
                table: "UposlenikUloga",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenje_ClanId",
                table: "Zaduzenje",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenje_KnjigaId",
                table: "Zaduzenje",
                column: "KnjigaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "UposlenikUloga");

            migrationBuilder.DropTable(
                name: "Zaduzenje");

            migrationBuilder.DropTable(
                name: "VrstaUplate");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Izdavac");

            migrationBuilder.DropTable(
                name: "Kategorija");
        }
    }
}
