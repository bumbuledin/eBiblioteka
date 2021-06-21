using eBiblioteka.Mobile.ViewModels;
using eBiblioteka.Model.Requests;
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
	public partial class UplatePage : ContentPage
	{
		private UplateViewModel model = null;
		public UplatePage ()
		{
			InitializeComponent ();
			BindingContext = model = new UplateViewModel();
			ViewModelContainer.UplateViewModel = model;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
			await model.Init();
			DatumMin.DateSelected += DatePicker_DateSelected;
			DatumMax.DateSelected += DatePicker_DateSelected;
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
			if(model != null)
				await model.Init(true);

		}

	}
}