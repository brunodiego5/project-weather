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
        [Route("")]
        public async Task<IActionResult> GetByCity(String name)
        {
            CityGetListByNameQuery city = new CityGetListByNameQuery();
            city.Name = name;
            var result = await _mediatorService.Send(city);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByGeo(Double lat, Double lon)
        {
            CityGetByIdQuery city = new CityGetByIdQuery();
            city.Id = id;
            var result = await _mediatorService.Send(city);

            return Ok(result);
        }


    }
}
