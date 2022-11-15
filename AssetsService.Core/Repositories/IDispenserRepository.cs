using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using System.Collections.Generic;
using AssetsService.Core.Response;
using AssetsService.Core.PagingHelper;
using static AssetsService.Core.Response.GetDispenserStatusResponse;

namespace AssetsService.Core.Repositories.Assets
{
    public interface IDispenserRepository : IRepository<AssetsService.Core.Entities.Charger>
    {
        //custom operations here
        Task<List<ChargerStatus>> GetDispenserStatusData(DispenserStatusRequest dispensersDetailRequest);
        Task<AssetsService.Core.Entities.Charger> GetDispenserById(long dispenserId);
        Task<GetDispenserResponse> GetDispenserDetailsById(long dispenserId);
        Task<List<Charger>> GetAllDispenser();
        Task<List<PlugTypeResponseData>> GetAllPlugType(string userId);
        Task<List<ConnectorTypeResponseData>> GetConnectorType(string userId);
        Task<AllDispenserResponse> GetAllDispensers(DispensersRequest dispensersRequest); 
        Task<Charger> GetDispenserByChargeBoxId(string chargeBoxId);
        Task<Charger> GetDispenserByStationId(long stationId);
        Task<List<DispenserByLocationIdResponse>> GetDispenserByLocationId(long locationId);
        Task<List<DispenserByLocationsResponse>> GetDispenserByLocations(List<long> locationId);
        Task<PagedList<DispensersDetail>> GetDispensersDetail(DispensersDetailRequest dispensersDetailRequest);
        Task<PagedList<DispenserByLocationsResponse>> GetLocationDispensers(LocationDispensersRequest locationDispensersRequest);
        Task<ChargerResponse>ValidateChargerId(string ChargeBoxId);
        Task<List<ListDropDown>> GetModemDDLList(string userId,int? dispenserId);
        Task<Charger> UpdateDispenser(Charger dispenser);
    }
}
