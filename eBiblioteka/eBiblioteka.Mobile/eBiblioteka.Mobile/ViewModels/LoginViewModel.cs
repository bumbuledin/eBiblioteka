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
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Clan");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
        }

        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }


        public ICommand LoginCommand { get; set; }



        private async Task OnLoginClicked()
        {
            if (string.IsNullOrWhiteSpace(KorisnickoIme) || string.IsNullOrWhiteSpace(Lozinka))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Sva polja moraju biti popunjena !!!", "OK");
            }
            else
            {
                IsBusy = true;
                APIService.Username = KorisnickoIme;
                APIService.Password = Lozinka;

                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

                try
                {
                    AuthenticationRequest request = new AuthenticationRequest
                    {
                        KorisnickoIme = KorisnickoIme,
                        Password = Lozinka
                    };

                    var x = await _service.Authenticate(request);
                    IsBusy = false;
                    Application.Current.MainPage = new AppShell(x);

                }
                catch (Exception ex)
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

                }
            }

        }
    }
}
