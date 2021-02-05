using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Service.Contracts
{
    public class GetWeatherResponse
    {
        public string Name { get; set; }

        public Main Main { get; set; }

        public WeatherJson[] Weather { get; set; }

        public int Dt { get; set; }
    }

    public class Main
    {
        public Double Temp { get; set; }
    }

    public class WeatherJson
    {
        public string Description { get; set; }

        public string Main { get; set; }
    }
}