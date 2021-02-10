using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CityQuerys.CityGetById
{
    public class CityGetByIdQuery: IRequest<CityDto>
    {
        public int Id;
    }
}
