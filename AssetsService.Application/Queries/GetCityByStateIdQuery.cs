using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetCityByStateIdQuery : IRequest<List<CityData>>
    {

         public long Id{get ; set;}
        public GetCityByStateIdQuery(long id)
        {
            Id = id;
        }

    }
}