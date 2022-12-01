using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    
    public class GetDispenserslocationIdQuery : IRequest<DispenserLocationResponse>
    {
        public DispenserLocationRequest DispenserLocationRequest { get; set; }

        public GetDispenserslocationIdQuery(DispenserLocationRequest dispensersRequest)
        {
            this.DispenserLocationRequest = dispensersRequest;

        }
    }
}
