using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Core.Repositories.Assets
{
    public interface ITimeZoneRepository : IRepository<TimeZoneResponse>
    {
        Task<List<TimeZoneResponse>> GetAllTimeZones();
    }
}
