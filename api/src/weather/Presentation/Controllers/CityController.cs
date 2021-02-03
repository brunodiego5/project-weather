using Application.Querys.CityQuerys.CityGetById;
using Application.Querys.CityQuerys.CityGetListByName;
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
    [Route("city")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly IMediator _mediatorService;
        public CityController(ILogger<CityController> logger, IMediator mediatorService)
        {
            _logger = logger;
            _mediatorService = mediatorService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromQuery] String name)
        {
            CityGetListByNameQuery city = new CityGetListByNameQuery();
            city.Name = name;
            var result = await _mediatorService.Send(city);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            CityGetByIdQuery city = new CityGetByIdQuery();
            city.Id = id;
            var result = await _mediatorService.Send(city);

            return Ok(result);
        }


    }
}
