using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weatherapp.Model;

namespace Weatherapp.ViewModel.Helper
{
    class AccuWeatherHelper
    {
        public const string BASEURL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CONDITIONAL_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";
            public const string API_KEY = "ft9Cn66cQvV8TGF5IwuXesngrAgsQHbu";
        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();
            string url = BASEURL + String.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, query);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }
            return cities;
        }
        public static async Task<Currentcondition> GetCurrentCondition(string citykey)
        {
           Currentcondition citystate = new Currentcondition();
            string url = BASEURL + String.Format(CONDITIONAL_ENDPOINT,  citykey , API_KEY);
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                citystate = (JsonConvert.DeserializeObject<List<Currentcondition>>(json)).FirstOrDefault();

            }
            return citystate;
        }

    }
       
}
