using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Service.ServiceHandlers
{
    public class OpenWeatherMapServiceClient : IWeatherServiceClient
    {
        private readonly HttpClient _httpClient;

        private readonly IMapper _mapper;

        public OpenWeatherMapServiceClient(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;

            _mapper = mapper;
        }

        public async Task<Weather> GetWeatherByCityName(string name)
        {
            var responseStream = await _httpClient.GetStreamAsync(
                String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=92e34d7b6a1f0f906b27622b1b2cdddd&units=metric&lang=pt_br", name));
            var response = await JsonSerializer.DeserializeAsync<GetWeatherResponse>(responseStream);

            return _mapper.Map<GetWeatherResponse, Weather>(response);
        }

        public async Task<Weather> GetWeatherByGeo(double lat, double lon)
        {
            var responseStream = await _httpClient.GetStreamAsync(
                String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=92e34d7b6a1f0f906b27622b1b2cdddd&units=metric&lang=pt_br", lat, lon));
            var response = await JsonSerializer.DeserializeAsync<GetWeatherResponse>(responseStream);

            return _mapper.Map<GetWeatherResponse, Weather>(response);
        }
    }
}
