using eBiblioteka.Mobile.Services;
using eBiblioteka.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class PocetnaViewModel : BaseViewModel
    {
        private Model.Clan _clan = null;
        private Model.ClanCounter _clanCounter = null;
        private int _aktZaduzenja;
        private int _aktRezervacija;
        private int _ukuZaduzenja;

        private APIService _service = new APIService("Preporuka");
        public PocetnaViewModel()
        {
            Title = "Početna";
            InitCommand = new Command(async() => await Init());
        }

        public int AktivnaZaduzenja
        {
            get { return _aktZaduzenja; }
            set { SetProperty(ref _aktZaduzenja, value); }
        }
        public int AktivneRezervacije
        {
            get { return _aktRezervacija; }
            set { SetProperty(ref _aktRezervacija, value); }
        }
        public int UkupnoZaduzenja
        {
            get { return _ukuZaduzenja; }
            set { SetProperty(ref _ukuZaduzenja, value); }
        }

        protected bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }

        public ICommand InitCommand { get; set; }

        public ObservableCollection<Model.Knjiga> PreporukaList { get; set; } = new ObservableCollection<Model.Knjiga>();


        public async Task Init()
        {
            if (_clan == null)
                _clan = await _service.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });

            if(_clanCounter == null)
            {
                _clanCounter = await _service.GetCounter<Model.ClanCounter>(_clan.ClanId);
                AktivnaZaduzenja = _clanCounter.BrojAktivnihZaduzenja;
                AktivneRezervacije = _clanCounter.BrojAktivnihRezervacija;
                UkupnoZaduzenja = _clanCounter.BrojUkupnoZaduzenja;
            }

            if(PreporukaList.Count == 0)
            {
                var result = await _service.Preporuka<List<Model.Knjiga>>(_clan.ClanId);

                foreach (var item in result)
                {
                    PreporukaList.Add(item);
                }

                if (PreporukaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;

            }
        }
    }
}
