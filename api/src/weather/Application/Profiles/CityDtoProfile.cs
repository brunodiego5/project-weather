using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles
{
    public class CityDtoProfile : Profile
    {
        public CityDtoProfile()
        {
            CreateMap<City, CityDto>();
        }
    }
}
