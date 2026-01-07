using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;
namespace AssetsService.Core.Repositories
{
    public interface IVehicleRepository : IRepository<AssetsService.Core.Entities.Vehicle>
    {
        Task<StatusVehicleresponcse> GetAllVehicle(GetAllVehicleRequest getAllVehicleRequest);
        Task<VehicleDTO> GetVehicleById(long Id);
        Task<VehicleDTO> GetVehicleByVinNumber(string vinnumber);
        Task<CreateVehicleResponse> CreateVehicle(Vehicle vehicle);
        Task<CreateVehicleResponse> UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> GetByIdVehicleData(long Id);
        Task<VehicleRFID> GetVehicleRFIDDetails(long vehicleRfId);
        Task<List<ListDropDown>> GetVehicleMakeDDLList();

        Task<List<ListDropDown>> GetVehicleModelDDLList();
        Task<List<ListDropDown>> GetVehicleModelYearDDLList();
        Task<VehicleListData> GetVehicleList(GetAllVehicleRequest getAllVehicleRequest);
        Task<Vehicle> GetVehicleInfoById(long Id);
        Task<VehicleRFID> GetVehicleRFIDDetailsByName(string RfIdName);
        Task<bool> DeleteVehicleById(int vehicleId);
    }
}