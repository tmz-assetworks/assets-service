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
     
        public class GetehicleListHandler : IRequestHandler<GetVechicleListQuery, VehicleListData>
        {
            private readonly IVehicleRepository _vechicleRepo;

            public GetehicleListHandler(IVehicleRepository vechicleRepository)
            {
                _vechicleRepo = vechicleRepository;
            }
            public async Task<VehicleListData> Handle(GetVechicleListQuery request, CancellationToken cancellationToken)
            {
                return (VehicleListData)await _vechicleRepo.GetVehicleList(request.GetAllVehicleRequest);
            }
        }
    }
