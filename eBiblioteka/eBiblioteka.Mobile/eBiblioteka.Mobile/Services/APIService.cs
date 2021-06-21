using eBiblioteka.Model;
using eBiblioteka.Model.Requests;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eBiblioteka.Mobile.Services
{
    class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

#if DEBUG
        private string APIUrl = "http://localhost:36195/api";
#endif
#if RELEASE
        private string APIUrl = "http://localhost:36195/api";

#endif

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{APIUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani!", "OK");
                }
                if (ex.Call.Response.StatusCode == 403)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Nemate permisije za pristup!", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{APIUrl}/{_route}/{id}";


            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autentificirani!", "OK");

                }
                if (ex.Call.Response.StatusCode == 403)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Nemate permisije za pristup!", "OK");

                }
                throw;
            }

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{APIUrl}/{_route}";


            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{APIUrl}/{_route}/{id}";


                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }

        }

        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{APIUrl}/{_route}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return false;
            }

        }


        public async Task<Model.Clan> Authenticate(AuthenticationRequest request)
        {
            try
            {
                var url = $"{APIUrl}/Clan/Authenticate";
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<Model.Clan>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response.StatusCode == 400)
                {
                    throw new Exception("Korisnički nalog je deaktiviran. Molimo kontaktirajte administratora.");
                }

                if (ex.Call.Response.StatusCode == 401)
                {
                    throw new Exception("Pogrešno korisničko ime ili lozinka !");
                }
                if (ex.Call.Response.StatusCode == 403)
                {
                    throw new Exception("Nemate permisije za pristup !!!" + Environment.NewLine + "Mobilni dio aplikacije je namijenjen samo za članove !");
                }
                throw;
            }
        }

        public async Task<T> UpdatePhoto<T>(int id, ClanUpdatePhotoRequest request)
        {

            try
            {
                var url = $"{APIUrl}/Clan/UpdatePhoto/{id}";
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }
        }

        public async Task<T> UpdatePassword<T>(int id, ClanUpdatePasswordRequest request)
        {

            try
            {
                var url = $"{APIUrl}/Clan/UpdatePassword/{id}";
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }
        }

        public async Task<T> GetCounter<T>(int id)
        {

            try
            {
                var url = $"{APIUrl}/Clan/GetCounter/{id}";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }
        }

        public async Task<T> Preporuka<T>(int id)
        {

            try
            {
                var url = $"{APIUrl}/Preporuka/Preporuka/{id}";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{string.Join(",", error.Value)}");

                }

                await Application.Current.MainPage.DisplayAlert("Greška", stringBuilder.ToString(), "OK");

                return default(T);
            }
        }
    }
}
