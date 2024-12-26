using AssetsService.Core.Entities;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.EnumData;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class TimeZoneRepository : Repository<TimeZoneResponse>, ITimeZoneRepository
    {
        public TimeZoneRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {
        }

        public async Task<List<TimeZoneResponse>> GetAllTimeZones()
        {
            var result = await (from TimeZone in _dbContext.TimeZones.Where(e => e.IsActive)
                          select new TimeZoneResponse
                          {
                              Id = Convert.ToInt32(TimeZone.Id),
                              TimeZoneText = TimeZone.TimeZoneText,
                          }
                          ).ToListAsync<TimeZoneResponse>();
            return result;
        }

        
    }
}
