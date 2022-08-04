using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetDispenserByLocationIdQuery : IRequest<List<AssetsService.Core.Responses.Assets.DispenserByLocationIdResponse>>
    {

       public long LocationId { get; set; }
        public GetDispenserByLocationIdQuery(long locationId)
        {
            LocationId = locationId;
        }
    }
}