using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


namespace AssetsService.Infrastructure.Repositories.Assets
{

    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }
        public async Task<StatusVehicleresponcse> GetAllVehicle(GetAllVehicleRequest getAllVehicleRequest)
        {
            StatusVehicleresponcse statusVehicleresponcse = new StatusVehicleresponcse();
            List<Vehicle> result = new List<Vehicle>();
            try
            {
                if (string.IsNullOrEmpty(getAllVehicleRequest.SearchParam) == true)
                {

                    result = await _dbContext.Vehicle

                      .Select(m => new Vehicle
                      {
                          Id = m.Id,
                          VIN = m.VIN,
                          LicencePlate = m.LicencePlate,
                          Department = m.Department,
                          DomicileLocation = m.DomicileLocation,
                          VehicleMacAddress = m.VehicleMacAddress,
                          IsActive = m.IsActive,
                          CreatedBy = m.CreatedBy,
                          CreatedOn = m.CreatedOn,
                          ModifiedBy = m.ModifiedBy,
                          ModifiedOn = m.ModifiedOn,
                          ModelYear = m.ModelYear,
                          ModelName = m.ModelName,
                          MakeName = m.MakeName,
                          UnitNumber = m.UnitNumber,
                          vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id && x.IsActive == true)
                                         select new VehicleRFID
                                         {
                                             Id = obls.Id,
                                             VehicleId = obls.VehicleId,
                                             Name = obls.Name,
                                             IsActive = obls.IsActive,
                                             CreatedBy = obls.CreatedBy,
                                             CreatedOn = obls.CreatedOn,
                                             ModifiedBy = obls.ModifiedBy,
                                             ModifiedOn = obls.ModifiedOn,

                                         }).ToList(),
                      })
                     .OrderByDescending(a => a.Id).ToListAsync();


                }
                else
                    result = await _dbContext.Vehicle.Where(d => d.Department.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()) || d.VehicleMacAddress.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()))
                          .Select(m => new Vehicle
                          {
                              Id = m.Id,
                              VIN = m.VIN,
                              LicencePlate = m.LicencePlate,
                              Department = m.Department,
                              DomicileLocation = m.DomicileLocation,
                              VehicleMacAddress = m.VehicleMacAddress,
                              IsActive = m.IsActive,
                              CreatedBy = m.CreatedBy,
                              CreatedOn = m.CreatedOn,
                              ModifiedBy = m.ModifiedBy,
                              ModifiedOn = m.ModifiedOn,
                              ModelYear = m.ModelYear,
                              ModelName = m.ModelName,
                              MakeName = m.MakeName,
                              UnitNumber = m.UnitNumber,
                              vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id && m.IsActive == true)

                                             select new VehicleRFID
                                             {
                                                 Id = obls.Id,
                                                 Name = obls.Name,
                                                 IsActive = obls.IsActive,
                                                 CreatedBy = obls.CreatedBy,
                                                 VehicleId = obls.VehicleId,
                                                 CreatedOn = obls.CreatedOn,
                                                 ModifiedBy = obls.ModifiedBy,
                                                 ModifiedOn = obls.ModifiedOn,

                                             }).ToList(),

                          })
                         .OrderByDescending(a => a.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                ;
            }
            statusVehicleresponcse.data = PagedList<Vehicle>.ToPagedList(result,
        getAllVehicleRequest.PageNumber,
        getAllVehicleRequest.PageSize);
            statusVehicleresponcse.Active = result.Where(m => m.IsActive == true).Count().ToString();
            statusVehicleresponcse.Inactive = result.Where(m => m.IsActive == false).Count().ToString();
            return (statusVehicleresponcse);
        }
        public async Task<VehicleDTO> GetVehicleById(long Id)
        {
            return _dbContext.Vehicle.Select(m => new VehicleDTO
            {
                Id = m.Id,
                VIN = m.VIN,
                LicencePlate = m.LicencePlate,
                Department = m.Department,
                DomicileLocation = m.DomicileLocation,
                VehicleMacAddress = m.VehicleMacAddress,
                IsActive = m.IsActive,
                //CreatedBy = m.CreatedBy,
                //CreatedOn = m.CreatedOn,
                //ModifiedBy = m.ModifiedBy,
                //ModifiedOn = m.ModifiedOn,
                ModelYear = m.ModelYear,
                ModelName = m.ModelName,
                MakeName = m.MakeName,
                UnitNumber = m.UnitNumber,
                vehicleRFIDIds = m.vehicleRFID.Select(m => new VehicleRFIDId
                {

                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive

                }).ToList(),

            }).Where(m => m.Id == Id).FirstOrDefault();

        }


        public async Task<Vehicle> GetVehicleInfoById(long Id)
        {
            DateTime currentDateTime = DateTime.Now;
            try
            {
                var vehicle = _dbContext.Vehicle
                     .Select(m => new Vehicle
                     {
                         Id = m.Id,
                         VIN = m.VIN,
                         LicencePlate = m.LicencePlate,
                         Department = m.Department,
                         DomicileLocation = m.DomicileLocation,
                         VehicleMacAddress = m.VehicleMacAddress,
                         IsActive = m.IsActive,
                         CreatedBy = m.CreatedBy,
                         CreatedOn = m.CreatedOn,
                         ModifiedBy = m.ModifiedBy,
                         ModifiedOn = m.ModifiedOn,
                         ModelYear = m.ModelYear,
                         ModelName = m.ModelName,
                         MakeName = m.MakeName,
                         UnitNumber = m.UnitNumber,
                         vehicleRFID = (from obls in _dbContext.VehicleRFID.Where(x => x.VehicleId == m.Id)

                                        select new VehicleRFID
                                        {
                                            Id = obls.Id,
                                            Name = obls.Name,
                                            IsActive = obls.IsActive,
                                            CreatedBy = obls.CreatedBy,
                                            VehicleId = obls.VehicleId,
                                            CreatedOn = obls.CreatedOn,
                                            ModifiedBy = obls.ModifiedBy,
                                            ModifiedOn = obls.ModifiedOn,
                                        }).ToList(),

                     }).Where(x => x.Id == Id).FirstOrDefault();

                if (vehicle != null)
                {
                    string[] vehicleRFIDs = _dbContext.VehicleRFID.Where(x => x.VehicleId == vehicle.Id && x.IsActive == true).Select(v => v.Name.ToString()).ToArray();

                    string modelYear = vehicle.ModelYear.ToString();
                    List<SubscriptionsGroupDetails> subscriptionsGroupDetails = _dbContext.SubscriptionsGroupDetails.Where(s => s.IsActive == true && (vehicleRFIDs.Contains(s.Value) && s.Text.ToLower() == "rfid")
                    || (s.Text.ToLower() == "modelyear" && s.Value == modelYear) || (s.Text.ToLower() == "makename" && s.Value == vehicle.MakeName) ||
                   (s.Text.ToLower() == "modelname" && s.Value == vehicle.ModelName) || (s.Text.ToLower() == "vin" && s.Value == vehicle.VIN)
                    ).ToList();

                    List<long> subscriptionsGroupIds = new List<long>();
                    foreach (var subscriptionsGroup in subscriptionsGroupDetails)
                    {
                        subscriptionsGroupIds.Add(subscriptionsGroup.SubscriptionsGroupId);
                    }
                    vehicle.applicableSubscriptionPlans = _dbContext.SubscriptionPlan.Where(x => subscriptionsGroupIds.Contains(x.SubscriptionsGroupId.Value)).OrderBy(p => p.Price)
                    .Where(p => p.ValidFrom <= currentDateTime && p.ValidTo >= currentDateTime && p.IsActive == true).Select(s => new ApplicableSubscriptionPlan
                    {
                        RfIdNumbers = vehicle.vehicleRFID != null ? String.Join(',', vehicle.vehicleRFID.Select(s => s.Name)).ToString() : "",
                        SubscriptionPlanName = s.SubscriptionPlanName,
                        SubscriptionsValue = s.Price.ToString(),
                        ValidFrom = s.ValidFrom,
                        ValidTo = s.ValidTo,
                        Type = s.PriceType.PriceTypeName,

                    }).ToList();
                }
                return vehicle;
            }
            catch (Exception ex)
            {
                ;
            }
            return new Vehicle();
        }
        public async Task<CreateVehicleResponse> CreateVehicle(Vehicle cv)
        {
            CreateVehicleResponse createVehicleResponse = new CreateVehicleResponse();
            VehicleRFID vehicleRFID = new VehicleRFID();
            try
            {

                cv.ModifiedBy = cv.CreatedBy;
                cv.CreatedOn = DateTime.Now;
                cv.ModifiedOn = DateTime.Now;
                cv.IsActive = true;
                cv.UnitNumber=cv.UnitNumber;

                _dbContext.Vehicle.Add(cv);
                _dbContext.SaveChanges();
                cv.vehicleRFID = _dbContext.VehicleRFID.Where(r => r.VehicleId == cv.Id).ToList();
                createVehicleResponse.VIN = cv.VIN;
                createVehicleResponse.id = cv.Id;
                return createVehicleResponse;
            }
            catch (Exception ex)
            {
            }
            return createVehicleResponse;
        }

        public async Task<CreateVehicleResponse> UpdateVehicle(Vehicle cv)
        {
            CreateVehicleResponse createVehicleResponse = new CreateVehicleResponse();
            try
            {
                var obj = string.Join(",", _dbContext.VehicleRFID.Where(r => r.VehicleId != cv.Id).Select(x => x.Name).ToList());
                var x = cv.vehicleRFID.Where(x => obj.Contains(x.Name)).ToList();
                if (x.Count > 0)
                {
                    createVehicleResponse.id = -5;  // RfID is already assigned to vehicle 
                    createVehicleResponse.VIN = x.Select(x => x.Name).FirstOrDefault();
                    return createVehicleResponse;
                }

                cv.ModifiedOn = DateTime.Now;
                _dbContext.Vehicle.Update(cv);
                _dbContext.SaveChanges();
                cv.vehicleRFID = _dbContext.VehicleRFID.Where(r => r.VehicleId == cv.Id).ToList();
                createVehicleResponse.VIN = cv.VIN;
                createVehicleResponse.id = cv.Id;
                createVehicleResponse.DomicileLocation = cv.DomicileLocation;
                createVehicleResponse.Department = cv.Department;
                createVehicleResponse.VehicleMacAddress = cv.VehicleMacAddress;
                createVehicleResponse.LicencePlate = cv.LicencePlate;
                createVehicleResponse.ModelYear = cv.ModelYear;
                createVehicleResponse.MakeName = cv.MakeName;
                createVehicleResponse.ModelName = cv.ModelName;
                createVehicleResponse.ModelYear = cv.ModelYear;
                createVehicleResponse.CreatedBy = cv.CreatedBy;
                createVehicleResponse.CreatedOn = cv.CreatedOn;
                createVehicleResponse.UnitNumber = cv.UnitNumber;
                createVehicleResponse.rfids = cv.vehicleRFID.Select(m => new Rfids
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive

                }).ToList();
                return createVehicleResponse;
            }
            catch (Exception ex)
            {
            }
            return createVehicleResponse;
        }

        public async Task<Vehicle> GetByIdVehicleData(long Id)
        {
            return _dbContext.Vehicle.FirstOrDefault(m => m.Id == Id);
        }

        public async Task<VehicleRFID> GetVehicleRFIDDetails(long Id)
        {
            return _dbContext.VehicleRFID.FirstOrDefault(m => m.Id == Id);
        }
        public async Task<VehicleRFID> GetVehicleRFIDDetailsByName(string RfIdName)
        {

            return _dbContext.VehicleRFID.FirstOrDefault(m => m.Name.ToLower() == RfIdName.ToLower());
        }
        public async Task<List<ListDropDown>> GetVehicleModelDDLList()
        {
            var data = _dbContext.VehicleModel.ToList()
               .Select(m => new ListDropDown
               {
                   Id = m.Id,
                   Name = m.Name,
                   IsActive = m.IsActive,
               }).ToList();
            return data;
        }

        public async Task<List<ListDropDown>> GetVehicleModelYearDDLList()
        {
            var data = _dbContext.VehicleModelYear.ToList().Select(m => new ListDropDown

            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive,
            }).ToList();
            return data;
        }
        public async Task<VehicleListData> GetVehicleList(GetAllVehicleRequest getAllVehicleRequest)
        {
            VehicleListData vehicleListData = new VehicleListData();
            List<VehicleDTO> result = new List<VehicleDTO>();
            if (string.IsNullOrEmpty(getAllVehicleRequest.SearchParam) == true)
            {
                result = _dbContext.Vehicle.Select(m => new VehicleDTO
                {
                    Id = m.Id,
                    VIN = m.VIN,
                    LicencePlate = m.LicencePlate,
                    Department = m.Department,
                    DomicileLocation = m.DomicileLocation,
                    VehicleMacAddress = m.VehicleMacAddress,
                    IsActive = m.IsActive,
                    ModifiedOn = m.ModifiedOn,
                    ModelYear = m.ModelYear,
                    ModelName = m.ModelName,
                    MakeName = m.MakeName,
                    UnitNumber=m.UnitNumber,
                    vehicleRFIDName = m.vehicleRFID != null ? String.Join(',', m.vehicleRFID.Where(m => m.IsActive == true).Select(s => s.Name)) : "",

                    vehicleRFIDIds = m.vehicleRFID.Where(m => m.IsActive == true).Select(m => new VehicleRFIDId
                    {
                        Id = m.Id,
                        Name = m.Name,
                        IsActive = m.IsActive
                    }).ToList()
                }).OrderByDescending(m => m.ModifiedOn).ToList<VehicleDTO>();
            }
            else
                result = _dbContext.Vehicle.Where(d => d.Department.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()) || d.VehicleMacAddress.ToLower().Contains(getAllVehicleRequest.SearchParam.ToLower()))

                        .Select(m => new VehicleDTO
                        {
                            Id = m.Id,
                            VIN = m.VIN,
                            LicencePlate = m.LicencePlate,
                            Department = m.Department,
                            DomicileLocation = m.DomicileLocation,
                            VehicleMacAddress = m.VehicleMacAddress,
                            IsActive = m.IsActive,
                            ModifiedOn = m.ModifiedOn,
                            ModelYear = m.ModelYear,
                            ModelName = m.ModelName,
                            MakeName = m.MakeName,
                            UnitNumber=m.UnitNumber,
                            vehicleRFIDName = m.vehicleRFID != null ? String.Join(',', m.vehicleRFID.Where(m => m.IsActive == true).Select(s => s.Name)) : "",
                            vehicleRFIDIds = m.vehicleRFID.Where(m => m.IsActive == true).Select(m => new VehicleRFIDId
                            {
                                Id = m.Id,
                                Name = m.Name,
                                IsActive = m.IsActive
                            }).ToList()
                        }).OrderByDescending(m => m.ModifiedOn).ToList<VehicleDTO>();

            var dataResult = PagedList<VehicleDTO>.ToPagedList(result,
         getAllVehicleRequest.PageNumber,
         getAllVehicleRequest.PageSize);
            vehicleListData.data = dataResult;
            vehicleListData.Active = _dbContext.Vehicle.Where(m => m.IsActive == true).Count();
            vehicleListData.InActive = _dbContext.Vehicle.Where(m => m.IsActive == false).Count();
            return vehicleListData;
        }
        public async Task<List<ListDropDown>> GetVehicleMakeDDLList()
        {
            var data = _dbContext.VehicleMake.ToList().Select(m => new ListDropDown
            {
                Id = m.Id,
                Name = m.Name,
                IsActive = m.IsActive

            }).ToList();
            return data;
        }

    }
}
