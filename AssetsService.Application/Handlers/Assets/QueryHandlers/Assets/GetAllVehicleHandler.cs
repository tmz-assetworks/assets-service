using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllVehicleHandler : IRequestHandler<GetAllVechicleQuery, StatusVehicleresponcse>
    {
        private readonly IVehicleRepository _vechicleRepo;

        public GetAllVehicleHandler(IVehicleRepository vechicleRepository)
        {
            _vechicleRepo = vechicleRepository;
        }
        public async Task<StatusVehicleresponcse> Handle(GetAllVechicleQuery request, CancellationToken cancellationToken)
        {
            return (StatusVehicleresponcse)await _vechicleRepo.GetAllVehicle(request.GetAllVehicleRequest);
        }
    }
}
