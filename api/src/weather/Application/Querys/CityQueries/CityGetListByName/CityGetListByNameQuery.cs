using Application.Querys.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querys.CityQuerys.CityGetListByName
{
    public class CityGetListByNameQuery: IRequest<IEnumerable<CityDto>>
    {
        public string Name { get; set; }
    }
}
