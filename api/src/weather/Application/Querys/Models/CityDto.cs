using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querys.Models
{
    public class CityDto
    {
        public CityDto(string country, string name)
        {
            Country = country;
            Name = name;
        }

        public string Country { get; set; }

        public string Name { get; set; }
    }
}
