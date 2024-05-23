using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MapsDemo.Models
{
    public class AirlineInfo
    {
        [JsonProperty("codeIataAirline")]
        public string CodeIataAirline { get; set; }

        [JsonProperty("nameAirline")]
        public string NameAirline { get; set; }

        // Другие необходимые поля
    }
}
