using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class IsActiveVehicleCommand : IRequest<VehicleResponse>
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
    }
}

