using eBiblioteka.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eBiblioteka.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KnjigaDetaljiPage : ContentPage
    {
        private KnjigaDetaljiViewModel model = null;
        public KnjigaDetaljiPage(Model.Knjiga knjiga)
        {
            InitializeComponent();
            BindingContext = model = new KnjigaDetaljiViewModel()
            {
                Knjiga = knjiga
            };
        }
    }
}