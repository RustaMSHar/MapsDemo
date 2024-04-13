﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsDemo.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Aircraft
    {
        public string iataCode { get; set; }
        public string icao24 { get; set; }
        public string icaoCode { get; set; }
        public string regNumber { get; set; }
    }

    public class Airline
    {
        public string iataCode { get; set; }
        public string icaoCode { get; set; }
    }

    public class Arrival
    {
        public string iataCode { get; set; }
        public string icaoCode { get; set; }
    }

    public class Departure
    {
        public string iataCode { get; set; }
        public string icaoCode { get; set; }
    }

    public class Flight
    {
        public string iataNumber { get; set; }
        public string icaoNumber { get; set; }
        public string number { get; set; }
    }

    public class Geography
    {
        public int altitude { get; set; }
        public int direction { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Root
    {
        public Aircraft aircraft { get; set; }
        public Airline airline { get; set; }
        public Arrival arrival { get; set; }
        public Departure departure { get; set; }
        public Flight flight { get; set; }
        public Geography geography { get; set; }
        public Speed speed { get; set; }
        public string status { get; set; }
        public System system { get; set; }
    }

    public class Speed
    {
        public double horizontal { get; set; }
        public int isGround { get; set; }
        public int vspeed { get; set; }
    }

    public class System
    {
        public object squawk { get; set; }
        public int updated { get; set; }
    }
}
