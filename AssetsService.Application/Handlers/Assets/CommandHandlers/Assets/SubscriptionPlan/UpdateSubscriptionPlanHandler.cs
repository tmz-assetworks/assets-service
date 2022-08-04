using AssetsService.Application.Commands.Assets.SubscriptionPlan;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.SubscriptionPlan
{
    public class UpdateSubscriptionPlanHandler : IRequestHandler<UpdateSubscriptionPlanCommand, SubscriptionPlanResponse>
    {
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepo;

        public UpdateSubscriptionPlanHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionPlanRepo = subscriptionPlanRepository;
        }


        public async Task<SubscriptionPlanResponse> Handle(UpdateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var subscriptionEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.SubscriptionPlan>(request);
            if (subscriptionEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var updateSubscriptionPlan = _subscriptionPlanRepo.UpdateAsync(subscriptionEntitiy, request.CustomerId);
            var mapSubscriptionResponse = Mapper.Mappers.Map<SubscriptionPlanResponse>(updateSubscriptionPlan.Result);
            return mapSubscriptionResponse;
        }
    }
}
