using AssetsService.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetByIdVehicleQuery : IRequest<Vehicle>
    {
        public long Id { get; set; }
        public GetByIdVehicleQuery(int id)
        {
            Id = id;
        }
    }
}
