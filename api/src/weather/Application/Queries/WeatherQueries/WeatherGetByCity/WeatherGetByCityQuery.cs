using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WeatherQueries.WeatherGetByCity
{
    public class WeatherGetByCityQuery: IRequest<WeatherDto>
    {
        public string City { get; set; }
    }
}
