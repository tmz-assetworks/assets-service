
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdPosHandler : IRequestHandler<GetByIdPosQuery, AssetsService.Core.Entities.Pos>
    {
        private readonly IPosRepository _posRepo;

        public GetByIdPosHandler(IPosRepository posRepository)
        {
            _posRepo = posRepository;
        }

     public async Task<AssetsService.Core.Entities.Pos> Handle(GetByIdPosQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.Pos)await _posRepo.GetByIdPos(request.Id);
        }

        
    }

    

}
