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

namespace Application.Queries.WeatherQueries.WeatherGetByCity
{
    public class WeatherGetByCityHandler : IRequestHandler<WeatherGetByCityQuery, WeatherDto>
    {
        private readonly IWeatherServiceClient _weatherServiceClient;

        private readonly IMapper _mapper;

        public WeatherGetByCityHandler(IWeatherServiceClient weatherServiceClient, IMapper mapper)
        {
            _weatherServiceClient = weatherServiceClient;

            _mapper = mapper;
        }

        public async Task<WeatherDto> Handle(WeatherGetByCityQuery request, CancellationToken cancellationToken)
        {
            var weather = await _weatherServiceClient.GetWeatherByCityName(request.City);

            return _mapper.Map<Weather, WeatherDto>(weather);
        }
    }
}
