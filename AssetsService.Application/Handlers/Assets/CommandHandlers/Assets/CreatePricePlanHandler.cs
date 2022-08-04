using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers
{
    public class CreatePricePlanHandler : IRequestHandler<CreatePricePlanCommand, PricePlanResponse>
    {
        private readonly IPricePlanRepository _pricePlanRepo;

        public CreatePricePlanHandler(IPricePlanRepository pricePlanRepository)
        {
            _pricePlanRepo = pricePlanRepository;
        }
        public async Task<PricePlanResponse> Handle(CreatePricePlanCommand request, CancellationToken cancellationToken)
        {
            var pricePlanEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.PricePlan>(request);
            if (pricePlanEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addPricePlanResponse = await _pricePlanRepo.AddAsync(pricePlanEntitiy);
            var mapPricePlanResponse = Mapper.Mappers.Map<PricePlanResponse>(addPricePlanResponse);
            return mapPricePlanResponse;
        }
    }
}
