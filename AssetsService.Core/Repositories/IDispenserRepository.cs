using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using System.Collections.Generic;
using AssetsService.Core.Response;
using AssetsService.Core.PagingHelper;
using static AssetsService.Core.Response.GetDispenserStatusResponse;

namespace AssetsService.Core.Repositories.Assets
{
    public interface IDispenserRepository : IRepository<AssetsService.Core.Entities.Dispenser>
    {
        //custom operations here
        Task<AssetsService.Core.Entities.Dispenser> GetDispenserById(long dispenserId);
        Task<List<AssetsService.Core.Entities.DispenserStatus>> GetDispenserStatusData(DispenserStatusRequest dispenserStatusRequest);
        Task<GetDispenserResponse> GetDispenserDetailsById(long dispenserId);
        Task<List<Dispenser>> GetAllDispenser();
        Task<List<PlugTypeResponseData>> GetAllPlugType(string userId);
        Task<List<ConnectorTypeResponseData>> GetConnectorType(string userId);
        Task<AllDispenserResponse> GetAllDispensers(DispensersRequest dispensersRequest); 
        Task<Dispenser> GetDispenserByChargeBoxId(string chargeBoxId);

        Task<Dispenser> GetDispenserByStationId(long stationId);

        Task<List<DispenserByLocationIdResponse>> GetDispenserByLocationId(long locationId);
        Task<List<DispenserByLocationsResponse>> GetDispenserByLocations(List<long> locationId);
       Task<PagedList<DispensersDetail>> GetDispensersDetail(DispensersDetailRequest dispensersDetailRequest);
       Task<PagedList<DispenserByLocationsResponse>> GetLocationDispensers(LocationDispensersRequest locationDispensersRequest);
       Task<ChargerResponse>ValidateChargerId(string ChargeBoxId);
        Task<List<ListDropDown>> GetModemDDLList(string userId);
        Task<Dispenser> UpdateDispenser(Dispenser dispenser);
    }
}
