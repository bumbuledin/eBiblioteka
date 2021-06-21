using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class Knjiga
    {

        public int KnjigaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string GodinaIzdavanja { get; set; }
        public string InventarniBroj { get; set; }
        public int BrojStranica { get; set; }
        public int BrojKnjigaNaStanju { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        public int AutorId { get; set; }
        public int IzdavacId { get; set; }
        public int KategorijaId { get; set; }
        public int TrenutnoZaduzeno { get; set; }
        public int TrenutnoRezervisano { get; set; }
        public int PreostaloNaStanju => BrojKnjigaNaStanju - (TrenutnoRezervisano + TrenutnoZaduzeno);


        public virtual Model.Autor Autor { get; set; }
        public virtual Model.Izdavac Izdavac { get; set; }
        public virtual Model.Kategorija Kategorija { get; set; }

        //Koristio sam jsonignore kako atribut ne bih prikazivao na api-u, nego samo u desktop aplikaciji 
        //za combo box.
        [JsonIgnore]
        public string ImePrezime
        {
            get { return Autor.ImePrezime; }
        }

    }
}
