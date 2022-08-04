using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class PowerCabinetRepository : Repository<AssetsService.Core.Entities.PowerCabinet>, IPowerCabinetRepository
    {
        string JSONString = string.Empty;
        public PowerCabinetRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }

        public async Task<PowerCabinet> GetPowerCabinetById(long powerCabinetId)
        {
            return _dbContext.PowerCabinet
                 .Select(m => new PowerCabinet
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     BreakerRating = m.BreakerRating,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     DcPortQuantityRating = m.DcPortQuantityRating,
                     InstallationDate = m.InstallationDate,
                     MakeId = m.MakeId,
                     ModelId = m.ModelId,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     NetworkId = m.NetworkId,
                     NetworkName = m.NetworkName,
                     PeakCurrent = m.PeakCurrent,
                     SerialNumber = m.SerialNumber,
                     ServiceVolts = m.ServiceVolts,
                     SubNetworkId = m.SubNetworkId,
                     SubNetworkName = m.SubNetworkName,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,

                     
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,

                               }).FirstOrDefault(),
                 }).Where(x => x.Id == powerCabinetId).FirstOrDefault();


        }
    }
}