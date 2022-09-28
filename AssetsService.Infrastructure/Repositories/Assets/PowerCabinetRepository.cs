using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using AssetsService.Core.Response;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class PowerCabinetRepository : Repository<AssetsService.Core.Entities.PowerCabinet>, IPowerCabinetRepository
    {
        string JSONString = string.Empty;
        public PowerCabinetRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        
        public async Task<List<GetPowerCabinetResponse>> GetPowerCabinetData()
        {
                 return _dbContext.PowerCabinet
                 .Select(m => new GetPowerCabinetResponse
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     BreakerRating = m.BreakerRating,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     DcPortQuantityRating = m.DcPortQuantityRating,
                     InstallationDate = m.InstallationDate,
                     MakeMasterId = m.MakeMasterId,
                     ModelId = (long)m.ModelId,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     PeakCurrent = m.PeakCurrent,
                     SerialNumber = m.SerialNumber,
                     ServiceVolts = m.ServiceVolts,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,
                     StatusName = m.Status.StatusName,
                     IsActive = m.IsActive,
                     LocationId = m.LocationId,
                     MakeMasterName = m.MakeMaster.Name,
                     ModelName = m.Model.ModelName,
                     LocationName = m.Location.LocationName,
                     StatusId = m.StatusId
                     
                 }).ToList();
        }
        public async Task<GetPowerCabinetResponse> GetPowerCabinetById(long powerCabinetId)
        {
            return _dbContext.PowerCabinet
                 .Select(m => new GetPowerCabinetResponse
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     BreakerRating = m.BreakerRating,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     DcPortQuantityRating = m.DcPortQuantityRating,
                     InstallationDate = m.InstallationDate,
                     MakeMasterId = m.MakeMasterId,
                     ModelId = (long)m.ModelId,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     PeakCurrent = m.PeakCurrent,
                     SerialNumber = m.SerialNumber,
                     ServiceVolts = m.ServiceVolts,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,
                     StatusName = m.Status.StatusName,
                     IsActive = m.IsActive,
                     LocationId = m.LocationId,
                     MakeMasterName = m.MakeMaster.Name,
                     ModelName = m.Model.ModelName,
                     LocationName = m.Location.LocationName,
                     StatusId = m.StatusId
                 }).Where(x => x.Id == powerCabinetId).FirstOrDefault();


        }
    }
}