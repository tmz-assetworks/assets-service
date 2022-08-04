using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdVehicleMakeQuery : IRequest<VehicleMake>
    {
        public long Id { get; set; }
        public GetByIdVehicleMakeQuery(int id)
        {
            Id = id;
        }
    }
}
