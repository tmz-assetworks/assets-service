using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class PosRepository : Repository<AssetsService.Core.Entities.Pos>, IPosRepository
    {
        public PosRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<AssetsService.Core.Entities.Pos>> GetPosById(long posId)
        {
            return await _dbContext.Pos
                .Where(abc => abc.Id == posId)
                .ToListAsync();
        }
         public async Task<List<Pos>> GetAllPos()
        {
            return await _dbContext.Pos
                 .Select(abc => new Pos
                 {
                     Id = abc.Id,
                     AssetId = abc.AssetId,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     InstallationDate = abc.InstallationDate,
                     ModelId = abc.ModelId,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     NetworkId = abc.NetworkId,
                     NetworkName = abc.NetworkName,
                     SerialNumber = abc.SerialNumber,
                     SubNetworkId = abc.SubNetworkId,
                     SubNetworkName = abc.SubNetworkName,
                     WarrantyDuration = abc.WarrantyDuration,
                     WarrantyExpiryDate = abc.WarrantyExpiryDate,
                     WarrantyStartDate = abc.WarrantyStartDate,
                     MakeId = abc.MakeId,
                     CardReaderType = abc.CardReaderType,
                     Password = abc.Password,
                     StatusId = abc.StatusId,
                     UserName = abc.UserName,
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == abc.StatusId)
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
 public async Task<Pos> GetByIdPos(long Posid)
        {
            return  _dbContext.Pos
                 .Select(abc => new Pos
                 {

                     Id = abc.Id,
                     AssetId = abc.AssetId,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     InstallationDate = abc.InstallationDate,
                     ModelId = abc.ModelId,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     NetworkId = abc.NetworkId,
                     NetworkName = abc.NetworkName,
                     SerialNumber = abc.SerialNumber,
                     SubNetworkId = abc.SubNetworkId,
                     SubNetworkName = abc.SubNetworkName,
                     WarrantyDuration = abc.WarrantyDuration,
                     WarrantyExpiryDate = abc.WarrantyExpiryDate,
                     WarrantyStartDate = abc.WarrantyStartDate,
                     MakeId = abc.MakeId,
                     CardReaderType = abc.CardReaderType,
                     Password = abc.Password,
                     StatusId = abc.StatusId,
                     UserName = abc.UserName,
                     Status = (from obls in _dbContext.Status.Where(x => x.Id == abc.StatusId)
                               select new Status
                               {
                                   Id = obls.Id,
                                   StatusName = obls.StatusName,
                                   IsActive = obls.IsActive,
                                   CreatedBy = obls.CreatedBy,
                                   CreatedOn = obls.CreatedOn,
                                   ModifiedBy = obls.ModifiedBy,
                                   ModifiedOn = obls.ModifiedOn,

                               }).FirstOrDefault()
                 
                 }).Where(x => x.Id == Posid).FirstOrDefault();
    
    }}}