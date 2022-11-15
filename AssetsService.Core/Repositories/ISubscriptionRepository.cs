using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface ISubscriptionPlanRepository : IRepository<AssetsService.Core.Entities.SubscriptionPlan>
    {
        //custom operations here
        Task<SubscriptionPlanResponse> GetAllSubscriptionPlans(GetSubscriptionPlanRequest subscriptionPlanRequest);
        Task<SubscriptionPlansByIdResponse> GetSubscriptionPlanById(long customerId);
        Task<SubscriptionPlan> UpdateSubscriptionPlan(SubscriptionPlan subscriptionPlan);
        Task<List<CurrencyListDropDown>> GetCurrencyDDLList(string userId);
    }
}
