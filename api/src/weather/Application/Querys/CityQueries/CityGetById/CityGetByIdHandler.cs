using Application.Interfaces.Repositories;
using Application.Querys.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Querys.CityQuerys.CityGetById
{
    public class CityGetByIdHandler : IRequestHandler<CityGetByIdQuery, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityGetByIdHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<CityDto> Handle(CityGetByIdQuery request, CancellationToken cancellationToken)
        {
            var city = _cityRepository.GetById(request.Id);

            CityDto cityDto = _mapper.Map<CityDto>(city);

            return Task.FromResult(cityDto);
        }
    }
}
