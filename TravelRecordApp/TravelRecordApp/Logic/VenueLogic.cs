using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using RestSharp;
using Newtonsoft.Json;
namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public static async Task<VenueRoot> GetVenues(double latitude, double longitude)
        {
            List<VenueRoot> venues = new List<VenueRoot>();
            var url = VenueRoot.GenerateURL(latitude, longitude);
            var options = new RestClientOptions(url);
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "fsq32Mu4lCrl1SBpb8Xz2l5rss1XzO0XLR1RadOEEcOhFfw=");
            var response = await client.GetAsync(request);
            var json = response.Content;
            var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);
            return venueRoot;
        }
    }
}
