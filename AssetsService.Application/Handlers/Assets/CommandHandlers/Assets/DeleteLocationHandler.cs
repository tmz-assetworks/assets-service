using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Commands.Assets;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class DeleteLocationHandler : IRequestHandler<DeleteLocationCommand, LocationResponse>
    {
         private readonly ILocationRepository _LocationRepo;

        public DeleteLocationHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        public async Task<LocationResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var LocationEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Location>(request);
            if (LocationEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updatelocation = _LocationRepo.DeleteLocationAsync(LocationEntitiy, LocationEntitiy.Id,"Location");
            var mapLocationResponse = Mapper.Mappers.Map<LocationResponse>(updatelocation.Result);
            return mapLocationResponse;
        }
    }
}