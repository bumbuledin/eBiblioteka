using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class ClanUpdatePasswordRequest
    {
        [Required]
        public string StaraLozinka { get; set; }
        [Required]
        public string NovaLozinka { get; set; }
        [Required]
        public string NovaLozinkaPotvrda { get; set; }

    }
}
