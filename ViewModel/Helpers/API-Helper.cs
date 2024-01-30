using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public const string BASE_URL = "https://collectionapi.metmuseum.org/public/collection/v1/search";
        
        public static async Task<List<int>> SearchArt(string query)
        {
            var url = $"{BASE_URL}?isHighlight=true&q={query}";
            List<int> result = new();
            using(HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                string json = await response.Content.ReadAsStringAsync();
                result = (List<int>)JsonConvert.DeserializeObject<IdListing>(json).objectIDs;
            }
            return result;
        }
        public static async Task<Art> GetArtInfo(int ArtID)
        {

            string url = $"https://collectionapi.metmuseum.org/public/collection/v1/objects/{ArtID}";
            Art result;
            using (HttpClient client = new())
            {
                var response = client.GetAsync(url).Result;
                string json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Art>(json);
            }

            return result;
        }
    }
}
