using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace W13_ClickyCratesWinformsUI
{
    public static class APIHelper
    {
        private static HttpClient apiHttpClient;
        private static string clickycrateswebapi = ConfigurationManager.AppSettings["clickycrateswebapiurl"];

        private static void InitializeClient()
        {
            if (apiHttpClient == null)   // Singleton. Only 1 instance per application
            {
                apiHttpClient = new HttpClient();
                apiHttpClient.BaseAddress = new Uri(clickycrateswebapi); // Defined in App.config
            }
            apiHttpClient.DefaultRequestHeaders.Clear();
            apiHttpClient.DefaultRequestHeaders.Accept.Clear();
        }

        public static async Task<string> Authenticate(string userEmail, string password)
        {
            InitializeClient();
            var data = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string,string>("grant_type", "password"),
                new KeyValuePair<string,string>("username", userEmail),
                new KeyValuePair<string,string>("password", password)
            });

            using(HttpResponseMessage response = await apiHttpClient.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    string token = JToken.Parse(result).SelectToken("access_token").ToString();
                    return token;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Player> GetLoggedInPlayerInfo(string token)
        {
            InitializeClient();
            apiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using(HttpResponseMessage response = await apiHttpClient.GetAsync("api/Player"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var player = await response.Content.ReadAsAsync<Player>();  // Microsoft.AspNet.WebApi.Client
                    return player;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> RegisterNewAspNetUser(AspNetUserModel newUser)
        {
            InitializeClient();
            apiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (HttpResponseMessage response = await apiHttpClient.PostAsJsonAsync<AspNetUserModel>("api/account/register", newUser))
            {
                if (response.IsSuccessStatusCode)
                {
                    string token = await Authenticate(newUser.Email, newUser.Password);
                    // get new id for registered user
                    string newId = await GetAspNetUserId(token);
                    return newId;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> GetAspNetUserId(string token)
        {
            InitializeClient();
            apiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await apiHttpClient.GetAsync("api/Account/UserId"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string aspNetUserId = await response.Content.ReadAsAsync<string>();  // ReadAsAsync in Microsoft.AspNet.WebApi.Client package
                    return aspNetUserId;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> InsertNewPlayer(Player newPlayer, string token)
        {
            InitializeClient();
            apiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiHttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await apiHttpClient.PostAsJsonAsync<Player>("api/Player/InsertNewPlayer", newPlayer))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<bool>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
