using eBiblioteka.Mobile.Services;
using eBiblioteka.Mobile.Views;
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
    public class UplateViewModel : BaseViewModel
    {
        private APIService _uplataService = new APIService("Uplata");
        private Model.Clan _clan = null;

        public UplateViewModel()
        {
            Title = "Uplate";
            InitCommand = new Command(async () => await Init());
            NovaOnlineUplataCommand = new Command(async () => await NovaUplata());
        }

        public ObservableCollection<Model.Uplata> UplataList { get; set; } = new ObservableCollection<Model.Uplata>();

        protected DateTime _datumMin;
        public DateTime DatumMin
        {
            get { return _datumMin; }
            set { SetProperty(ref _datumMin, value); }
        }

        protected DateTime _datumMax;
        public DateTime DatumMax
        {
            get { return _datumMax; }
            set { SetProperty(ref _datumMax, value); }
        }

        protected DateTime _vaziDo;
        public DateTime VaziDo
        {
            get { return _vaziDo; }
            set { SetProperty(ref _vaziDo, value); }
        }

        protected bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }

        protected bool _IsVisibleClanarina;

        public bool IsClanarinaIstekla
        {
            get { return _IsVisibleClanarina; }
            set { SetProperty(ref _IsVisibleClanarina, value); }
        }


        public ICommand InitCommand { get; set; }
        public ICommand NovaOnlineUplataCommand { get; set; }


        //Varijablu FilterEventCall sam uveo iskljucivo radi navigacije, pošto se Init metode pozove i prilkom ponovnog otvaranja page-a,
        // pa kako bi sprijecio da se stranica refresha u slucaju da korisnik koristi navigaciju, nego ce se refreshati samo u slucaju eventa
        public async Task Init(bool FilterEventCall = false)
        {
            if (_clan == null)
            {
                _clan = await _uplataService.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }

            if (UplataList.Count == 0 && FilterEventCall == false)
            {
                UplataSearchRequest search2 = new UplataSearchRequest() { ClanId = _clan.ClanId };
                var list = await _uplataService.Get<List<Model.Uplata>>(search2);

                if (list.Count > 0)
                {
                    DatumMin = list.Last().DatumUplate;
                    DatumMax = list.First().DatumUplate;
                    VaziDo = list.First().VaziDo;
                }

                foreach (var item in list)
                {
                    UplataList.Add(item);
                }

                if (DateTime.Compare(VaziDo.Date, DateTime.Now.Date) < 0)
                    IsClanarinaIstekla = true;
                else
                    IsClanarinaIstekla = false;

                if (UplataList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }
            if (FilterEventCall == true)
            {

                UplataSearchRequest src = new UplataSearchRequest() { ClanId = _clan.ClanId, DatumOd = DatumMin, DatumDo = DatumMax };
                var list = await _uplataService.Get<List<Model.Uplata>>(src);

                UplataList.Clear();

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        UplataList.Add(item);
                    }
                }

                if (UplataList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }

        }

        public async Task NovaUplataInit()
        {
            UplataSearchRequest search2 = new UplataSearchRequest() { ClanId = _clan.ClanId };
            var list  = await _uplataService.Get<List<Model.Uplata>>(search2);

            UplataList.Clear();

            if (list != null)
            {
                foreach (var item in list)
                {
                    UplataList.Add(item);
                }
            }

            if (list.Count > 0)
            {
                DatumMin = list.Last().DatumUplate;
                DatumMax = list.First().DatumUplate;
                VaziDo = list.First().VaziDo;
                IsVisible = false;
            }

            if (DateTime.Compare(VaziDo.Date, DateTime.Now.Date) < 0)
                IsClanarinaIstekla = true;
            else
                IsClanarinaIstekla = false;
        }

        public async Task  NovaUplata()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new PaymentGatwayPage());
        }
    }
}
