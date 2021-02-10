using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WeatherQueries.WeatherGetByGeo
{
    public class WeatherGetByGeoQuery: IRequest<WeatherDto>
    {
        public Double Lat { get; set; }

        public Double Lon { get; set; }
    }
}
