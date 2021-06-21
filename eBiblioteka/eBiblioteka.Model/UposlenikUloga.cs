using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class UposlenikUloga
    {
        [JsonIgnore]
        public int UposlenikUlogaId { get; set; }
        [JsonIgnore]
        public int UposlenikId { get; set; }
        [JsonIgnore]
        public int UlogaId { get; set; }
        [JsonIgnore]
        public DateTime DatumIzmjene { get; set; }
        public virtual Model.Uloga Uloga { get; set; }
        public virtual Model.Uposlenik Uposlenik { get; set; }
    }
}
