using AssetsService.Application.Commands.Assets.SubscriptionPlan;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets.SubscriptionPlan
{
    public class CreateSubscriptionPlanHandler : IRequestHandler<CreateSubscriptionPlanCommand, SubscriptionPlanResponse>
    {
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepo;

        public CreateSubscriptionPlanHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionPlanRepo = subscriptionPlanRepository;
        }
        public async Task<SubscriptionPlanResponse> Handle(CreateSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var subscriptionEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.SubscriptionPlan>(request);
            if (subscriptionEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var addSubscriptionResponse = await _subscriptionPlanRepo.AddAsync(subscriptionEntitiy);
            var mapSusbcriptionResponse = Mapper.Mappers.Map<SubscriptionPlanResponse>(addSubscriptionResponse);
            return mapSusbcriptionResponse;
        }
    }
 }

