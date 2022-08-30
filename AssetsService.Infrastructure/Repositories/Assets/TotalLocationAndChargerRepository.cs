using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Repositories;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class TotalLocationAndChargerRepository : Repository<TotalLocationAndChargerResponse>, ITotalLocationAndChargerRepository
    {
        string JSONString = string.Empty;
        public TotalLocationAndChargerRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {


        }
        Task<TotalLocationAndChargerResponse> ITotalLocationAndChargerRepository.GetTotalLocationAndCharger()
        {
           TotalLocationAndChargerResponse totalLocationAndChargerResponse = new TotalLocationAndChargerResponse();

            totalLocationAndChargerResponse.TotalLocations = _dbContext.Locations.Where(m => true==true).Count();
            totalLocationAndChargerResponse.TotalDispenser = _dbContext.Dispenser.Where(n => true == true).Count();
            return  Task.FromResult(totalLocationAndChargerResponse);
        }
    }
}
