using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.CityQuerys.CityGetListByName
{
    public class CityGetListByNameQuery: IRequest<IEnumerable<CityDto>>
    {
        public string Name { get; set; }
    }
}
