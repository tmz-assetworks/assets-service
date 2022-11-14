using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetAllSwitchGearQuery : IRequest<AllSwitchGearResponse>
    {
        public SwitchGearRequest SwitchGearRequest { get; set; }

        public GetAllSwitchGearQuery(SwitchGearRequest switchGearRequest)
        {
            this.SwitchGearRequest = switchGearRequest;

        }
    }
}
