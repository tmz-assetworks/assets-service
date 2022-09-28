using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;

namespace AssetsService.Application.Queries
{
    public class GetLocationListQuery : IRequest<Locationalist>
    {
        public LocationListRequst LocationListRequst { get; set; }

        public GetLocationListQuery(LocationListRequst locationListRequst)
        {
            this.LocationListRequst = locationListRequst;

        }
    }
}
