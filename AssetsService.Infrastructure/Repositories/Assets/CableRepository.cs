using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class CableRepository : Repository<AssetsService.Core.Entities.Cable>, ICableRepository
    {
        public CableRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<AssetsService.Core.Entities.Cable>> GetEmployeeById(long cableId)

        {
            return await _dbContext.Cables
                .Where(m => m.Id == cableId)
                .ToListAsync();
        }
        public async Task<List<Cable>> GetAllCable()
        {
            return await _dbContext.Cables
                 .Select(m => new Cable
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     InstallationDate = m.InstallationDate,
                     MakeMasterId = m.MakeMasterId,
                     ModelId = m.ModelId,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     NetworkId = m.NetworkId,
                     NetworkName = m.NetworkName,
                     SerialNumber = m.SerialNumber,
                     StatusId = m.StatusId,
                     SubNetworkId = m.SubNetworkId,
                     SubNetworkName = m.SubNetworkName,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,
                     IsActive = m.IsActive,

                     MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                select new MakeMaster
                                {
                                    Id = obls.Id,
                                    Name = obls.Name,
                                    Description = obls.Description,
                                    IsActive = obls.IsActive,
                                    CreatedBy = obls.CreatedBy,
                                    ModifiedBy = obls.ModifiedBy,
                                    ModifiedOn = obls.ModifiedOn,
                                    CreatedOn = (obls.CreatedOn==DateTime.MinValue? DateTime.MinValue: obls.CreatedOn),

                                }).FirstOrDefault(),
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                              select new Status
                              {
                                  Id = obls.Id,
                                  StatusName = obls.StatusName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                 })
                 .ToListAsync();
        }
        public async Task<Cable> GetByIdCable(long Cableid)
        {
            return  _dbContext.Cables
                 .Select(m => new Cable
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     InstallationDate = m.InstallationDate,
                     MakeMasterId = m.MakeMasterId,
                     ModelId = m.ModelId,
                     ModifiedBy = m.ModifiedBy,
                     ModifiedOn = m.ModifiedOn,
                     NetworkId = m.NetworkId,
                     NetworkName = m.NetworkName,
                     SerialNumber = m.SerialNumber,
                     StatusId = m.StatusId,
                     SubNetworkId = m.SubNetworkId,
                     SubNetworkName = m.SubNetworkName,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,
                     IsActive = m.IsActive,

                     MakeMaster = (from obls in _dbContext.MakeMaster.Where(x => x.Id == m.MakeMasterId)
                                   select new MakeMaster
                                   {
                                       Id = obls.Id,
                                       Name = obls.Name,
                                       Description = obls.Description,
                                       IsActive = obls.IsActive,
                                       CreatedBy = obls.CreatedBy,
                                       ModifiedBy = obls.ModifiedBy,
                                       ModifiedOn = obls.ModifiedOn,
                                       CreatedOn = (obls.CreatedOn == DateTime.MinValue ? DateTime.MinValue : obls.CreatedOn),

                                   }).FirstOrDefault(),
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == m.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,
                                   IsActive = obls.IsActive,
                                   CreatedBy = obls.CreatedBy,
                                   CreatedOn = obls.CreatedOn,
                                   ModifiedBy = obls.ModifiedBy,
                                   ModifiedOn = obls.ModifiedOn,

                               }).FirstOrDefault(),
                 }).Where(x => x.Id == Cableid).FirstOrDefault();
        }

    }
}
