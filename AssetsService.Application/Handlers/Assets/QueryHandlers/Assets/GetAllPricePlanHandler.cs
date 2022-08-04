using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetAllPricePlanHandler : IRequestHandler<GetAllPricePlanQuery, List<AssetsService.Core.Entities.PricePlan>>
    {
        private readonly IPricePlanRepository _pricePlanRepo;

        public GetAllPricePlanHandler(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepo = pricePlanRepository;
        }
        public async Task<List<AssetsService.Core.Entities.PricePlan>> Handle(GetAllPricePlanQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.PricePlan>)await _pricePlanRepo.GetAllPricePlan();
        }
    }
}
