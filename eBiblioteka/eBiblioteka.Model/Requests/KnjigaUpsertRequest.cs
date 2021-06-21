using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class KnjigaUpsertRequest
    {
        [Required]
        [RegularExpression(@"^\p{Lu}{1}[\p{Ll}\p{Lu}\s\d]{2,29}$", ErrorMessage = "Prvo slovo mora biti veliko, minimalno 3 i maximalno 30 karaktera.")]
        public string Naziv { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Neispravan format. Godina mora sadržavati 4 broja!")]
        public string GodinaIzdavanja { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{6,9}$", ErrorMessage = "Inventarni broj mora sadržavati od 6 do 9 brojeva!")]
        public string InventarniBroj { get; set; }
        [Required]
        public int BrojStranica { get; set; }
        [Required]
        public int BrojKnjigaNaStanju { get; set; }
        public string SlikaPutanja { get; set; }
        public byte[] Slika { get; set; }
        [Required]
        public int AutorId { get; set; }
        [Required]
        public int IzdavacId { get; set; }
        [Required]
        public int KategorijaId { get; set; }
    }
}
