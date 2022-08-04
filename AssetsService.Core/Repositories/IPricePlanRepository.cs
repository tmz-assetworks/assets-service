using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;

namespace AssetsService.Core.Repositories.Assets
{
    
    public interface IPricePlanRepository : IRepository<AssetsService.Core.Entities.PricePlan>
    {
        

        Task<List<PricePlan>> GetAllPricePlan();
        Task<PricePlan> GetByIdPricePlan(long id);
    }
}

