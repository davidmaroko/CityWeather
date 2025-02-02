using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityWeather.Models
{
    //this is the model for the response from the weather API website.
    public class WeatherApiResponse
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class Current
    {
        public double temp_c { get; set; }
        public double temp_f { get; set; }
        public double wind_kph { get; set; }
        public double wind_mph { get; set; }
        public string wind_dir { get; set; }
    }
}

