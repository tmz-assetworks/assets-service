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
    public class GetLocationsDispenserDetailsQuery : IRequest<PagedList<Core.Response.LocationsDispenserDetails>>
    {
        public LocationDispenserRequest LocationDispenserRequest { get; set; }
        public GetLocationsDispenserDetailsQuery(LocationDispenserRequest locationDispenserRequest)
        {
            this.LocationDispenserRequest = locationDispenserRequest;
        }
    }
}