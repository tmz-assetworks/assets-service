using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetsService.Core.Response.GetDispenserStatusResponse;

namespace AssetsService.Application.Queries
{
    public class GetDispenserStatusQuery : IRequest<List<AssetsService.Core.Entities.DispenserStatus>>
    {
        public DispenserStatusRequest statusRequest { get; set; }
        public GetDispenserStatusQuery(DispenserStatusRequest _statusRequest)
        {
            this.statusRequest = _statusRequest;
        }
    }
}
