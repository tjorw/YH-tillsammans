using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tillsammans.Auth;
using Xamarin.Forms;

namespace tillsammans.mobile.Services
{
    public class AuthService : IAuthService
    {

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            var url = $"api/auth/signin/{request.Name}";

            string json = JsonConvert.SerializeObject(request);
            StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await getClient().PostAsync(url, payload);

            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var responseObject = JsonConvert.DeserializeObject<SignInResponse>(content);

            return responseObject;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            var url = $"api/auth/signup/{request.Name}";

            string json = JsonConvert.SerializeObject(request);
            StringContent payload = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await getClient().PostAsync(url, payload);

            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            var responseObject = JsonConvert.DeserializeObject<SignUpResponse>(content);

            return responseObject;
        }

        private HttpClient getClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(getUrl());
            client.DefaultRequestHeaders.Add("x-functions-key", Constants.API_KEY);
            return client;
        }

        private string getUrl()
        {
            if(string.IsNullOrWhiteSpace(Constants.API_BASEURL))
            {
                if (Device.RuntimePlatform == Device.Android) return Constants.API_BASEURL_DEV_ANDROID;
                if (Device.RuntimePlatform == Device.iOS) return Constants.API_BASEURL_DEV_IOS;
                if (Device.RuntimePlatform == Device.UWP) return Constants.API_BASEURL_DEV_UWP;
            }

            return Constants.API_BASEURL;
        }
    }
}
