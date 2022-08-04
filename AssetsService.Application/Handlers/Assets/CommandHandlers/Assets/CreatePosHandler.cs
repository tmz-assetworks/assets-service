using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreatePosHandler : IRequestHandler<CreatePosCommand, PosResponse>
    {
        private readonly IPosRepository _posRepo;

        public CreatePosHandler(IPosRepository posRepository)
        {
            _posRepo = posRepository;
        }
        public async Task<PosResponse> Handle(CreatePosCommand request, CancellationToken cancellationToken)
        {
            var posEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Pos>(request);
            if (posEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addPosResponse = await _posRepo.AddAsync(posEntitiy);
            var mapPosResponse = Mapper.Mappers.Map<PosResponse>(addPosResponse);
            return mapPosResponse;
        }
    }
}
