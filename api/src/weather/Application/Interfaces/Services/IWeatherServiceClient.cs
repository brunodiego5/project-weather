using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IWeatherServiceClient<Response>
    {
        Task<Response> GetWeatherByCityName(string name);

        Task<Response> GetWeatherByGeo(Double lat, Double lon);
    }
}
