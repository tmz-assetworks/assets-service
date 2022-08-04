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
    public class GetAllVehicleHandler : IRequestHandler<GetAllVechicleQuery, List<AssetsService.Core.Entities.Vehicle>>
    {
        private readonly IVehicleRepository _vechicleRepo;

        public GetAllVehicleHandler(IVehicleRepository vechicleRepository)
        {
            _vechicleRepo = vechicleRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Vehicle>> Handle(GetAllVechicleQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Vehicle>)await _vechicleRepo.GetAllVehicle();
        }
    }
}
