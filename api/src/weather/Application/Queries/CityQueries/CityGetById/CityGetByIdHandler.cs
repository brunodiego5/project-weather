using Application.Interfaces.Repositories;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.CityQuerys.CityGetById
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

        public async Task<CityDto> Handle(CityGetByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetById(request.Id);

            return _mapper.Map<City, CityDto>(city);
        }
    }
}
