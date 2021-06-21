using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class UposlenikUloga
    {
        public int UposlenikUlogaId { get; set; }
        public int UposlenikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual Uposlenik Uposlenik { get; set; }

    }
}
