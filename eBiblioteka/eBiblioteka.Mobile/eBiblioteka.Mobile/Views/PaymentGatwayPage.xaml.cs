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
    public partial class PaymentGatwayPage : ContentPage
    {
        private PaymentGatwayViewModel model = null;
        public PaymentGatwayPage()
        {
            InitializeComponent();
            BindingContext = model = new PaymentGatwayViewModel();
        }

        protected async override void OnAppearing()
        {
            await model.Init();
            ErrorLabel_CardNumber.IsVisible = false;
            ErrorLabel_Month.IsVisible = false;
            ErrorLabel_Year.IsVisible = false;
            ErrorLabel_CVC.IsVisible = false;

            model.IsButtonEnabled = false;

        }
        private void CardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CardNumber.Text.Length > 16)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                CardNumber.Text = RemoveLastCharacter(CardNumber.Text);
                ErrorLabel_CardNumber.Text = "Format nije ispravan!";
            }
            else if (CardNumber.Text.Length < 1)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                ErrorLabel_CardNumber.Text = "Obavezno polje!";

            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;

            }
            EnableSubmitButton();
        }

        private void CardNumber_Unfocused(object sender, FocusEventArgs e)
        {
           
            if (CardNumber.Text == null || CardNumber.Text.Length > 16 || CardNumber.Text.Length < 16)
            {
                ErrorLabel_CardNumber.IsVisible = true;
                if(CardNumber.Text == null || CardNumber.Text == string.Empty)
                    ErrorLabel_CardNumber.Text = "Obavezno polje!";
                else
                    ErrorLabel_CardNumber.Text = "Kartica mora sadržavati 16 brojeva!";

                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_CardNumber.IsVisible = false;
            }
            EnableSubmitButton();

        }



        private void Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Month.Text.Length < 1)
            {
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Obavezno polje!";
            }
            else if (Month.Text.Length > 2)
            {
                Month.Text = RemoveLastCharacter(Month.Text);
                ErrorLabel_Month.IsVisible = true;
                ErrorLabel_Month.Text = "Neispravan fromat!";
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
                EnableSubmitButton();
            }
            EnableSubmitButton();
        }

        private void Month_Unfocused(object sender, FocusEventArgs e)
        {
            if (Month.Text == null || Month.Text.Length > 2 || Month.Text.Length < 1)
            {
                ErrorLabel_Month.IsVisible = true;
                if (Month.Text == null || Month.Text == string.Empty)
                    ErrorLabel_Month.Text = "Obavezno polje!";
                else
                    ErrorLabel_Month.Text = "Neisprvan format!";

                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_Month.IsVisible = false;
            }
            EnableSubmitButton();
        }


        private void Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Year.Text.Length < 1)
            {
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Obavezno polje!";
            }
            else if (Year.Text.Length > 4)
            {
                Year.Text = RemoveLastCharacter(Year.Text);
                ErrorLabel_Year.IsVisible = true;
                ErrorLabel_Year.Text = "Neispravan fromat!";
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
                EnableSubmitButton();
            }
            EnableSubmitButton();
        }

        private void Year_Unfocused(object sender, FocusEventArgs e)
        {
            if (Year.Text == null || Year.Text.Length != 4 )
            {
                ErrorLabel_Year.IsVisible = true;
                if (Year.Text == null || Year.Text == string.Empty)
                    ErrorLabel_Year.Text = "Obavezno polje!";
                else
                    ErrorLabel_Year.Text = "Neisprvan format!";

                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_Year.IsVisible = false;
            }
            EnableSubmitButton();
        }


        private void CVC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CVC.Text.Length < 1)
            {
                ErrorLabel_CVC.IsVisible = true;
                ErrorLabel_CVC.Text = "Obavezno polje!";
            }
            else if (CVC.Text.Length > 3)
            {
                CVC.Text = RemoveLastCharacter(CVC.Text);
                ErrorLabel_CVC.IsVisible = true;
                ErrorLabel_CVC.Text = "Neispravan fromat!";
            }
            else
            {
                ErrorLabel_CVC.IsVisible = false;
                EnableSubmitButton();
            }
            EnableSubmitButton();
        }

        private void CVC_Unfocused(object sender, FocusEventArgs e)
        {
            if (CVC.Text == null || CVC.Text.Length != 3)
            {
                ErrorLabel_CVC.IsVisible = true;
                if (CVC.Text == null || CVC.Text == string.Empty)
                    ErrorLabel_CVC.Text = "Obavezno polje!";
                else
                    ErrorLabel_CVC.Text = "Neisprvan format!";

                EnableSubmitButton();
            }
            else
            {
                ErrorLabel_CVC.IsVisible = false;
            }
            EnableSubmitButton();
        }


        private void EnableSubmitButton()
        {
            if 
            (
            (CardNumber.Text == null || CardNumber.Text == string.Empty || ErrorLabel_CardNumber.IsVisible) || 
            (Month.Text == null || Month.Text == string.Empty || ErrorLabel_Month.IsVisible) || 
            (Year.Text == null || Year.Text == string.Empty || ErrorLabel_Year.IsVisible) ||
            (CVC.Text == null || CVC.Text == string.Empty || ErrorLabel_CVC.IsVisible)
            ) 
            {
                model.IsButtonEnabled = false;
            }

            else
            {
                model.IsButtonEnabled = true;
            }
        }
        private string RemoveLastCharacter(string str)
        {
            int l = str.Length;
            string text = str.Remove(l - 1, 1);
            return text;
        }

    }
}