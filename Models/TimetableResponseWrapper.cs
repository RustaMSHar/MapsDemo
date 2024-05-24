using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDemo.Models
{
    public class TimetableResponseWrapper
    {
        [JsonProperty("timetable")]
        public List<TimetableResponse> Timetable { get; set; }
    }

}
