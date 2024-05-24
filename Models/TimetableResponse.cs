using Newtonsoft.Json;

namespace MapsDemo.Models
{
    public class TimetableResponse
    {

        [JsonProperty("airline")]
        public Airline_T Airline  { get; set; }

        [JsonProperty("arrival")]
        public Arrival_T Arrival { get; set; }

        [JsonProperty("departure")]
        public Departure_T Departure { get; set; }

        [JsonProperty("flight")]
        public FlightDetails_T FlightDetails { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Airline_T
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }

    }

    public class Arrival_T
    {
        [JsonProperty("actualRunway")]
        public string ActualRunway { get; set; }

        [JsonProperty("actualTime")]
        public string ActualTime { get; set; }

        [JsonProperty("baggage")]
        public string Baggage { get; set; }

        [JsonProperty("delay")]
        public string Delay { get; set; }

        [JsonProperty("estimatedRunway")]
        public string EstimatedRunway { get; set; }

        [JsonProperty("estimatedTime")]
        public string EstimatedTime { get; set; }

        [JsonProperty("gate")]
        public string Gate { get; set; }

        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }

        [JsonProperty("scheduledTime")]
        public string ScheduledTime { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }
    }

    public class Departure_T
    {
        [JsonProperty("actualRunway")]
        public string ActualRunway { get; set; }

        [JsonProperty("actualTime")]
        public string ActualTime { get; set; }

        [JsonProperty("baggage")]
        public string Baggage { get; set; }

        [JsonProperty("delay")]
        public string Delay { get; set; }

        [JsonProperty("estimatedRunway")]
        public string EstimatedRunway { get; set; }

        [JsonProperty("estimatedTime")]
        public string EstimatedTime { get; set; }

        [JsonProperty("gate")]
        public string Gate { get; set; }

        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }

        [JsonProperty("scheduledTime")]
        public string ScheduledTime { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }
    }

    public class FlightDetails_T
    {
        [JsonProperty("iataNumber")]
        public string IataNumber { get; set; }

        [JsonProperty("icaoNumber")]
        public string IcaoNumber { get; set; }

    }
}
