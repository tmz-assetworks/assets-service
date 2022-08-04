using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, LocationResponse>
    {
        private readonly ILocationRepository _locationRepo;

        public CreateLocationHandler(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }
        public async Task<LocationResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var LocationEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Location>(request);
            if (LocationEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            LocationEntitiy.IsActive = true;//set newly created customer as a active
            var addLocationResponse = await _locationRepo.AddAsync(LocationEntitiy);
            var mapLocationResponse = Mapper.Mappers.Map<LocationResponse>(addLocationResponse);
            return mapLocationResponse;
        }

    }
}