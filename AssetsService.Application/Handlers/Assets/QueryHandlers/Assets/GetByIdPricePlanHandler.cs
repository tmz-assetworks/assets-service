
using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdPricePlanHandler : IRequestHandler<GetByIdPricePlanQuery, AssetsService.Core.Entities.PricePlan>
    {
        private readonly IPricePlanRepository _pricePlanRepo;

        public GetByIdPricePlanHandler(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepo = pricePlanRepository;
        }

     public async Task<AssetsService.Core.Entities.PricePlan> Handle(GetByIdPricePlanQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.PricePlan)await _pricePlanRepo.GetByIdPricePlan(request.Id);
        }

        
    }

    

}
