using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdSubscriptionHandler : IRequestHandler<GetSubscriptionByIdQuery, AssetsService.Core.Entities.SubscriptionPlan>
    {
        private readonly ISubscriptionPlanRepository _subscriptionRepo;
        public GetByIdSubscriptionHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionRepo = subscriptionPlanRepository;
        }
        public async Task<AssetsService.Core.Entities.SubscriptionPlan> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            return (AssetsService.Core.Entities.SubscriptionPlan)await _subscriptionRepo.GetSubscriptionPlanById(Convert.ToInt32(request.Id));
        }
    }
}
