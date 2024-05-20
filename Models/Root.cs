using Newtonsoft.Json;

namespace MapsDemo.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Flight
    {
        [JsonProperty("geography")]
        public Geography Geography { get; set; }

        [JsonProperty("flight")]
        public FlightDetails FlightDetails { get; set; }

        // Другие необходимые поля
    }

    public class Geography
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        public double Altitude { get; set; }
    }

    public class FlightDetails
    {
        [JsonProperty("iataNumber")]
        public string IataNumber { get; set; }

        [JsonProperty("icaoNumber")]
        public string IcaoNumber { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        // Другие необходимые поля
    }
}
