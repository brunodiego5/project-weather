using Application.Interfaces.Services;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.WeatherQueries.WeatherGetByGeo
{
    public class WeatherGetByGeoHandler : IRequestHandler<WeatherGetByGeoQuery, WeatherDto>
    {
        private readonly IWeatherServiceClient _weatherServiceClient;

        private readonly IMapper _mapper;

        public WeatherGetByGeoHandler(IWeatherServiceClient weatherServiceClient, IMapper mapper)
        {
            _weatherServiceClient = weatherServiceClient;

            _mapper = mapper;
        }

        public async Task<WeatherDto> Handle(WeatherGetByGeoQuery request, CancellationToken cancellationToken)
        {
            var weather = await _weatherServiceClient.GetWeatherByGeo(request.Lat, request.Lon);

            return _mapper.Map<Weather, WeatherDto>(weather);
        }
    }
}
