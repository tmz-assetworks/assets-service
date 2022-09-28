using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllModelListHandler : IRequestHandler<GetAllModelListQuery, List<ModelList>>
    {
        private readonly IModelRepository _ModelRepo;

        public GetAllModelListHandler(IModelRepository ModelRepository)
        {
            _ModelRepo = ModelRepository;
        }
        public async Task<List<ModelList>> Handle(GetAllModelListQuery request, CancellationToken cancellationToken)
        {
            return (List<ModelList>)await _ModelRepo.GetAllModelList();
        }
    }
}
