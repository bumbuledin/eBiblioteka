using eBiblioteka.Mobile.Services;
using eBiblioteka.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class ClanUpdateViewModel : BaseViewModel
    {
        private Model.Clan _clan = null;
        private APIService _service = new APIService("Clan");
        private string _ime;
        private string _prezime;
        private string _korisnickoIme;
        private string _adresa;
        private string _email;
        private string _telefon;
        private bool _isButtonEnabled;


        public ClanUpdateViewModel()
        {
            Title = "Izmjena ličnih podataka";
            InitCommand = new Command(async () => await Init());
            SpremiCommand = new Command(async () => await Spremi());
        }

        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        public string Adresa
        {
            get { return _adresa; }
            set { SetProperty(ref _adresa, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand SpremiCommand { get; set; }


        public async Task Init()
        {
            if(_clan == null)
            {
                _clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });

                Ime = _clan.Ime;
                Prezime = _clan.Prezime;
                KorisnickoIme = _clan.KorisnickoIme;
                Adresa = _clan.Adresa;
                Telefon = _clan.Telefon;
                Email = _clan.Email;

            }
        }

        public async Task Spremi()
        {
            IsButtonEnabled = false;
            IsBusy = true;

            ClanUpdateRequest request = new ClanUpdateRequest()
            {
                Ime = this.Ime,
                Prezime = this.Prezime,
                Email = this.Email,
                Telefon = this.Telefon,
                KorisnickoIme = this.KorisnickoIme,
                Adresa = this.Adresa,
                DatumRodjenja = _clan.DatumRodjenja,
                DatumUclanjenja = _clan.DatumUclanjenja,
                GradId = _clan.Grad.GradId,
                Status = _clan.Status
            };

            var result = await _service.Update<Model.Clan>(_clan.ClanId, request);

            if(result != null)
            {
                if(ViewModelContainer.appShellViewModel != null)
                {
                    ViewModelContainer.appShellViewModel.ImePrezime = result.ImePrezime;
                    ViewModelContainer.appShellViewModel.Email = result.Email;
                }

                if(ViewModelContainer.ProfilViewModel != null)
                    ViewModelContainer.ProfilViewModel.Clan = result;


                await Application.Current.MainPage.DisplayAlert("Informacija", "Uspješno ste izmjenuli podatke.", "OK");
            }

            IsBusy = false;

        }
    }
}
