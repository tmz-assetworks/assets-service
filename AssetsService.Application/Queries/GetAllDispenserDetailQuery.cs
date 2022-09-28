using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetAllDispenserDetailQuery : IRequest<AllDispenserResponse>
    {
        public DispensersRequest DispensersRequest { get; set; }

        public GetAllDispenserDetailQuery(DispensersRequest dispensersRequest)
        {
            this.DispensersRequest = dispensersRequest;

        }
    }
}
