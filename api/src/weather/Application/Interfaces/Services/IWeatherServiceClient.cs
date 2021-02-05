using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IWeatherServiceClient
    {
        Task<Weather> GetWeatherByCityName(string name);

        Task<Weather> GetWeatherByGeo(Double lat, Double lon);
    }
}
