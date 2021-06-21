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
    public class KnjigaDetaljiViewModel : BaseViewModel
    {
        private APIService _rezervacijaService = new APIService("Rezervacija");
        public KnjigaDetaljiViewModel()
        {
            Title = "Detalji knjige";
            RezervacijaCommand = new Command(async () => await RezervisiKnjigu());
        }
        public Model.Knjiga Knjiga { get; set; }


        public ICommand RezervacijaCommand { get; set; }

        public async Task RezervisiKnjigu()
        {
            IsBusy = true;

            var clan = await _rezervacijaService.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });

            RezervacijaUpsertRequest request = new RezervacijaUpsertRequest()
            {
                DatumRezervacije = DateTime.Now,
                ClanId = clan.ClanId,
                KnjigaId = Knjiga.KnjigaId,
                ClanMessage = true
            };

            try
            {
                var insert = await _rezervacijaService.Insert<Model.Rezervacija>(request);

                if(insert!=null)
                {
                    await Application.Current.MainPage.DisplayAlert("Informacija", "Uspješno ste rezervisali knjigu.", "OK");

                    if(ViewModelContainer.RezervacijaViewModel != null)
                        await ViewModelContainer.RezervacijaViewModel.UpdateAfterReservation();
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
