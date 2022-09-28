using AssetsService.Core.Entities;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdVehicleQuery : IRequest<VehicleDTO>
    {
        public long Id { get; set; }
        public GetByIdVehicleQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
