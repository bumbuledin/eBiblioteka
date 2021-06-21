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
using System.IO;

namespace eBiblioteka.WebAPI.Services
{
    public class PreporukaService : IPreporukaService
    {
        private readonly eBibliotekaContext _context;
        private readonly IMapper _mapper;
        private ImageHelper imageHelper = new ImageHelper();
        private readonly CBF _cbf = new CBF();
        public PreporukaService(eBibliotekaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /* Ideja je bila da sistem na osnovu knjiga koje je korisnik zaduživao, predlaže nove knjige istog ili sličnog žanra i od istog pisca.
           Za implementaciju sam iskoristio Levenshtein Distance Algorithm, koji koristi matricu za računanje udaljenosti između sličnosti 2 stringa.
        */

        public async Task<List<Model.Knjiga>> Preporuka(int id)
        {

            //Korak 1. Preuzimanje svih zaduženja i rezervacija, koje je korisnik imao, kako bi mogli filtrirati listu knjiga, te izbaciti knjige koje je korisnik već imao
            var zaduzenja = await _context.Zaduzenje.Include("Clan.KorisnickiNalog").Include("Knjiga").Where(s => s.ClanId == id).ToListAsync();



            //Korak 2. Preuzimanje svih knjiga od autora, čije je knjige korisnik već zaduživao
            var knjigeOdAutoraIzPrethodnihZaduzenja = new List<Database.Knjiga>();
            foreach (var item in zaduzenja)
            {
                var knjige = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Include("Zaduzenja").Include("Rezervacije").Where(s => s.AutorId == item.Knjiga.AutorId).ToListAsync();
                foreach (var knjiga in knjige)
                {
                    if(knjigeOdAutoraIzPrethodnihZaduzenja.Find(d=> d.KnjigaId == knjiga.KnjigaId) == null)
                    {
                        knjigeOdAutoraIzPrethodnihZaduzenja.Add(knjiga);
                    }
                }
            }

            //Korak 3. Preuzimanje svih knjiga istog žanra, na osnovu prethodnih zaduženja
            var knjigeIstogZanra = new List<Database.Knjiga>();
            foreach (var item in zaduzenja)
            {
                var knjige = await _context.Knjiga.Include("Autor").Include("Izdavac").Include("Kategorija").Include("Zaduzenja").Include("Rezervacije").Where(s => s.KategorijaId == item.Knjiga.KategorijaId).ToListAsync();
                foreach (var knjiga in knjige)
                {
                    if (knjigeIstogZanra.Find(d => d.KnjigaId == knjiga.KnjigaId) == null)
                    {
                        knjigeIstogZanra.Add(knjiga);
                    }
                }
            }

            //Korak 4. Spajanje listi iz koraka 2 i 3, pri dodavanju u jednu zajedničku listu, provjerava se da li knjiga već postoji, kako u listi ne bi postojalo
            // više istih knjiga
            var konacnaListaKnjiga = new List<Database.Knjiga>();

            foreach (var item in knjigeOdAutoraIzPrethodnihZaduzenja)
            {
                if (konacnaListaKnjiga.Find(s => s.KnjigaId == item.KnjigaId) == null)
                    konacnaListaKnjiga.Add(item);
            }

            foreach (var item in knjigeIstogZanra)
            {
                if (konacnaListaKnjiga.Find(s => s.KnjigaId == item.KnjigaId) == null)
                    konacnaListaKnjiga.Add(item);
            }


            //Korak 5. Brisanje knjiga koje je već korisnik zaduživao iz liste za algoritam
            foreach (var item in zaduzenja)
            {
                if (konacnaListaKnjiga.Find(s => s.KnjigaId == item.KnjigaId) != null)
                    konacnaListaKnjiga.RemoveAll(x => x.KnjigaId == item.KnjigaId);
            }


            //Korak 6. Pretvaranje liste za algoritam u helper klasu, koja će pored knjige čuvati i score iz algoritma
            var knjigeScore = new List<ItemScore<Database.Knjiga>>();
            foreach (var item in konacnaListaKnjiga)
            {
                var newItem = new ItemScore<Database.Knjiga>
                {
                    Item = item,
                    Score = 0
                };
                knjigeScore.Add(newItem);
            }

            //Korak 7. Levenshtein Distance Algorithm
            foreach (var item in knjigeScore)
            {
                foreach (var knjigazaduzenje in zaduzenja)
                {
                    string source = item.Item.Naziv + "_" + item.Item.Autor.ImePrezime;
                    string target = knjigazaduzenje.Knjiga.Naziv + "_" + item.Item.Autor.ImePrezime;
                    item.Score += _cbf.CalculateSimilarity(source, target);
                }
            }



            //Korak 8. Konačna lista, uzimamo prve(top) 3 preporuke za korisnika
            knjigeScore.Sort((a, b) => b.Score.CompareTo(a.Score));
            var preporukaList = new List<Database.Knjiga>();
            foreach (var item in knjigeScore)
            {
                preporukaList.Add(item.Item);
            }

            var top3 = preporukaList.Take(3).ToList();
            var result = _mapper.Map<List<Model.Knjiga>>(top3);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Knjiga", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }
    }
}
