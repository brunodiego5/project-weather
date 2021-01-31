using Application.Querys.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querys.CityQuerys.CityGetById
{
    public class CityGetByIdQuery: IRequest<CityDto>
    {
        public int Id;
    }
}
