using AppPlaces.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppPlaces.Services
{
    public class PlacesApi
    {
        readonly string _api_base_url = "https://comp-nuvem.azurewebsites.net/place";

        public async Task<List<Place>> GetAllPlacesAsync()
        {
            //grab json from server
            var json = await GetJsonData(_api_base_url);

            //Deserialize json
            var places = JsonConvert.DeserializeObject<List<Place>>(json);

            //return the items
            return places;
        }

        async Task<string> GetJsonData(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return json;
            }
        }
    }
}
