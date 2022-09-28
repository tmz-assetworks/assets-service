using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllMakeMasterListHandler : IRequestHandler<GetAllMakeMasterListQuery, List<MakeMasterList>>
    {
        private readonly IMakeMasterRepository _MakeMasterRepo;

        public GetAllMakeMasterListHandler(IMakeMasterRepository MakeMasterRepository)
        {
            _MakeMasterRepo = MakeMasterRepository;
        }
        public async Task<List<MakeMasterList>> Handle(GetAllMakeMasterListQuery request, CancellationToken cancellationToken)
        {
            return (List<MakeMasterList>)await _MakeMasterRepo.GetAllMakeMasterList();
        }
    }
}
