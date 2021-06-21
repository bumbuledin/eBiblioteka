using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class AutorUpsertRequest
    {
        [Required]
        [RegularExpression(@"^\p{Lu}{1}\p{Ll}{2,19}$", ErrorMessage = "Neispravan format. Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.")]
        public string Ime { get; set; }
        [Required]
        [RegularExpression(@"^\p{Lu}{1}\p{Ll}{2,19}$", ErrorMessage = "Neispravan format. Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.")]
        public string Prezime { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Neispravan format. Godina mora sadržavati četri broja!")]
        public string GodinaRodjenja { get; set; }
    }
}
