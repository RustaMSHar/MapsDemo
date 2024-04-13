using MapsDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MapsDemo.Services
{
    public class ApiService
    {
        
        public async void GetTracker()
        {
            var httpClient = new HttpClient();
            var ApiKey = "2d83a2-a21b99";
            var response = await httpClient.GetStringAsync(string.Format("https://aviation-edge.com/v2/public/flights?key={0}&limit=10", ApiKey));
            JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
