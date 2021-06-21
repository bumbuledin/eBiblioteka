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
    public partial class ZaduzenjaPage : ContentPage
    {
        private ZaduzenjeViewModel model = null;

        public ZaduzenjaPage()
        {
            InitializeComponent();
            BindingContext = model = new ZaduzenjeViewModel();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            DatumMin.DateSelected += DatePicker_DateSelected;
            DatumMax.DateSelected += DatePicker_DateSelected;
            Status.Toggled += Switch_Toggled;

        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (model != null)
                await model.Init(true);

        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (model != null)
                await model.Init(true);
        }
    }
}