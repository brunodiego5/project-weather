using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class WeatherDto
    {
        public String City { get; set; }

        public Double Temperature { get; set; }

        public String Description { get; set; }

        public String Currently { get; set; }

        public Double Date { get; set; }
    }
}
