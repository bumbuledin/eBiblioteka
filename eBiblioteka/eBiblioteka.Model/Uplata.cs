using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBiblioteka.Model
{
    public class Uplata
    {
        public int UplataId { get; set; }
        public int ClanId { get; set; }
        public int VrstaUplateId { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal IznosUplate { get; set; }
        public string VrstaUplateNaziv
        {
            get { return VrstaUplate.Naziv; }
        }
        public string ImePrezime
        {
            get { return Clan.ImePrezime; }
        }
        public DateTime VaziDo
        {
            get
            {
                if (VrstaUplate.Naziv == "Mjesečna uplata")
                    return DatumUplate.AddMonths(1);
                else if (VrstaUplate.Naziv == "Godišnja uplata")
                    return DatumUplate.AddYears(1);
                else
                    return DatumUplate;
            }
        }
        public virtual Model.VrstaUplate VrstaUplate { get; set; }
        public virtual Model.Clan Clan { get; set; }
    }
}
