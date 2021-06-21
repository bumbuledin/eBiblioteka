using eBiblioteka.Mobile.Models;
using eBiblioteka.Mobile.Services;
using eBiblioteka.Mobile.Views;
using eBiblioteka.Model.Requests;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.ViewModels
{

    public class PaymentGatwayViewModel : BaseViewModel
    {

        private APIService _uplataService = new APIService("Uplata");
        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private Model.Clan _clan = null;
        private readonly string StripeTestApiKey = "pk_test_51J2kbSK6pAPfzeXy1X1hy2yxGtUa8kxx7O6BZfmCnxERHG977Jl6v6ZdciQ6oP4YxNOlzoXfJXeouH4BuHO85iiP00a7H8nGAP";
        private bool _isCarcValid;
        private bool _isButtonEnabled;
        private bool _isTransectionSuccess;

        public PaymentGatwayViewModel()
        {
            Title = "Online uplata";
            CreditCardModel = new CreditCardModel();
            InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Pay());
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public ICommand InitCommand { get; set; } 

        public ICommand SubmitCommand { get; set; }



        public async Task Init()
        {
            if(_clan == null)
            {
                _clan = await _uplataService.Authenticate(new AuthenticationRequest() { KorisnickoIme = APIService.Username, Password = APIService.Password });
            }
        }

        public async Task Pay()
        {
            IsButtonEnabled = false;
            IsTransectionSuccess = false;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            IsButtonEnabled = false;

            try
            {
                await Task.Run(async () =>
                {
                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška","Neispravna kartica!", "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    var uplata = new UplataUpsertRequest()
                    {
                        ClanId = _clan.ClanId,
                        DatumUplate = DateTime.Now,
                        IznosUplate = new decimal(25.00),
                        VrstaUplateId = 1
                    };

                    var response = await _uplataService.Insert<Model.Uplata>(uplata);

                    if(response != null)
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Informacija", "Uspješno ste uplatili članarinu.", "OK");
                        if(ViewModelContainer.UplateViewModel != null)
                            await ViewModelContainer.UplateViewModel.NovaUplataInit();

                        await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
                    }            

                }
                else
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Greška", "Dogodila se greška prilikom plaćanja.", "OK");
                }
            }
        }

        public bool MakePayment(string token)
        {
            try
            {
                StripeConfiguration.SetApiKey("sk_test_51J2kbSK6pAPfzeXyDebmFn6E0mz3tiZVTRN9HNdgdytQBcHdNAVTGjB6YtDDvbAI7bUTPrFjB7nw8GsYramb3nHI00bqTeYVRd");
                var options = new ChargeCreateOptions
                {
                    Amount = (long)2500.00,
                    Currency = "EUR",
                    Description = "Test za online plaćanje",

                    StatementDescriptor = "Test",
                    Capture = true,
                    ReceiptEmail = "rs2seminarski@mail.com",
                    Source = stripeToken.Id
                };

                //Make payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string CreateToken()
        {
            try
            {
                StripeConfiguration.SetApiKey(StripeTestApiKey);
                var service = new ChargeService();
                var tokenoptiion = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = _creditCardModel.Number,
                        ExpYear = _creditCardModel.ExpYear,
                        ExpMonth = _creditCardModel.ExpMonth,
                        Cvc = _creditCardModel.Cvc,
                        Name = "Test" + _clan.ClanId,
                        AddressLine1 = "xyz",
                        AddressLine2 = "lmn",
                        AddressCity = "Starmo",
                        AddressState = _clan.Adresa,
                        AddressCountry = "BiH",
                        AddressZip = "82332",
                        Currency = "EUR"
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(tokenoptiion);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}