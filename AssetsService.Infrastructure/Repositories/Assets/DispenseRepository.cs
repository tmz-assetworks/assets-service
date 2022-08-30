using AssetsService.Core.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Response;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class DispenserRepository : Repository<AssetsService.Core.Entities.Dispenser>, IDispenserRepository
    {
        string JSONString = string.Empty;
        public DispenserRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }

        public Task<List<Dispenser>> GetAllDispenser()
        {
            return _dbContext.Dispenser
                 .Select(m => new Dispenser
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     Description = m.Description,
                     EndPointUrl = m.EndPointUrl,
                     FirmwareVersion = m.FirmwareVersion,
                     HardwareSerialNumber = m.HardwareSerialNumber,
                     IsActive = m.IsActive,
                     IsAutomatic = m.IsAutomatic,
                     IsDeviceExists = m.IsDeviceExists,
                     Latitude = m.Latitude,
                     Longitude = m.Longitude,
                     MeterType = m.MeterType,
                     MultiplePorts = m.MultiplePorts,
                     //  NetworkId = m.NetworkId,
                     //  NetworkName = m.NetworkName,
                     PingSchedule = m.PingSchedule,
                     PrivateStation = m.PrivateStation,
                     ReadingSchedule = m.ReadingSchedule,
                     SerialNumber = m.SerialNumber,
                     StationId = m.StationId,
                     ChargeBoxId = m.ChargeBoxId,
                     StationName = m.StationName,
                     //  SubnetworkId = m.SubnetworkId,
                     //  SubnetworkName = m.SubnetworkName,
                     DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                        select new DispenserStatus
                                        {
                                            Id = oblu.Id,
                                            DispenserStatusName = oblu.DispenserStatusName,
                                            CreatedBy = oblu.CreatedBy,
                                            CreatedOn = oblu.CreatedOn,
                                            IsActive = oblu.IsActive,
                                            ModifiedBy = oblu.ModifiedBy,
                                            ModifiedOn = oblu.ModifiedOn,
                                        }).FirstOrDefault(),

                     MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                   select new MakeMaster
                                   {
                                       Id = obls.Id,
                                       Name = obls.Name
                                   }).FirstOrDefault(),
                     Model = (from obls in _dbContext.Model.Where(x => x.Id == m.ModelId)
                              select new Model
                              {
                                  Id = obls.Id,
                                  ModelName = obls.ModelName,
                              }).FirstOrDefault(),
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     /// LocationId = obls.LocationId,
                                     ContactPersonName = obls.ContactPersonName,
                                     GlobalTax = obls.GlobalTax,
                                     TotalCapacity = obls.TotalCapacity,
                                     UtilityService = obls.UtilityService,
                                     CreatedBy = obls.CreatedBy,
                                     CreatedOn = obls.CreatedOn,
                                     Description = obls.Description,
                                     IsActive = obls.IsActive,
                                     ModifiedBy = obls.ModifiedBy,
                                     ModifiedOn = obls.ModifiedOn,
                                     // NetworkId = obls.NetworkId,
                                     ///    NetworkName = obls.NetworkName,
                                     LocationName = obls.LocationName,
                                     LocationNumber = obls.LocationNumber,
                                     ///  SubNetworkId = obls.SubNetworkId,
                                     /// SubNetworkName = obls.SubNetworkName,
                                     TimeZone = obls.TimeZone,

                                     LocationAddress = (from oblt in _dbContext.LocationAddress.Where(x => x.Id == obls.LocationAddressId)
                                                        select new LocationAddress
                                                        {
                                                            Id = oblt.Id,
                                                            AddressLine1 = oblt.AddressLine1,
                                                            AddressLine2 = oblt.AddressLine2,
                                                            AlternateMobileNumber = oblt.AlternateMobileNumber,
                                                            CityId = oblt.CityId,
                                                            CityName = oblt.CityName,
                                                            CountryId = oblt.CountryId,
                                                            CountryName = oblt.CityName,
                                                            CreatedBy = oblt.CreatedBy,
                                                            CreatedOn = obls.CreatedOn,
                                                            Email = oblt.Email,
                                                            IsActive = oblt.IsActive,
                                                            LandlineNumber = oblt.LandlineNumber,
                                                            Latitude = oblt.Latitude,
                                                            Longitude = oblt.Longitude,
                                                            MobileNumber = oblt.MobileNumber,
                                                            ModifiedBy = oblt.ModifiedBy,
                                                            ModifiedOn = oblt.ModifiedOn,
                                                            PinCode = oblt.PinCode,
                                                            StateId = oblt.StateId,
                                                            StateName = oblt.StateName
                                                        }).FirstOrDefault(),

                                     LocationStatus = (from oblu in _dbContext.LocationStatus.Where(x => x.Id == obls.LocationStatusId)
                                                       select new LocationStatus
                                                       {
                                                           Id = oblu.Id,
                                                           LocationStatusName = oblu.LocationStatusName,
                                                           CreatedBy = oblu.CreatedBy,
                                                           CreatedOn = oblu.CreatedOn,
                                                           IsActive = oblu.IsActive,
                                                           ModifiedBy = oblu.ModifiedBy,
                                                           ModifiedOn = oblu.ModifiedOn,

                                                       }).FirstOrDefault(),

                                     LocationSchedule = (from obs in _dbContext.LocationSchedule.Where(x => x.LocationId == obls.Id)
                                                         select new LocationSchedule
                                                         {
                                                             Day = obs.Day,
                                                             StartTime = obs.StartTime,
                                                             EndTime = obs.EndTime,
                                                             CreatedBy = obs.CreatedBy,
                                                             CreatedOn = obs.CreatedOn,
                                                             Id = obs.Id,
                                                             LocationId = obs.LocationId,
                                                             IsActive = obs.IsActive,
                                                             ModifiedBy = obs.ModifiedBy,
                                                             ModifiedOn = obs.ModifiedOn,
                                                         }).ToList(),
                                 }).FirstOrDefault(),
                     Vendor = (from obls in _dbContext.Vendor.Where(x => x.Id == m.vendorId)
                               select new Vendor
                               {
                                   Id = obls.Id,
                                   VendorName = obls.VendorName
                               }).FirstOrDefault(),
                 }).ToListAsync();
        }

        public async Task<Dispenser> GetDispenserByStationId(long stationId)
        {

            Dispenser result = _dbContext.Dispenser.FirstOrDefault(d => d.StationId == stationId);

            return result;


        }

         public async Task<Dispenser> GetDispenserByChargeBoxId(string chargeBoxId)
        {
            var dispenser = _dbContext.Dispenser
                 .Select(m => new Dispenser
                 {
                     LocationId = m.LocationId,
                     DispenserStatusId = m.DispenserStatusId,
                     Id = m.Id,
                     AssetId = m.AssetId,
                     Description = m.Description,
                     EndPointUrl = m.EndPointUrl,
                     FirmwareVersion = m.FirmwareVersion,
                     HardwareSerialNumber = m.HardwareSerialNumber,
                     IsActive = m.IsActive,
                     IsAutomatic = m.IsAutomatic,
                     IsDeviceExists = m.IsDeviceExists,
                     Latitude = m.Latitude,
                     Longitude = m.Longitude,
                     MeterType = m.MeterType,
                     MultiplePorts = m.MultiplePorts,
                     PingSchedule = m.PingSchedule,
                     PrivateStation = m.PrivateStation,
                     ReadingSchedule = m.ReadingSchedule,
                     SerialNumber = m.SerialNumber,
                     StationId = m.StationId,
                     ChargeBoxId = m.ChargeBoxId,
                     StationName = m.StationName,
                     DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                        select new DispenserStatus
                                        {
                                            Id = oblu.Id,
                                            DispenserStatusName = oblu.DispenserStatusName,
                                            CreatedBy = oblu.CreatedBy,
                                            CreatedOn = oblu.CreatedOn,
                                            IsActive = oblu.IsActive,
                                            ModifiedBy = oblu.ModifiedBy,
                                            ModifiedOn = oblu.ModifiedOn,
                                        }).FirstOrDefault(),
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationName = obls.LocationName,
                                     LocationAddress = obls.LocationAddress
                                 }).FirstOrDefault(),
                     Ports = ((List<Port>)(from obpo in _dbContext.Port.Where(x => x.DispenserId == m.Id)
                                           select new Port
                                           {
                                               Id = obpo.Id,
                                               ConnectorId = obpo.ConnectorId,
                                               Connector = obpo.Connector,
                                               ConnectorType = obpo.ConnectorType,
                                           })),
                 }).Where(d => d.ChargeBoxId.ToLower() == chargeBoxId.ToLower()).FirstOrDefault();
            return dispenser;
        }

        public async Task<List<DispenserByLocationIdResponse>> GetDispenserByLocationId(long locationId)
        {

            List<DispenserByLocationIdResponse> query = (from location in _dbContext.Locations
                                                         join charger in _dbContext.Dispenser
                                                         on location.Id equals charger.LocationId
                                                         join address in _dbContext.LocationAddress
                                                         on location.LocationAddressId equals address.Id
                                                         join Status in _dbContext.LocationStatus
                                                         on location.LocationStatusId equals Status.Id
                                                         where location.Id.Equals(locationId)
                                                         select new DispenserByLocationIdResponse
                                                         {
                                                             ChargerId = charger.Id,
                                                             LocationId = locationId,
                                                             LocationName = location.LocationName,
                                                             ContactPersonName = location.ContactPersonName,
                                                             AddressLine1 = address.AddressLine1,
                                                             LocationStatusName = Status.LocationStatusName,
                                                             LocationStatusId = location.LocationStatusId,
                                                             ChargeBoxId = charger.ChargeBoxId,
                                                             SerialNumber = charger.SerialNumber,
                                                             DispenserStatus = charger.DispenserStatus,

                                                             //SerialNumber = charger.st,
                                                             //TODO
                                                             //ChargerStats

                                                         }
                        ).ToList();

            return query.ToList();
        }

        public async Task<Dispenser> GetDispenserById(long dispenserId)
        {
            return _dbContext.Dispenser
                 .Select(m => new Dispenser
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     Description = m.Description,
                     EndPointUrl = m.EndPointUrl,
                     FirmwareVersion = m.FirmwareVersion,
                     HardwareSerialNumber = m.HardwareSerialNumber,
                     IsActive = m.IsActive,
                     IsAutomatic = m.IsAutomatic,
                     IsDeviceExists = m.IsDeviceExists,
                     Latitude = m.Latitude,
                     Longitude = m.Longitude,
                     MeterType = m.MeterType,
                     MultiplePorts = m.MultiplePorts,
                     //  NetworkId = m.NetworkId,
                     //  NetworkName = m.NetworkName,
                     PingSchedule = m.PingSchedule,
                     PrivateStation = m.PrivateStation,
                     ReadingSchedule = m.ReadingSchedule,
                     SerialNumber = m.SerialNumber,
                     StationId = m.StationId,
                     ChargeBoxId = m.ChargeBoxId,
                     StationName = m.StationName,

                     DispenserStatus = (from oblu in _dbContext.DispenserStatus.Where(x => x.Id == m.DispenserStatusId)
                                        select new DispenserStatus
                                        {
                                            Id = oblu.Id,
                                            DispenserStatusName = oblu.DispenserStatusName,
                                            CreatedBy = oblu.CreatedBy,
                                            CreatedOn = oblu.CreatedOn,
                                            IsActive = oblu.IsActive,
                                            ModifiedBy = oblu.ModifiedBy,
                                            ModifiedOn = oblu.ModifiedOn,
                                        }).FirstOrDefault(),


                     MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                   select new MakeMaster
                                   {
                                       Id = obls.Id,
                                       Name = obls.Name
                                   }).FirstOrDefault(),
                     Model = (from obls in _dbContext.Model.Where(x => x.Id == m.ModelId)
                              select new Model
                              {
                                  Id = obls.Id,
                                  ModelName = obls.ModelName,
                              }).FirstOrDefault(),
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationName = obls.LocationName,
                                 }).FirstOrDefault(),
                     Vendor = (from obls in _dbContext.Vendor.Where(x => x.Id == m.vendorId)
                               select new Vendor
                               {
                                   Id = obls.Id,
                                   VendorName = obls.VendorName
                               }).FirstOrDefault(),
                 }).Where(x => x.Id == dispenserId).FirstOrDefault();
        }
        public async Task<List<DispenserByLocationsResponse>> GetDispenserByLocations(List<long> locationIds)
        {
            List<DispenserByLocationsResponse> query = new List<DispenserByLocationsResponse>();
            if (locationIds.Count <= 0)
            {
                query = (from location in _dbContext.Locations
                         join charger in _dbContext.Dispenser
                         on location.Id equals charger.LocationId
                         join address in _dbContext.LocationAddress
                         on location.LocationAddressId equals address.Id
                         join Status in _dbContext.LocationStatus
                         on location.LocationStatusId equals Status.Id

                         select new DispenserByLocationsResponse
                         {
                             ChargerId = charger.Id,
                             LocationId = location.Id,
                             LocationName = location.LocationName,
                             ContactPersonName = location.ContactPersonName,
                             AddressLine1 = address.AddressLine1,
                             LocationStatusName = Status.LocationStatusName,
                             LocationStatusId = location.LocationStatusId,
                             ChargeBoxId = charger.ChargeBoxId,
                             SerialNumber = charger.SerialNumber,
                             DispenserName = charger.StationName,
                             ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.Model.ModelName,
                             ProtocolName = charger.Model.Protocol.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeMaster.Name,


                         }

                           ).ToList<DispenserByLocationsResponse>();


            }
            else
            {
                query = (from location in _dbContext.Locations.Where(x => locationIds.Contains(x.Id))
                         join charger in _dbContext.Dispenser
                         on location.Id equals charger.LocationId
                         join address in _dbContext.LocationAddress
                         on location.LocationAddressId equals address.Id
                         join Status in _dbContext.LocationStatus
                         on location.LocationStatusId equals Status.Id

                         select new DispenserByLocationsResponse
                         {
                             ChargerId = charger.Id,
                             LocationId = location.Id,
                             LocationName = location.LocationName,
                             ContactPersonName = location.ContactPersonName,
                             AddressLine1 = address.AddressLine1,
                             LocationStatusName = Status.LocationStatusName,
                             LocationStatusId = location.LocationStatusId,
                             DispenserName = charger.StationName,
                             ChargeBoxId = charger.ChargeBoxId,
                             SerialNumber = charger.SerialNumber,
                             ChargerStatus = charger.DispenserStatus.DispenserStatusName,
                             ConnectorType = String.Join(",", _dbContext.Port.Where(p => p.DispenserId == charger.Id).Select(s => s.Connector.ConnectorType)),
                             DispenserModel = charger.Model.ModelName,
                             ProtocolName = charger.Model.Protocol.ProtocolName,
                             NoofPort = charger.Ports.Count.ToString(),
                             DispenserMake = charger.MakeMaster.Name,
                         }).ToList<DispenserByLocationsResponse>();

            }
            return query;
        }

        /// <summary>
        /// Get Chargers Details List
        /// </summary>
        /// <param name="dispensersDetailRequest"></param>
        /// <returns></returns>
        public Task<PagedList<DispensersDetail>> GetDispensersDetail(DispensersDetailRequest dispensersDetailRequest)
        {
            List<DispensersDetail> result = new List<DispensersDetail>();
            result = (from disp in _dbContext.Dispenser
                      join location in _dbContext.Locations on disp.LocationId equals location.Id
                      select new DispensersDetail
                      {
                          ChargerName = disp.Description,
                          ChargerBoxId = disp.ChargeBoxId,
                          FaultSince = "",
                          TimeReported = "",
                          LocationId = disp.LocationId,
                          State = location.LocationAddress != null ? location.LocationAddress.StateName : "",
                          ChargerType = "OCPP",
                          LocationContactName = location.LocationName,
                          LocationContactNumber = location.ContactPersonName,

                      }).ToList<DispensersDetail>();
            result = result != null ? result.OrderByDescending(a => a.ChargerName).ToList<DispensersDetail>() : result;


            if (!string.IsNullOrEmpty(dispensersDetailRequest.SearchParam))
                result = result.Where(d => d.ChargerName.ToLower().Contains( dispensersDetailRequest.SearchParam.ToLower())
             ).ToList<DispensersDetail>();
            //  Paging on Records

            var dataResult = PagedList<DispensersDetail>.ToPagedList(result,
              dispensersDetailRequest.PageNumber,
              dispensersDetailRequest.PageSize);

            return Task.FromResult(dataResult);
        }

        public async Task<ChargerResponse> ValidateChargerId(string ChargeBoxId)
        {
            ChargerResponse result =  new ChargerResponse();
            Dispenser rus = await _dbContext.Dispenser.FirstOrDefaultAsync(d => d.ChargeBoxId == ChargeBoxId);
            if (rus!= null)
            {
                result.Id = rus.Id;
                result.ChargeBoxId = rus.ChargeBoxId;
                result.status = rus.IsActive;

            }
            
            return result;

        }

    }
}



