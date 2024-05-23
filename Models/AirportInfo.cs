using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsDemo.Models;

namespace MapsDemo.Models
{

    public class AirportInfo
    {
        [JsonProperty("codeIataAirport")]
        public string CodeIataAirport { get; set; }

        [JsonProperty("nameAirport")]
        public string NameAirport { get; set; }

        // Другие необходимые поля
    }
}
