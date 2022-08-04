using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{


    public class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, LocationResponse>
    {
        private readonly ILocationRepository _LocationRepo;

        public UpdateLocationHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }


        public async Task<LocationResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var LocationEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Location>(request);
            if (LocationEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateLocation = _LocationRepo.UpdateAsync(LocationEntitiy, LocationEntitiy.Id);
            var mapUserResponse = Mapper.Mappers.Map<LocationResponse>(updateLocation.Result);
            return mapUserResponse;
        }

    }
}


