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
    public class KnjigeViewModel : BaseViewModel
    {
        private APIService _knjigeService = new APIService("Knjiga");

        public KnjigeViewModel()
        {
            Title = "Knjige";
            InitCommand = new Command(async () => await Init());
        }

        public string _autorSearch = string.Empty;
        public string AutorSearch
        {
            get { return _autorSearch; }
            set
            {
                SetProperty(ref _autorSearch, value);
            }
        }

        public string _knjigaSearch = string.Empty;
        public string KnjigaSearch
        {
            get { return _knjigaSearch; }
            set
            {
                SetProperty(ref _knjigaSearch, value);
            }
        }

        protected bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }


        public ObservableCollection<Model.Knjiga> KnjigaList { get; set; } = new ObservableCollection<Model.Knjiga>();

        public ICommand InitCommand { get; set; }

        public async Task Init(bool OnTextChangedCall = false) 
        {
            if(KnjigaList.Count == 0 && OnTextChangedCall==false && IsVisible == false)
            {
                var list = await _knjigeService.Get<List<Model.Knjiga>>(null);

                if (KnjigaList.Count > 0)
                    KnjigaList.Clear();

                foreach (var item in list)
                {
                    KnjigaList.Add(item);
                }

                if (KnjigaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }

            if(OnTextChangedCall)
            {
                KnjigaSearchRequest search2 = new KnjigaSearchRequest();

                if (AutorSearch != string.Empty)
                    search2.ImePrezime = AutorSearch;

                if (KnjigaSearch != string.Empty)
                    search2.Naziv = KnjigaSearch;


                var list = await _knjigeService.Get<List<Model.Knjiga>>(search2);

                KnjigaList.Clear();

                foreach (var item in list)
                {
                    KnjigaList.Add(item);
                }


                if (KnjigaList.Count == 0)
                    IsVisible = true;
                else
                    IsVisible = false;
            }

        }
    }
}
