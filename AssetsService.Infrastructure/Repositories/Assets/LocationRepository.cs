using AssetsService.Core.Entities;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.EnumData;
using AssetsService.Infrastructure.Helpers;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class LocationRepository : Repository<AssetsService.Core.Entities.Location>, ILocationRepository
    {
        string JSONString = string.Empty;
        public LocationRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<AssetsService.Core.Entities.Location> GetLocationById(long locationId)
        {
            return _dbContext.Locations.Where(t => t.Id == locationId)
                 .Select(m => new Location
                 {
                     Id = m.Id,
                     ContactPersonName = m.ContactPersonName,
                     GlobalTax = m.GlobalTax,
                     TotalCapacity = m.TotalCapacity,
                     UtilityService = m.UtilityService,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     IsActive = m.IsActive,

                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     DepartmentId = m.DepartmentId,
                     LocationStatusId = m.LocationStatusId,
                     LocationAddressId = m.LocationAddressId,
                     FuelProtectType = m.FuelProtectType,

                     LocationName = m.LocationName,
                     LocationNumber = m.LocationNumber,

                     TimeZone = m.TimeZone,

                     LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                        select new LocationAddress
                                        {
                                            Id = obls.Id,
                                            AddressLine1 = obls.AddressLine1,
                                            AddressLine2 = obls.AddressLine2,
                                            AlternateMobileNumber = obls.AlternateMobileNumber,
                                            CityId = obls.CityId,
                                            CityName = obls.CityName,
                                            CountryId = obls.CountryId,
                                            CountryName = obls.CountryName,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            Email = obls.Email,
                                            IsActive = obls.IsActive,
                                            LandlineNumber = obls.LandlineNumber,
                                            Latitude = obls.Latitude,
                                            Longitude = obls.Longitude,
                                            MobileNumber = obls.MobileNumber,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                            PinCode = obls.PinCode,
                                            StateId = obls.StateId,
                                            StateName = obls.StateName
                                        }).FirstOrDefault(),

                     LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                       select new LocationStatus
                                       {
                                           Id = obls.Id,
                                           LocationStatusName = obls.LocationStatusName,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,

                                       }).FirstOrDefault(),

                     Department = (from obls in _dbContext.Department.Where(x => x.Id == m.DepartmentId)
                                   select new Department
                                   {
                                       Id = obls.Id,
                                       DepartmentName = obls.DepartmentName,
                                       ContactPersonName = obls.ContactPersonName,
                                       Address = obls.Address,
                                       CreatedBy = obls.CreatedBy,
                                       CreatedOn = obls.CreatedOn,
                                       IsActive = obls.IsActive,
                                       ModifiedBy = obls.ModifiedBy,
                                       ModifiedOn = obls.ModifiedOn,

                                   }).FirstOrDefault(),

                     LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                         select new LocationSchedule
                                         {
                                             Day = obls.Day,
                                             StartTime = obls.StartTime,
                                             EndTime = obls.EndTime,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                         }).ToList(),
                     OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                           select new OperatorUserMapper
                                           {
                                               UserId = obls.UserId,
                                               UserName = obls.UserName,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               Id = obls.Id,
                                               LocationId = obls.LocationId,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).ToList(),

                 }).ToList().FirstOrDefault();
        }
        public async Task<List<Location>> GetAllLocation()
        {

            return _dbContext.Locations
                 .Select(m => new Location
                 {
                     Id = m.Id,
                     ContactPersonName = m.ContactPersonName,
                     GlobalTax = m.GlobalTax,
                     TotalCapacity = m.TotalCapacity,
                     UtilityService = m.UtilityService,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     IsActive = m.IsActive,

                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     DepartmentId = m.DepartmentId,
                     LocationStatusId = m.LocationStatusId,
                     LocationAddressId = m.LocationAddressId,
                     FuelProtectType = m.FuelProtectType,

                     LocationName = m.LocationName,
                     LocationNumber = m.LocationNumber,

                     TimeZone = m.TimeZone,

                     LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                        select new LocationAddress
                                        {
                                            Id = obls.Id,
                                            AddressLine1 = obls.AddressLine1,
                                            AddressLine2 = obls.AddressLine2,
                                            AlternateMobileNumber = obls.AlternateMobileNumber,
                                            CityId = obls.CityId,
                                            CityName = obls.CityName,
                                            CountryId = obls.CountryId,
                                            CountryName = obls.CountryName,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            Email = obls.Email,
                                            IsActive = obls.IsActive,
                                            LandlineNumber = obls.LandlineNumber,
                                            Latitude = obls.Latitude,
                                            Longitude = obls.Longitude,
                                            MobileNumber = obls.MobileNumber,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                            PinCode = obls.PinCode,
                                            StateId = obls.StateId,
                                            StateName = obls.StateName
                                        }).FirstOrDefault(),

                     LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                       select new LocationStatus
                                       {
                                           Id = obls.Id,
                                           LocationStatusName = obls.LocationStatusName,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,

                                       }).FirstOrDefault(),

                     Department = (from obls in _dbContext.Department.Where(x => x.Id == m.DepartmentId)
                                   select new Department
                                   {
                                       Id = obls.Id,
                                       DepartmentName = obls.DepartmentName,
                                       ContactPersonName = obls.ContactPersonName,
                                       Address = obls.Address,
                                       CreatedBy = obls.CreatedBy,
                                       CreatedOn = obls.CreatedOn,
                                       IsActive = obls.IsActive,
                                       ModifiedBy = obls.ModifiedBy,
                                       ModifiedOn = obls.ModifiedOn,

                                   }).FirstOrDefault(),

                     LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                         select new LocationSchedule
                                         {
                                             Day = obls.Day,
                                             StartTime = obls.StartTime,
                                             EndTime = obls.EndTime,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                         }).ToList(),
                     OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                           select new OperatorUserMapper
                                           {
                                               UserId = obls.UserId,
                                               UserName = obls.UserName,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               Id = obls.Id,
                                               LocationId = obls.LocationId,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).ToList(),

                 }).ToList();

        }

        public async Task<Location> GetByIdLocation(long locationId)
        {


            return _dbContext.Locations.Where(t => t.Id == locationId)
                 .Select(m => new Location
                 {
                     Id = m.Id,
                     ContactPersonName = m.ContactPersonName,
                     GlobalTax = m.GlobalTax,
                     TotalCapacity = m.TotalCapacity,
                     UtilityService = m.UtilityService,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     Description = m.Description,
                     IsActive = m.IsActive,

                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     DepartmentId = m.DepartmentId,
                     LocationStatusId = m.LocationStatusId,
                     LocationAddressId = m.LocationAddressId,
                     FuelProtectType = m.FuelProtectType,

                     LocationName = m.LocationName,
                     LocationNumber = m.LocationNumber,

                     TimeZone = m.TimeZone,

                     LocationAddress = (from obls in _dbContext.LocationAddress.Where(x => x.Id == m.LocationAddressId)
                                        select new LocationAddress
                                        {
                                            Id = obls.Id,
                                            AddressLine1 = obls.AddressLine1,
                                            AddressLine2 = obls.AddressLine2,
                                            AlternateMobileNumber = obls.AlternateMobileNumber,
                                            CityId = obls.CityId,
                                            CityName = obls.CityName,
                                            CountryId = obls.CountryId,
                                            CountryName = obls.CountryName,
                                            CreatedBy = obls.CreatedBy,
                                            CreatedOn = obls.CreatedOn,
                                            Email = obls.Email,
                                            IsActive = obls.IsActive,
                                            LandlineNumber = obls.LandlineNumber,
                                            Latitude = obls.Latitude,
                                            Longitude = obls.Longitude,
                                            MobileNumber = obls.MobileNumber,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                            PinCode = obls.PinCode,
                                            StateId = obls.StateId,
                                            StateName = obls.StateName
                                        }).FirstOrDefault(),

                     LocationStatus = (from obls in _dbContext.LocationStatus.Where(x => x.Id == m.LocationStatusId)
                                       select new LocationStatus
                                       {
                                           Id = obls.Id,
                                           LocationStatusName = obls.LocationStatusName,
                                           CreatedBy = obls.CreatedBy,
                                           CreatedOn = obls.CreatedOn,
                                           IsActive = obls.IsActive,
                                           ModifiedBy = obls.ModifiedBy,
                                           ModifiedOn = obls.ModifiedOn,

                                       }).FirstOrDefault(),

                     Department = (from obls in _dbContext.Department.Where(x => x.Id == m.DepartmentId)
                                   select new Department
                                   {
                                       Id = obls.Id,
                                       DepartmentName = obls.DepartmentName,
                                       ContactPersonName = obls.ContactPersonName,
                                       Address = obls.Address,
                                       CreatedBy = obls.CreatedBy,
                                       CreatedOn = obls.CreatedOn,
                                       IsActive = obls.IsActive,
                                       ModifiedBy = obls.ModifiedBy,
                                       ModifiedOn = obls.ModifiedOn,

                                   }).FirstOrDefault(),

                     LocationSchedule = (from obls in _dbContext.LocationSchedule.Where(x => x.LocationId == m.Id)
                                         select new LocationSchedule
                                         {
                                             Day = obls.Day,
                                             StartTime = obls.StartTime,
                                             EndTime = obls.EndTime,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             Id = obls.Id,
                                             LocationId = obls.LocationId,
                                             IsActive = obls.IsActive,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,
                                         }).ToList(),
                     OperatorUserMapper = (from obls in _dbContext.OperatorUserMapper.Where(x => x.LocationId == m.Id)
                                           select new OperatorUserMapper
                                           {
                                               UserId = obls.UserId,
                                               UserName = obls.UserName,
                                               CreatedBy = obls.CreatedBy,
                                               CreatedOn = obls.CreatedOn,
                                               Id = obls.Id,
                                               LocationId = obls.LocationId,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                           }).ToList()

                 }).Where(m => m.Id == locationId).FirstOrDefault();

            //}).FirstOrDefault();


        }

        public Task<List<LocationsDispenser>> GetLocationsDispenserformap(List<long> Id)
        {
            // return null
            List<LocationsDispenser> result = new List<LocationsDispenser>();
            if (Id.Count <= 0 || Id == null)
            {
                result = (from location in _dbContext.Locations
                          join charger in _dbContext.Dispenser
                          on location.Id equals charger.LocationId
                          select new LocationsDispenser
                          {
                              CityName = location.LocationAddress.CityName,
                              CountryName = location.LocationAddress.CountryName,
                              StateName = location.LocationAddress.StateName,
                              locationId = location.Id,
                              Latitude = location.LocationAddress.Latitude,
                              Longitude = location.LocationAddress.Longitude,
                              LocationName = location.LocationName,
                              DispenserId = charger.Id,

                              status = charger.DispenserStatus.DispenserStatusName
                          }).ToList<LocationsDispenser>();
            }
            else
            {
                result = (from location in _dbContext.Locations.Where(x => Id.Contains(x.Id))
                          join charger in _dbContext.Dispenser
                          on location.Id equals charger.LocationId
                          select new LocationsDispenser
                          {
                              CityName = location.LocationAddress.CityName,
                              CountryName = location.LocationAddress.CountryName,
                              StateName = location.LocationAddress.StateName,
                              locationId = location.Id,
                              Latitude = location.LocationAddress.Latitude,
                              Longitude = location.LocationAddress.Longitude,
                              LocationName = location.LocationName,
                              DispenserId = charger.Id,
                              status = charger.DispenserStatus.DispenserStatusName
                          }).ToList<LocationsDispenser>();
            }


            return Task.FromResult(result);
        }

        public Task<PagedList<LocationsDispenserDetails>> GetLocationsDispenserDetails(LocationDispenserRequest locationDispenserRequest)
        {
            List<LocationsDispenserDetails> result = new List<LocationsDispenserDetails>();
            if (locationDispenserRequest.LocationIds.Count <= 0 || locationDispenserRequest.LocationIds == null)
            {
                result = (from location in _dbContext.Locations
                          select new LocationsDispenserDetails
                          {
                              Address = location.LocationAddress.CityName + ", " + location.LocationAddress.StateName,

                              locationId = location.Id,

                              CreatedOn = location.CreatedOn,

                              LocationName = location.LocationName,

                              status = location.LocationStatus.LocationStatusName,
                              NoofPort = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id)
                                          join port in _dbContext.Port
                              on charger.Id equals port.DispenserId
                                          select new Port
                                          {
                                              DispenserId = charger.Id
                                          }).ToList<Port>().Count.ToString(),
                              Available = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Available.GetEnumDisplayName())) //"Available")
                                           select new DispenserStatus
                                           {
                                               Id = charger.DispenserStatusId,
                                           }
                                           ).ToList<DispenserStatus>().Count.ToString(),
                              Connected = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Connected.GetEnumDisplayName())) //== "Connected")
                                           select new DispenserStatus
                                           {
                                               Id = charger.DispenserStatusId,
                                           }).ToList<DispenserStatus>().Count.ToString(),
                              Faulted = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Faulted.GetEnumDisplayName()))  // == "Faulted")
                                         select new DispenserStatus
                                         {
                                             Id = charger.DispenserStatusId,
                                         }).ToList<DispenserStatus>().Count.ToString(),
                              ContactNo = location.LocationAddress.MobileNumber.ToString(),
                              ContactName = location.ContactPersonName.ToString(),

                          }).ToList<LocationsDispenserDetails>();
            }
            else
            {
                result = (from location in _dbContext.Locations.Where(x => locationDispenserRequest.LocationIds.Contains(x.Id))
                          select new LocationsDispenserDetails
                          {
                              Address = location.LocationAddress.CityName + ", " + location.LocationAddress.StateName,

                              locationId = location.Id,

                              LocationName = location.LocationName,
                              CreatedOn = location.CreatedOn,

                              status = location.LocationStatus.LocationStatusName,
                              NoofPort = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id)
                                          join port in _dbContext.Port
                              on charger.Id equals port.DispenserId
                                          select new Port
                                          {
                                              DispenserId = charger.Id
                                          }).ToList<Port>().Count.ToString(),
                              Available = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Available.GetEnumDisplayName()))
                                           select new DispenserStatus
                                           {
                                               Id = charger.DispenserStatusId,
                                           }
                                           ).ToList<DispenserStatus>().Count.ToString(),
                              Connected = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Connected.GetEnumDisplayName()))
                                           select new DispenserStatus
                                           {
                                               Id = charger.DispenserStatusId,
                                           }).ToList<DispenserStatus>().Count.ToString(),
                              Faulted = (from charger in _dbContext.Dispenser.Where(x => x.LocationId == location.Id && x.DispenserStatus.DispenserStatusName.Equals(Status_Indication.ChargerStatus.Faulted.GetEnumDisplayName()))
                                         select new DispenserStatus
                                         {
                                             Id = charger.DispenserStatusId,
                                         }).ToList<DispenserStatus>().Count.ToString(),
                              ContactNo = location.LocationAddress.MobileNumber.ToString(),
                              ContactName = location.ContactPersonName.ToString(),


                          }).ToList<LocationsDispenserDetails>();
            }
            result = result != null ? result.OrderByDescending(a => a.locationId).ToList() : result;
            if (!string.IsNullOrEmpty(locationDispenserRequest.SearchParam))
                result = result.Where(d => d.LocationName.ToLower().Contains(locationDispenserRequest.SearchParam.ToLower())
             ).ToList<LocationsDispenserDetails>();
            //Paging on Records           

            var dataResult = PagedList<LocationsDispenserDetails>.ToPagedList(result,
              locationDispenserRequest.PageNumber,
              locationDispenserRequest.PageSize);
            return Task.FromResult(dataResult);
        }
        public async Task<List<Core.Response.LocationData>> GetAllLocationName()
        {

            return _dbContext.Locations
                 .Select(m => new Core.Response.LocationData
                 {
                     Id = m.Id,
                     LocationName = m.LocationName
                 }).ToList<Core.Response.LocationData>();


        }
        public Task<List<LocationDispenserForLocation>> GetLocationsDispenserForLocation(List<long> Id)
        {
            List<LocationDispenserForLocation> result = new List<LocationDispenserForLocation>();
            if (Id.Count <= 0)
            {
                result = (from location in _dbContext.Locations
                          join charger in _dbContext.Dispenser
                          on location.Id equals charger.LocationId
                          join model in _dbContext.Model
                          on charger.ModelId equals model.Id
                          join make in _dbContext.MakeMaster
                          on charger.MakeMasterId equals make.Id
                          join protocol in _dbContext.Protocol
                          on model.ProtocolId equals protocol.Id
                          join status in _dbContext.DispenserStatus
                          on charger.DispenserStatusId equals status.Id
                          select new LocationDispenserForLocation
                          {
                              locationId = location.Id,
                              DispenserId = charger.Id,
                              ChargeBoxId = charger.ChargeBoxId,
                              SerialNumber = charger.SerialNumber,
                              ProtocolName = protocol.ProtocolName,
                              ChargerStatus = status.DispenserStatusName,
                              NoofPort = charger.Ports.Where(t => t.DispenserId.Equals(charger.Id)).ToList().Count == 0 ? "0" : charger.Ports.Where(t => t.DispenserId.Equals(charger.Id)).ToList().Count.ToString(),
                              DispenserMake = make.Name,
                              DispenserModel = model.ModelName,
                              ConnectorType = _dbContext.Port.FirstOrDefault(p => p.DispenserId == charger.Id).Connector.ConnectorType,
                              DispenserName = charger.StationName,
                               DispenserStatusId = charger.DispenserStatusId
                          }).ToList<LocationDispenserForLocation>();
            }
            else
            {
                result = (from location in _dbContext.Locations.Where(x => Id.Contains(x.Id))
                          join charger in _dbContext.Dispenser
                          on location.Id equals charger.LocationId
                          join model in _dbContext.Model
                          on charger.ModelId equals model.Id
                          join make in _dbContext.MakeMaster
                          on charger.MakeMasterId equals make.Id
                          join protocol in _dbContext.Protocol
                          on model.ProtocolId equals protocol.Id
                          join status in _dbContext.DispenserStatus
                          on charger.DispenserStatusId equals status.Id
                          select new LocationDispenserForLocation
                          {
                              locationId = location.Id,
                              DispenserId = charger.Id,
                              ChargeBoxId = charger.ChargeBoxId,
                              SerialNumber = charger.SerialNumber,
                              ProtocolName = protocol.ProtocolName,
                              ChargerStatus = status.DispenserStatusName,
                              NoofPort = charger.Ports.Where(t => t.DispenserId.Equals(charger.Id)).ToList().Count == 0 ? "0" : charger.Ports.Where(t => t.DispenserId.Equals(charger.Id)).ToList().Count.ToString(),
                              DispenserMake = make.Name,
                              DispenserModel = model.ModelName,
                              ConnectorType = _dbContext.Port.FirstOrDefault(p => p.DispenserId == charger.Id).Connector.ConnectorType,                          
                              DispenserName = charger.StationName,
                              DispenserStatusId = charger.DispenserStatusId
                          }).ToList<LocationDispenserForLocation>();
            }
            return Task.FromResult(result);



        }
    }
}
