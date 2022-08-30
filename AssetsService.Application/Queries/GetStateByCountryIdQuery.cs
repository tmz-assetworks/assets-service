using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetStateByCountryIdQuery : IRequest<List<StateData>>
    {

         public long Id{get ; set;}
        public GetStateByCountryIdQuery(long id)
        {
            Id = id;
        }

    }
}