using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;

namespace AssetsService.Core.Repositories.Assets
{
    public interface ILocationRepository : IRepository<AssetsService.Core.Entities.Location>
    {

        Task<AssetsService.Core.Entities.Location> GetByIdLocation(long locationId);
        Task<List<AssetsService.Core.Entities.Location>> GetAllLocation();
        Task<List<Core.Response.LocationData>> GetAllLocationName();
        Task<List<Core.Response.LocationsDispenser>> GetLocationsDispenserformap(List<long> Id);
        Task<PagedList<Core.Response.LocationsDispenserDetails>> GetLocationsDispenserDetails(LocationDispenserRequest locationDispenserRequest);
        Task<List<Core.Response.LocationDispenserForLocation>> GetLocationsDispenserForLocation(List<long> Id);

    }

}
