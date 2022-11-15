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
          
            AssetsService.Core.Entities.Location LocationEntitiy=new Core.Entities.Location(){
                Id=request.Id,
                IsActive=request.IsActive,
                ModifiedBy = request.UserId
            };
         
            var updatelocation = _LocationRepo.DeleteLocationAsync(LocationEntitiy, LocationEntitiy.Id,"Location");
            var mapLocationResponse = Mapper.Mappers.Map<LocationResponse>(updatelocation.Result);
            return mapLocationResponse;
        }
    }
}