using AssetsService.Core.Entities;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Queries
{
    public class ValidateChargerIdQuery : IRequest<ChargerResponse>
    {

        public string ChargeBoxId { get; set; }
        public ValidateChargerIdQuery(string chargeBoxId)
        {
            ChargeBoxId = chargeBoxId;
        }
    }
}