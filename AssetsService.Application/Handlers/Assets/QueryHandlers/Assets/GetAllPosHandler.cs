using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetAllPosHandler : IRequestHandler<GetAllPosQuery, List<AssetsService.Core.Entities.Pos>>
    {
        private readonly IPosRepository _posRepo;

        public GetAllPosHandler(IPosRepository posRepository)
        {
            _posRepo = posRepository;
        }
        public async Task<List<AssetsService.Core.Entities.Pos>> Handle(GetAllPosQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.Pos>)await _posRepo.GetAllPos();
        }
    }
}
