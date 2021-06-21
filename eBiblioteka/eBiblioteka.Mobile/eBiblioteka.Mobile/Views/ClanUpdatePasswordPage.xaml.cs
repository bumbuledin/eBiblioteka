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
    public partial class ClanUpdatePasswordPage : ContentPage
    {
        private ClanUpdatePasswordViewModel model = null;
        public ClanUpdatePasswordPage()
        {
            InitializeComponent();
            BindingContext = model = new ClanUpdatePasswordViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            ErrorLabel_NovaLozinka.IsVisible = false;
            ErrorLabel_StaraLozinka.IsVisible = false;
            ErrorLabel_NovaLozinkaPotvrda.IsVisible = false;
            model.IsButtonEnabled = false;

        }

        private void StaraLozinka_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(StaraLozinka.Text))
            {
                ErrorLabel_StaraLozinka.IsVisible = true;
                ErrorLabel_StaraLozinka.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_StaraLozinka.IsVisible = false;
            }
            EnableSpremiButton();
        }

        private void NovaLozinka_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NovaLozinka.Text))
            {
                ErrorLabel_NovaLozinka.IsVisible = true;
                ErrorLabel_NovaLozinka.Text = "Obavezno polje!";
            }
            else if(NovaLozinka.Text.Length <4)
            {
                ErrorLabel_NovaLozinka.IsVisible = true;
                ErrorLabel_NovaLozinka.Text = "Minimalno 4 karaktera!";
            }
            else
            {
                ErrorLabel_NovaLozinka.IsVisible = false;
            }
            EnableSpremiButton();
        }

        private void NovaLozinkaPotvrda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NovaLozinkaPotvrda.Text))
            {
                ErrorLabel_NovaLozinkaPotvrda.IsVisible = true;
                ErrorLabel_NovaLozinkaPotvrda.Text = "Obavezno polje!";
            }
            else if (NovaLozinkaPotvrda.Text.Length < 4)
            {
                ErrorLabel_NovaLozinkaPotvrda.IsVisible = true;
                ErrorLabel_NovaLozinkaPotvrda.Text = "Minimalno 4 karaktera!";
            }
            else if(NovaLozinkaPotvrda.Text.Length >= 4 && NovaLozinka.Text.Length >= 4 && NovaLozinkaPotvrda.Text != NovaLozinka.Text)
            {
                ErrorLabel_NovaLozinkaPotvrda.IsVisible = true;
                ErrorLabel_NovaLozinkaPotvrda.Text = "Lozinke se ne podudaraju!";
            }
            else
            {
                ErrorLabel_NovaLozinkaPotvrda.IsVisible = false;
            }
            EnableSpremiButton();
        }

        public void EnableSpremiButton()
        {

            if (
                (string.IsNullOrWhiteSpace(StaraLozinka.Text) || ErrorLabel_StaraLozinka.IsVisible) ||
                (string.IsNullOrWhiteSpace(NovaLozinka.Text) || ErrorLabel_NovaLozinka.IsVisible) ||
                (string.IsNullOrWhiteSpace(NovaLozinkaPotvrda.Text) || ErrorLabel_NovaLozinkaPotvrda.IsVisible)
                )
                model.IsButtonEnabled = false;
            else
                model.IsButtonEnabled = true;
        }
    }
    
}