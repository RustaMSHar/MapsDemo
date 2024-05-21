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

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("speed")]
        public Speed Speed { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("system")]
        public System System { get; set; }


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


    public class Aircraft
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icao24")]
        public string Icao24 { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }

        [JsonProperty("regNumber")]
        public string RegNumber { get; set; }
    }

    public class Airline
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }
    }

    public class Departure
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }
    }

    public class Speed
    {
        [JsonProperty("horizontal")]
        public double Horizontal { get; set; }

        [JsonProperty("isGround")]
        public double IsGround { get; set; }

        [JsonProperty("vspeed")]
        public double Vspeed { get; set; }
    }

    public class System
    {
        [JsonProperty("squawk")]
        public object Squawk { get; set; }

        [JsonProperty("updated")]
        public int Updated { get; set; }
    }


}
