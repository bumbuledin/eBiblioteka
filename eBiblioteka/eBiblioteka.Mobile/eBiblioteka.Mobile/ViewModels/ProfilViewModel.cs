using eBiblioteka.Mobile.Helpers;
using eBiblioteka.Mobile.Services;
using eBiblioteka.Mobile.Views;
using eBiblioteka.Model.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        private APIService _service = new APIService("Clan");
        private ImageHelper img = new ImageHelper();
        private Model.Clan _clan;
        public ProfilViewModel()
        {
            Title = "Profil";
            InitCommand = new Command(async () => await Init());
            AddNewPhoto = new Command(async () => await PickAndShow(img.GetOptionsFromHelper()));
            IzmjenaPodatakaCommand = new Command(async () => await IzmjenaPodataka());
            IzmjenaLozinkeCommand = new Command(async () => await IzmjenaLozinke());
        }

        public Model.Clan Clan
        {
            get { return _clan; }
            set { SetProperty(ref _clan, value); }
        }
        public ICommand InitCommand { get; set; }
        public ICommand IzmjenaPodatakaCommand { get; set; }
        public ICommand IzmjenaLozinkeCommand { get; set; }


        public ICommand AddNewPhoto { get; set; }


        public async Task Init()
        {
            if (_clan == null)
            {
                Clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }
        }

        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    //Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();

                        var filename = result.FileName;
                        var slika = img.GetImageStreamAsBytes(stream);

                        ClanUpdatePhotoRequest request = new ClanUpdatePhotoRequest()
                        {
                            SlikaPutanja = filename,
                            Slika = slika
                        };

                        var resultFromApi = await _service.UpdatePhoto<Model.Clan>(_clan.ClanId, request);

                        if (resultFromApi != null)
                        {
                            this.Clan = resultFromApi;
                            if(ViewModelContainer.appShellViewModel != null)
                                ViewModelContainer.appShellViewModel.Slika = resultFromApi.Slika;
                            await Application.Current.MainPage.DisplayAlert("Informacija", "Uspješno ste dodali novu sliku.", "OK");
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

                // The user canceled or something went wrong
            }

            return null;
        }

        async Task IzmjenaPodataka()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new ClanUpdatePage());
        }

        async Task IzmjenaLozinke()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new ClanUpdatePasswordPage());
        }
    }
}
