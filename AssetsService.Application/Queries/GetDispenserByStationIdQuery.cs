using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetDispenserByStationIdQuery : IRequest<Dispenser>
    {

        public long StationId { get; set; }
        public GetDispenserByStationIdQuery(long stationId)
        {
            StationId = stationId;
        }
    }
}