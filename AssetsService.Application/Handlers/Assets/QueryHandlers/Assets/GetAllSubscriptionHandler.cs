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
    public class GetAllSubscriptionHandler : IRequestHandler<GetAllSubscriptionQuery, List<AssetsService.Core.Entities.SubscriptionPlan>>
    {
        private readonly ISubscriptionPlanRepository _subscriptionRepo;

        public GetAllSubscriptionHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionRepo = subscriptionPlanRepository;
        }
        public async Task<List<AssetsService.Core.Entities.SubscriptionPlan>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Entities.SubscriptionPlan>)await _subscriptionRepo.GetAllSubscriptionPlan();
        }
    }
}
