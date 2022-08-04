using AssetsService.Core.Repositories.Assets.Base;
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
        Task<List<AssetsService.Core.Entities.SubscriptionPlan>> GetAllSubscriptionPlan();
        Task<AssetsService.Core.Entities.SubscriptionPlan> GetSubscriptionPlanById(long customerId);
    }
}
