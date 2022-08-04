using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class GetDispenserByChargeBoxIdQuery : IRequest<Dispenser>
    {

        public string ChargeBoxId{get ; set;}
        public GetDispenserByChargeBoxIdQuery(string chargeBoxId)
        {
            ChargeBoxId = chargeBoxId;
        }
    }
}