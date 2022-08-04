using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreateCableHandler : IRequestHandler<CreateCableCommand, CableResponse>
    {
        private readonly ICableRepository _cableRepo;

        public CreateCableHandler(ICableRepository cableRepository)
        {
            _cableRepo = cableRepository;
        }
        public async Task<CableResponse> Handle(CreateCableCommand request, CancellationToken cancellationToken)
        {
            var cableEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Cable>(request);
            if (cableEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            cableEntitiy.IsActive = true;
            var addCableResponse = await _cableRepo.AddAsync(cableEntitiy);
            var mapCableResponse = Mapper.Mappers.Map<CableResponse>(addCableResponse);
            return mapCableResponse;
        }
    }
}
