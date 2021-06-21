using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class ClanUpdatePhotoRequest
    {
        [Required]
        public string SlikaPutanja { get; set; }
        [Required]
        public byte[] Slika { get; set; }
    }
}
