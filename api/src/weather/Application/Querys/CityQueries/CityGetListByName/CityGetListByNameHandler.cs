using Application.Interfaces.Repositories;
using Application.Querys.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Querys.CityQuerys.CityGetListByName
{
    public class CityGetListByNameHandler : IRequestHandler<CityGetListByNameQuery, IEnumerable<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityGetListByNameHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> Handle(CityGetListByNameQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetByName(request.Name);

            return _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cities);
        }
    }
}
