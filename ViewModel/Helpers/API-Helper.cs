using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using museum_api.Model;
using Newtonsoft.Json;

namespace museum_api.ViewModel.Helpers
{
    public class API_Helper
    {
        public const string BASE_URL = "https://collectionapi.metmuseum.org/public/collection/v1/objects/436535";
        public static async Task<Art> GetArt(string query)
        {

            string url = BASE_URL;
            Art result;
            using (HttpClient client = new())
            {
                var response = client.GetAsync(url).Result;
                string json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Art>(json);
            }

            return result;
        }

        //public static async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        //{
        //    CurrentConditions? conditions = new();

        //    string url = BASE_URL + string.Format(CURRENT_CONDITIONS_ENDPOINT, cityKey, API_KEY);

        //    using (HttpClient client = new())
        //    {
        //        var response = client.GetAsync(url).Result;
        //        string json = await response.Content.ReadAsStringAsync();

        //        conditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
        //    }

        //    return conditions;
        //}
    }
}
