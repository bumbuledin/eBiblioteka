using eBiblioteka.Mobile.ViewModels;
using eBiblioteka.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eBiblioteka.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private AppShellViewModel model = null;
        private Model.Clan _clan = null;
        public AppShell(Model.Clan clan)
        {
            InitializeComponent();
            BindingContext = model = new AppShellViewModel(clan);
            if (_clan == null)
            {
                _clan = clan;
                model.Init2();
            }
            ViewModelContainer.appShellViewModel = model;
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }



        //Ovo jednostavno ne radi na shellu, Bug je prijavljen prije 2 godine i još nije ispravljen ...
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init2();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Odjava", "Da li se sigurno želite odjaviti iz aplikacije ?", "Da", "Ne");

            if (answer == true)
            {
                Application.Current.MainPage = new Login();
            }
        }
    }
}
