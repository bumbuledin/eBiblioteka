using eBiblioteka.Mobile.Services;
using eBiblioteka.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class RezervacijaViewModel : BaseViewModel
    {
        private APIService _service = new APIService("Rezervacija");
        private Model.Clan _clan = null;

        public RezervacijaViewModel()
        {
            Title = "Rezervacije";
            InitCommand = new Command(async() => await Init());
        }

        public ICommand InitCommand{ get; set; }

        public ObservableCollection<Model.Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Model.Rezervacija>();

        protected bool _filterAktivneRezervacije;
        public bool Status
        {
            get { return _filterAktivneRezervacije; }
            set { SetProperty(ref _filterAktivneRezervacije, value); }
        }

        protected DateTime _datumOd;
        public DateTime DatumOd
        {
            get { return _datumOd; }
            set { SetProperty(ref _datumOd, value); }
        }

        protected DateTime _datumDo;
        public DateTime DatumDo
        {
            get { return _datumDo; }
            set { SetProperty(ref _datumDo, value); }
        }

        protected bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }
        public async Task Init(bool FilterEventCall=false)
        {
            if(_clan == null)
            {
                _clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }
            if(RezervacijaList.Count == 0 && FilterEventCall==false && IsVisible==false)
            {
                RezervacijaSearchRequest search2 = new RezervacijaSearchRequest() { ClanId = _clan.ClanId };
                var list = await _service.Get<List<Model.Rezervacija>>(search2);

                if(list.Count > 0)
                {
                    DatumOd = list.Min(s => s.DatumRezervacije);
                    DatumDo = list.Max(s => s.DatumRezervacije);
                }
                

                foreach (var item in list)
                {
                    RezervacijaList.Add(item);
                }

                if (RezervacijaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }
            if(FilterEventCall == true)
            {
                RezervacijaSearchRequest search = new RezervacijaSearchRequest() { ClanId = _clan.ClanId, Status = Status, DatumOd = this.DatumOd, DatumDo = this.DatumDo };

                var list = await _service.Get<List<Model.Rezervacija>>(search);

                RezervacijaList.Clear();

                foreach (var item in list)
                {
                    RezervacijaList.Add(item);
                }

                if (RezervacijaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }

        }


        // Zbog navigacije prilikom rezervisanja nove knjige, ukoliko se korisnik vrati na page rezervacija ista nece odma biti prikazana dok se ne napravi izmjena na page-u,
        // pa sam dodao akciju koja ce prilikom rezervisanja nove knjige automatski update-ovati listu rezervacija, kako bi korisnik prilikom otvaranja page-a Rezevacije
        // novu rezervaciju imao odma dostupnu na pregled.
        public async Task UpdateAfterReservation()
        {
            if (_clan == null)
            {
                _clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }

            if (RezervacijaList.Count > 0)
                RezervacijaList.Clear();

            RezervacijaSearchRequest search2 = new RezervacijaSearchRequest() { ClanId = _clan.ClanId };
            var list = await _service.Get<List<Model.Rezervacija>>(search2);

            if(list.Count > 0)
            {
                DatumOd = list.Min(s => s.DatumRezervacije);
                DatumDo = list.Max(s => s.DatumRezervacije);
                Status = false;
            }
            

            foreach (var item in list)
            {
                RezervacijaList.Add(item);
            }

        }
    }
}
