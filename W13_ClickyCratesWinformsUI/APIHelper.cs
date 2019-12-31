using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace W13_ClickyCratesWinformsUI
{
    public class APIHelper
    {
        private HttpClient apiHttpClient;

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string clickycrateswebapi = ConfigurationManager.AppSettings["clickycrateswebapiurl"];

            apiHttpClient = new HttpClient();
            apiHttpClient.BaseAddress = new Uri(clickycrateswebapi); // Defined in App.config
            apiHttpClient.DefaultRequestHeaders.Accept.Clear();
            apiHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Authenticate(string userEmail, string password)
        {
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

        public async Task<Player> GetLoggedInPlayerInfo(string token)
        {
            apiHttpClient.DefaultRequestHeaders.Clear();
            apiHttpClient.DefaultRequestHeaders.Accept.Clear();
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
    }
}
