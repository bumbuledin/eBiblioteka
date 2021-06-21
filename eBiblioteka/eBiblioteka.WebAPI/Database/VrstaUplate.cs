using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI.Database
{
    public class VrstaUplate
    {
        public VrstaUplate()
        {
            Uplate = new HashSet<Uplata>();
        }

        public int VrstaUplateId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Uplata> Uplate { get; set; }
    }
}
