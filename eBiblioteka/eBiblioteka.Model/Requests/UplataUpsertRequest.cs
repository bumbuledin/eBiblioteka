using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eBiblioteka.Model.Requests
{
    public class UplataUpsertRequest
    {
        [Required]
        public int ClanId { get; set; }
        [Required]
        public int VrstaUplateId { get; set; }
        [Required]
        public DateTime DatumUplate { get; set; }
        [Required]
        public decimal IznosUplate { get; set; }
    }
}
