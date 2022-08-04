using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class UpdateVehicleMakeCommand : IRequest<VehicleMakeResponse>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }


        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
