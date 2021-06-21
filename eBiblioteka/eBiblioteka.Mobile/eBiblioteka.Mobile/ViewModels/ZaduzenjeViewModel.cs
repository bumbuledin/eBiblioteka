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
    public class ZaduzenjeViewModel : BaseViewModel
    {
        private APIService _service = new APIService("Zaduzenje");
        private Model.Clan _clan = null;

        public ZaduzenjeViewModel()
        {
            Title = "Zaduženja";
            InitCommand = new Command(async () => await Init());
        }

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Model.Zaduzenje> ZaduzenjaList { get; set; } = new ObservableCollection<Model.Zaduzenje>();

        protected bool _filterAktivnoZaduzenje;
        public bool Status
        {
            get { return _filterAktivnoZaduzenje; }
            set { SetProperty(ref _filterAktivnoZaduzenje, value); }
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

        public async Task Init(bool FilterEventCall = false)
        {
            if (_clan == null)
            {
                _clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }
            if (ZaduzenjaList.Count == 0 && FilterEventCall == false && IsVisible == false)
            {
                ZaduzenjeSearchRequest search2 = new ZaduzenjeSearchRequest() { ClanId = _clan.ClanId };
                var list = await _service.Get<List<Model.Zaduzenje>>(search2);

                if(list.Count > 0)
                {
                    DatumOd = list.Min(s => s.DatumZaduzenja);
                    DatumDo = list.Max(s => s.DatumZaduzenja);
                }

                foreach (var item in list)
                {
                    ZaduzenjaList.Add(item);
                }

                if (ZaduzenjaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;


            }
            if (FilterEventCall == true)
            {
                ZaduzenjeSearchRequest search = new ZaduzenjeSearchRequest() { ClanId = _clan.ClanId, Status = Status, DatumOd = this.DatumOd, DatumDo = this.DatumDo };

                var list = await _service.Get<List<Model.Zaduzenje>>(search);

                ZaduzenjaList.Clear();

                foreach (var item in list)
                {
                    ZaduzenjaList.Add(item);
                }

                if (ZaduzenjaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }
        }

            
    }
}
