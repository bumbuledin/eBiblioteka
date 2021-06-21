using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private readonly Model.Clan _clan = null;

        public AppShellViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public AppShellViewModel(Model.Clan clan = null)
        {
            _clan = clan;
            InitCommand = new Command(async () => await Init());
        }

        string _imePrezime = string.Empty;
        public string ImePrezime
        {
            get { return _imePrezime; }
            set { SetProperty(ref _imePrezime, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        byte[] _slika = null;
        public byte[] Slika
        {
            get { return _slika; }
            set { SetProperty(ref _slika, value); }
        }

        public ICommand InitCommand;

        public async Task Init()
        {
            ImePrezime = _clan.ImePrezime;
            Email = _clan.Email;
        }

        public  void Init2()
        {
            ImePrezime = _clan.ImePrezime;
            Email = _clan.Email;
            Slika = _clan.Slika;
        }
    }
}
