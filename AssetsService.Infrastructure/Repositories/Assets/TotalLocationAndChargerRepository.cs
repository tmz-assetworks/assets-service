using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Helpers;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class TotalLocationAndChargerRepository : Repository<TotalLocationAndChargerResponse>, ITotalLocationAndChargerRepository
    {
        string JSONString = string.Empty;
        TokenBase _Token;
        public TotalLocationAndChargerRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext,TokenBase token) : base(dbContext)
        {

            _Token=token;
        }
        Task<TotalLocationAndChargerResponse> ITotalLocationAndChargerRepository.GetTotalLocationAndCharger()
        {
           TotalLocationAndChargerResponse totalLocationAndChargerResponse = new TotalLocationAndChargerResponse();

            totalLocationAndChargerResponse.TotalLocations = _dbContext.Locations.Join(_dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_Token.getObjectId())).FirstOrDefault().Id)),p=> p.Id,n=> n.LocationId, (p, n)=>new { p.LocationId}).Count();
            totalLocationAndChargerResponse.TotalDispenser = _dbContext.Charger.Join(_dbContext.OperatorUserMapper.Where(x => x.UserId == (_dbContext.Users.Where(z => z.ObjectId.Equals(_Token.getObjectId())).FirstOrDefault().Id)), p => p.LocationId, n => n.LocationId, (p, n) => new { p.LocationId }).Count();
            return  Task.FromResult(totalLocationAndChargerResponse);
        }
    }
}
