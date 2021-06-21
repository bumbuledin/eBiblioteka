using eBiblioteka.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eBiblioteka.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClanUpdatePage : ContentPage
    {
        private ClanUpdateViewModel model = null;
        Regex ime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");
        Regex prezime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");
        Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex telefon = new Regex(@"^([0-9]){3}(-|/|\s)?([0-9]){3}(-|/|\s)?([0-9]){3,4}$");




        public ClanUpdatePage()
        {
            InitializeComponent();
            BindingContext = model = new ClanUpdateViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            ErrorLabel_Ime.IsVisible = false;
            ErrorLabel_Prezime.IsVisible = false;
            ErrorLabel_KorisnickoIme.IsVisible = false;
            ErrorLabel_Email.IsVisible = false;
            ErrorLabel_Telefon.IsVisible = false;
            ErrorLabel_Adresa.IsVisible = false;
            model.IsButtonEnabled = false;

        }

        private void Ime_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "Obavezno polje!";
            }
            else if (!ime.IsMatch(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.";
            }
            else
            {
                ErrorLabel_Ime.IsVisible = false;

            }
            EnableSpremiButton();
        }

        private void Prezime_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "Obavezno polje!";
            }
            else if (!prezime.IsMatch(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "Prvo slovo mora biti veliko, minimalno 3 i maximalno 20 karaktera.";
            }
            else
            {
                ErrorLabel_Prezime.IsVisible = false;

            }
            EnableSpremiButton();

        }

        private void KorisnickoIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KorisnickoIme.Text))
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "Obavezno polje!";
            }
            else if (KorisnickoIme.Text.Length < 4)
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "Minimalno 4 karaktera.";
            }
            else
            {
                ErrorLabel_KorisnickoIme.IsVisible = false;

            }
            EnableSpremiButton();

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Obavezno polje!";
            }
            else if (!email.IsMatch(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Neispravan format e-maila.";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;
            }
            EnableSpremiButton();

        }

        private void Telefon_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "Obavezno polje!";
            }
            else if (!telefon.IsMatch(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "Neispravan format. Primjer: 060-000-000 ili 060/000/0000 ili 0621234567";
            }
            else
            {
                ErrorLabel_Telefon.IsVisible = false;
            }
            EnableSpremiButton();

        }

        private void Adresa_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Adresa.Text))
            {
                ErrorLabel_Adresa.IsVisible = true;
                ErrorLabel_Adresa.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_Adresa.IsVisible = false;
            }
            EnableSpremiButton();

        }

        public void EnableSpremiButton()
        {


            if (
                (string.IsNullOrWhiteSpace(Ime.Text) || ErrorLabel_Ime.IsVisible) ||
                (string.IsNullOrWhiteSpace(Prezime.Text) || ErrorLabel_Prezime.IsVisible) ||
                (string.IsNullOrWhiteSpace(KorisnickoIme.Text) || ErrorLabel_KorisnickoIme.IsVisible) ||
                (string.IsNullOrWhiteSpace(Email.Text) || ErrorLabel_Email.IsVisible) ||
                (string.IsNullOrWhiteSpace(Telefon.Text) || ErrorLabel_Telefon.IsVisible) ||
                (string.IsNullOrWhiteSpace(Adresa.Text) || ErrorLabel_Adresa.IsVisible)
                )
                model.IsButtonEnabled = false;
            else
                model.IsButtonEnabled = true;
    }

    }

}