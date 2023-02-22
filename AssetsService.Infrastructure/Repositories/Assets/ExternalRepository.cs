using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{


    public class ExternalRepository : Repository<Vehicle>, IExternalRepository
    {
        private readonly IVehicleRepository _vehicleRepo;
        public ExternalRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext, IVehicleRepository vehicleRepository) : base(_dbContext)
        {
            _vehicleRepo = vehicleRepository;
        }

        public async Task<CreateVehicleResponseExternal> CreateNewVehicle(Vehicle vehicle)
        {
            CreateVehicleResponseExternal createVehicleResponse = new CreateVehicleResponseExternal();
            VehicleRFID vehicleRFID = new VehicleRFID();
            try
            {

                vehicle.ModifiedBy = vehicle.CreatedBy;
                vehicle.CreatedOn = DateTime.Now;
                vehicle.ModifiedOn = DateTime.Now;
                vehicle.IsActive = true;
                vehicle.UnitNumber = vehicle.UnitNumber;
                

                VehicleDTO dt = await _vehicleRepo.GetVehicleByVinNumber(vehicle.VIN);
                
                if (dt!=null)
                {
                    vehicle.vehicleRFID.ToList().RemoveAll(item => dt.vehicleRFIDIds.Any(item2 => item.Name == item2.Name));//remove already exist rfid from list
                    _dbContext.VehicleRFID.AddRangeAsync(vehicle.vehicleRFID);
                    _dbContext.SaveChanges();

                    createVehicleResponse.VIN = dt.VIN;
                    createVehicleResponse.id = dt.Id;
                }
                else
                {
                    _dbContext.Vehicle.Add(vehicle);
                    _dbContext.SaveChanges();
                    vehicle.vehicleRFID = _dbContext.VehicleRFID.Where(r => r.VehicleId == vehicle.Id).ToList();
                    createVehicleResponse.VIN = vehicle.VIN;
                    createVehicleResponse.id = vehicle.Id;
                }
               
                
                return createVehicleResponse;
            }
            catch (Exception ex)
            {
            }
            return createVehicleResponse;
        }


    }
}
