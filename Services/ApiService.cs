using MapsDemo.Models;
using Newtonsoft.Json;

namespace MapsDemo.Services
{
    public static class ApiService
    {

        public static async Task<List<Flight>> GetTracker()
        {
            var httpClient = new HttpClient();
            var ApiKey = "2d83a2-a21b99";
            var response = await httpClient.GetStringAsync($"https://aviation-edge.com/v2/public/flights?key={ApiKey}&limit=10");
            return JsonConvert.DeserializeObject<List<Flight>>(response);
        }
    }
}
