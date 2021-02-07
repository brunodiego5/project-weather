using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Weather
    {
        public string City { get; set; }

        public Double Temperature { get; set; }

        public string Description { get; set; }

        public string Currently { get; set; }

        public int Date { get; set; }


    }
}
