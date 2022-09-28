using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetLocationDispensersQuery : IRequest<PagedList<DispenserByLocationsResponse>>
    {
        public LocationDispensersRequest _LocationDispensersRequest = null;
        public GetLocationDispensersQuery(LocationDispensersRequest dispensersDetailRequest)
        {
            this._LocationDispensersRequest = dispensersDetailRequest;
        }
    }


}
