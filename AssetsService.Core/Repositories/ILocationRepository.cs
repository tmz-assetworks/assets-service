using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Core.Repositories.Assets
{
    public interface ILocationRepository : IRepository<AssetsService.Core.Entities.Location>
    {

        Task<AssetsService.Core.Entities.Location> GetByIdLocation(long locationId);
        Task<Location> GetLocationByLocationId(string locationId);
        Task<List<AssetsService.Core.Entities.Location>> GetAllLocation();
        Task<List<Core.Response.LocationData>> GetAllLocationName();
        Task<List<Core.Response.LocationsDispenser>> GetLocationsDispenserformap(List<long> Id);
        Task<PagedList<Core.Response.LocationsDispenserDetails>> GetLocationsDispenserDetails(LocationDispenserRequest locationDispenserRequest);
        Task<List<Core.Response.LocationDispenserForLocation>> GetLocationsDispenserForLocation(List<long> Id);
        Task<Locationalist>GetLocationList(LocationListRequst LocationListRequst);
        Task<List<AllLocationStatuss>>GetAllLocationStatus();

        Task<Location>CreateLocation(Location location);
        Task<List<AllDepartmentList>>GetAllDepartmentList();
        Task<Location>UpdateLocation(Location location);

    }

}
