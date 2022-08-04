using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class DeleteVehicleMakeCommand : IRequest<VehicleMakeResponse>
    {
        public long Id { get; set; }

        public bool IsActive { get; set; }
    }
}
