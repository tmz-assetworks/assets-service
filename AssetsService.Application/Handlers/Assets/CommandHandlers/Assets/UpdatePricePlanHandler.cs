using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class UpdatePricePlanHandler : IRequestHandler<UpdatePricePlanCommand, PricePlanResponse>
    {
        private readonly IPricePlanRepository _pricePlanRepo;

        public UpdatePricePlanHandler(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepo = pricePlanRepository;
        }


        public async Task<PricePlanResponse> Handle(UpdatePricePlanCommand request, CancellationToken cancellationToken)
        {
            var pricePlanEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.PricePlan>(request);
            if (pricePlanEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            pricePlanEntitiy.CreatedOn = DateTime.Now;
            pricePlanEntitiy.ModifiedOn = DateTime.Now;
            var updatePricePlan = _pricePlanRepo.UpdateAsync(pricePlanEntitiy, request.Id, "PRICEPLAN");
            var mapPricePlanResponse = Mapper.Mappers.Map<PricePlanResponse>(updatePricePlan.Result);
            return mapPricePlanResponse;
        }
    }
}
