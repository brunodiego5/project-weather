using Application.Querys.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querys.Profiles
{
    public class CityDtoProfile : Profile
    {
        public CityDtoProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
