using eBiblioteka.Mobile.Services;
using eBiblioteka.Mobile.Views;
using eBiblioteka.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class ClanUpdatePasswordViewModel : BaseViewModel
    {
        private APIService _service = new APIService("Clan");
        private Model.Clan _clan = null;
        private string _staraLozinka;
        private string _novaLozinka;
        private string _novaLozinkaPotvrda;
        private bool _isButtonEnabled;



        public ClanUpdatePasswordViewModel()
        {
            Title = "Izmjena lozinke";
            InitCommand = new Command(async () => await Init());
            SpremiCommand = new Command(async () => await Spremi());
        }

        public string StaraLozinka
        {
            get { return _staraLozinka; }
            set { SetProperty(ref _staraLozinka, value); }
        }

        public string NovaLozinka
        {
            get { return _novaLozinka; }
            set { SetProperty(ref _novaLozinka, value); }
        }

        public string NovaLozinkaPotvrda
        {
            get { return _novaLozinkaPotvrda; }
            set { SetProperty(ref _novaLozinkaPotvrda, value); }
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
            }
        }

        public async Task Spremi()
        {
            IsButtonEnabled = false;
            IsBusy = true;

            ClanUpdatePasswordRequest request = new ClanUpdatePasswordRequest()
            {
                StaraLozinka = this.StaraLozinka,
                NovaLozinka = this.NovaLozinka,
                NovaLozinkaPotvrda = this.NovaLozinkaPotvrda
            };

            var result = await _service.UpdatePassword<bool>(_clan.ClanId, request);

            if (result == true)
            {
                await Application.Current.MainPage.DisplayAlert("Informacija", "Uspješno ste izmjenuli podatke." + Environment.NewLine + "Molimo da se ponovo prijavite kako bi koristili aplikaciju!", "OK");
                Application.Current.MainPage = new Login();
            }

            IsBusy = false;
        }
    }
}
