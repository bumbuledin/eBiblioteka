using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class JednaVarijablaUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
    }
}
