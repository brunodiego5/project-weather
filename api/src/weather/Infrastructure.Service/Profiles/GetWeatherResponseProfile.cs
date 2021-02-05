using AutoMapper;
using Domain.Entities;
using Infrastructure.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Profiles
{
    public class GetWeatherResponseProfile : Profile
    {
        public GetWeatherResponseProfile()
        {
            CreateMap<GetWeatherResponse, Weather>()
                .ForMember(d => d.City, opt => opt.MapFrom(x => x.Name))
                .ForMember(d => d.Temperature, opt => opt.MapFrom(x => x.Main.Temp))
                .ForMember(d => d.Description, opt => opt.MapFrom(x => x.Weather[0].Description))
                .ForMember(d => d.Currently, opt => opt.MapFrom(x => x.Weather[0].Main))
                .ForMember(d => d.Date, opt => opt.MapFrom(x => x.Dt));
        }
    }
}
