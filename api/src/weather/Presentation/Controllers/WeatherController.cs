using Application.Models;
using Application.Querys.CityQueries.WeatherGetByCity;
using Application.Querys.CityQueries.WeatherGetByGeo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IMediator _mediatorService;
        public WeatherController(ILogger<WeatherController> logger, IMediator mediatorService)
        {
            _logger = logger;
            _mediatorService = mediatorService;
        }

        [HttpGet]
        [Route("bycity")]
        public async Task<IActionResult> GetByCity([FromQuery] String name)
        {
            WeatherGetByCityQuery weather = new WeatherGetByCityQuery();
            weather.City = name;
            var result = await _mediatorService.Send(weather);

            return Ok(result);
        }

        [HttpGet]
        [Route("bygeo")]
        public async Task<IActionResult> GetByGeo([FromQuery] Double lat, [FromQuery] Double lon)
        {
            WeatherGetByGeoQuery weather = new WeatherGetByGeoQuery();
            weather.Lat = lat;
            weather.Lon = lon;
            var result = await _mediatorService.Send(weather);

            return Ok(result);
        }


    }
}
