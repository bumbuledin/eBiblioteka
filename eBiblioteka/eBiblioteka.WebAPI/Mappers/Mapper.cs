using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //Models
            CreateMap<Database.KorisnickiNalog, Model.KorisnickiNalog>().ReverseMap();
            CreateMap<Database.KorisnickiNalog, Model.AuthKorisnickiNalog>().ReverseMap();
            CreateMap<Database.Grad, Model.Grad>().ReverseMap();
            CreateMap<Database.VrstaUplate, Model.VrstaUplate>().ReverseMap();
            CreateMap<Database.Uplata, Model.Uplata>().ReverseMap();
            CreateMap<Database.Uloga, Model.Uloga>().ReverseMap();
            CreateMap<Database.UposlenikUloga, Model.UposlenikUloga>().ReverseMap();
            CreateMap<Database.Uloga, Model.Uloga>().ReverseMap();
            CreateMap<Database.Izdavac, Model.Izdavac>().ReverseMap();
            CreateMap<Database.Autor, Model.Autor>().ReverseMap();
            CreateMap<Database.Kategorija, Model.Kategorija>().ReverseMap();
            CreateMap<Database.Zaduzenje, Model.Zaduzenje>().ReverseMap();
            CreateMap<Database.Rezervacija, Model.Rezervacija>().ReverseMap();


            //Requests
            CreateMap<Database.Uposlenik, Model.Requests.UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.Uposlenik, Model.Requests.UposlenikUpdateRequest>().ReverseMap();
            CreateMap<Database.Grad, Model.Requests.UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.KorisnickiNalog, Model.Requests.ClanInsertRequest>().ReverseMap();
            CreateMap<Database.KorisnickiNalog, Model.Requests.ClanUpdateRequest>().ReverseMap();
            CreateMap<Database.KorisnickiNalog, Model.Requests.UposlenikInsertRequest>().ReverseMap();
            CreateMap<Database.KorisnickiNalog, Model.Requests.UposlenikUpdateRequest>().ReverseMap();
            CreateMap<Database.Clan, Model.Requests.ClanInsertRequest>().ReverseMap();
            CreateMap<Database.Clan, Model.Requests.ClanUpdateRequest>().ReverseMap();
            CreateMap<Database.Grad, Model.Requests.JednaVarijablaUpsertRequest>().ReverseMap();
            CreateMap<Database.VrstaUplate, Model.Requests.JednaVarijablaUpsertRequest>().ReverseMap();
            CreateMap<Database.Uloga, Model.Requests.JednaVarijablaUpsertRequest>().ReverseMap();
            CreateMap<Database.Uplata, Model.Requests.UplataUpsertRequest>().ReverseMap();
            CreateMap<Database.Izdavac, Model.Requests.IzdavacUpsertRequest>().ReverseMap();
            CreateMap<Database.Autor, Model.Requests.AutorUpsertRequest>().ReverseMap();
            CreateMap<Database.Kategorija, Model.Requests.JednaVarijablaUpsertRequest>().ReverseMap();
            CreateMap<Database.Knjiga, Model.Requests.KnjigaUpsertRequest>().ReverseMap();
            CreateMap<Database.Zaduzenje, Model.Requests.ZaduzenjeUpsertRequest>().ReverseMap();
            CreateMap<Database.Rezervacija, Model.Requests.RezervacijaUpsertRequest>().ReverseMap();







            /*Pošto sam sve zajednicke atribute clanova i uposlenika stavio u tabelu korisnicki nalog
            samo sam na maperu prepisao nacin na koji ce mapirati elemente u modelu, kako bi prikaz
            izgledao preglednije i jednostavnije za raditi sa njim.*/

            CreateMap<Database.Clan, Model.Clan>()
                .ForMember(s=> s.Ime, x=> x.MapFrom(y=> y.KorisnickiNalog.Ime))
                .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiNalog.Prezime))
                .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiNalog.Email))
                .ForMember(s => s.Telefon, x => x.MapFrom(y => y.KorisnickiNalog.Telefon))
                .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiNalog.KorisnickoIme))
                .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiNalog.Adresa))
                .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiNalog.DatumRodjenja))
                .ForMember(s => s.SlikaPutanja, x => x.MapFrom(y => y.KorisnickiNalog.SlikaPutanja))
                .ReverseMap();

            CreateMap<Database.Uposlenik, Model.Uposlenik>()
                .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiNalog.Ime))
                .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiNalog.Prezime))
                .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiNalog.Email))
                .ForMember(s => s.Telefon, x => x.MapFrom(y => y.KorisnickiNalog.Telefon))
                .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiNalog.KorisnickoIme))
                .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiNalog.Adresa))
                .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiNalog.DatumRodjenja))
                .ForMember(s => s.SlikaPutanja, x => x.MapFrom(y => y.KorisnickiNalog.SlikaPutanja))
                .ReverseMap();

            CreateMap<Database.Knjiga, Model.Knjiga>()
              .ForMember(s => s.TrenutnoZaduzeno, x => x.MapFrom(y => y.Zaduzenja.Where(s => s.Status == true).Count()))
              .ForMember(s => s.TrenutnoRezervisano, x => x.MapFrom(y => y.Rezervacije.Where(s=> s.Status == true).Count()))
              .ReverseMap();

        }
    }
}
