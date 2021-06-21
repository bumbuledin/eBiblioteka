using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class IzdavacUpsertRequest
    {
        [Required]
        [MinLength(3, ErrorMessage="Minimalno 3 karaktera,a maximalno 20 karaktera!")]
        [MaxLength(20, ErrorMessage = "Minimalno 3 karaktera,a maximalno 20 karaktera!")]
        public string Naziv { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Neispravan format emaila.")]
        public string KontaktEmail { get; set; }
    }
}
