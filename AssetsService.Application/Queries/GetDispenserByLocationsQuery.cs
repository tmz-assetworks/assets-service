using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetDispenserByLocationsQuery : IRequest<List<Core.Response.DispenserByLocationsResponse>>
    {
        public List<long> StationId { get; set; }
        public GetDispenserByLocationsQuery(List<long> stationId)
        {
            StationId = stationId;
        }
    }
}
