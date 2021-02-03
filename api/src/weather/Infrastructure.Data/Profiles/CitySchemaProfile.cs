using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Profiles
{
    public class CitySchemaProfile : Profile
    {
        public CitySchemaProfile()
        {
            CreateMap<CitySchema, City>();
        }
    }
}
