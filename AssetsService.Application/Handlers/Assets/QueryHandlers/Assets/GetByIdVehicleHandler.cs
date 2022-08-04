using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdVehicleHandler : IRequestHandler<GetByIdVehicleQuery, AssetsService.Core.Entities.Vehicle>
    {
        private readonly IVehicleRepository _vehicleRepo;

        public GetByIdVehicleHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<AssetsService.Core.Entities.Vehicle> Handle(GetByIdVehicleQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Vehicle)await _vehicleRepo.GetAllVehicleById(request.Id);
        }
    }
}
