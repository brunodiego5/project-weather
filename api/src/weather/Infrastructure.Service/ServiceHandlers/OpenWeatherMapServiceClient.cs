using Application.Interfaces.Services;
using Infrastructure.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Service.ServiceHandlers
{
    public class OpenWeatherMapServiceClient : IWeatherServiceClient<GetWeatherResponse>
    {
        private readonly HttpClient _httpClient;
        public OpenWeatherMapServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetWeatherResponse> GetWeatherByCityName(string name)
        {
            var responseStream = await _httpClient.GetStreamAsync(
                String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=92e34d7b6a1f0f906b27622b1b2cdddd&units=metric&lang=pt_br", name));
            var response = await JsonSerializer.DeserializeAsync<GetWeatherResponse>(responseStream);

            return response;
        }

        public async Task<GetWeatherResponse> GetWeatherByGeo(double lat, double lon)
        {
            var responseStream = await _httpClient.GetStreamAsync(
                String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=92e34d7b6a1f0f906b27622b1b2cdddd&units=metric&lang=pt_br", lat, lon));
            var response = await JsonSerializer.DeserializeAsync<GetWeatherResponse>(responseStream);

            return response;
        }
    }
}
