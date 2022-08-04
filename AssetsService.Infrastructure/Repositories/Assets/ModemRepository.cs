using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class ModemRepository : Repository<AssetsService.Core.Entities.Modem>, IModemRepository
    {
        public ModemRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<AssetsService.Core.Entities.Modem>> GetModemById(long modemId)
        {
            return await _dbContext.Modem
                .Where(abc => abc.Id == modemId)
                .ToListAsync();
        }
        public async Task<List<Modem>> GetAllModem()
        {
            return await _dbContext.Modem
                 .Select(abc => new Modem
                 {
                     Id = abc.Id,
                     AssetId = abc.AssetId,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     InstallationDate = abc.InstallationDate,
                     Carrier = abc.Carrier,
                     ModelId = abc.ModelId,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     NetworkId = abc.NetworkId,
                     NetworkName = abc.NetworkName,
                     SerialNumber = abc.SerialNumber,
                     StatusId = abc.StatusId,
                     LocationId = abc.LocationId,
                     ModemTypeId = abc.ModemTypeId,
                     SubNetworkId = abc.SubNetworkId,
                     SubNetworkName = abc.SubNetworkName,
                     WarrantyDuration = abc.WarrantyDuration,
                     WarrantyExpiryDate = abc.WarrantyExpiryDate,
                     WarrantyStartDate = abc.WarrantyStartDate,
                     IpAddress = abc.IpAddress,
                     MakeId = abc.MakeId,
                     SimNumber= abc.SimNumber,
                     ImeiNumber = abc.ImeiNumber,
                      Location = (from obls in _dbContext.Locations.Where(x => x.Id == abc.LocationId)
                                select new Location
                                {
                                    Id = obls.Id,
                                    LocationName = obls.LocationName,
                                    IsActive = obls.IsActive,
                                    CreatedBy = obls.CreatedBy,
                                    ModifiedBy = obls.ModifiedBy,
                                    ModifiedOn = obls.ModifiedOn,
                                    CreatedOn = (obls.CreatedOn==DateTime.MinValue? DateTime.MinValue: obls.CreatedOn),

                                }).FirstOrDefault(),

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
                              
                 
                 ModemType = (from obls in _dbContext.ModemType.Where(x => x.Id == abc.ModemTypeId)
                              select new ModemType
                              {
                                  Id = obls.Id,
                                  ModemTypeName = obls.ModemTypeName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                              
                 })
                 .ToListAsync();



                     
                     
          
        }
        public async Task<Modem> GetByIdModem(long Modemid)
        {
            return  _dbContext.Modem
                 .Select(abc => new Modem
                 {
                      Id = abc.Id,
                     AssetId = abc.AssetId,
                     CreatedBy = abc.CreatedBy,
                     CreatedOn = abc.CreatedOn,
                     InstallationDate = abc.InstallationDate,
                     Carrier = abc.Carrier,
                     ModelId = abc.ModelId,
                     ModifiedBy = abc.ModifiedBy,
                     ModifiedOn = abc.ModifiedOn,
                     NetworkId = abc.NetworkId,
                     NetworkName = abc.NetworkName,
                     SerialNumber = abc.SerialNumber,
                     StatusId = abc.StatusId,
                     SubNetworkId = abc.SubNetworkId,
                     SubNetworkName = abc.SubNetworkName,
                     WarrantyDuration = abc.WarrantyDuration,
                     WarrantyExpiryDate = abc.WarrantyExpiryDate,
                     WarrantyStartDate = abc.WarrantyStartDate,
                     IpAddress = abc.IpAddress,
                     MakeId = abc.MakeId,
                     SimNumber= abc.SimNumber,
                     ImeiNumber = abc.ImeiNumber,

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
                               ModemType = (from obls in _dbContext.ModemType.Where(x => x.Id == abc.ModemTypeId)
                              select new ModemType
                              {
                                  Id = obls.Id,
                                  ModemTypeName = obls.ModemTypeName,
                                  IsActive = obls.IsActive,
                                  CreatedBy = obls.CreatedBy,
                                  CreatedOn = obls.CreatedOn,
                                  ModifiedBy = obls.ModifiedBy,
                                  ModifiedOn = obls.ModifiedOn,

                              }).FirstOrDefault(),
                              Location = (from obls in _dbContext.Locations.Where(x => x.Id == abc.LocationId)
                                select new Location
                                {
                                    Id = obls.Id,
                                    LocationName = obls.LocationName,
                                    IsActive = obls.IsActive,
                                    CreatedBy = obls.CreatedBy,
                                    ModifiedBy = obls.ModifiedBy,
                                    ModifiedOn = obls.ModifiedOn,
                                    CreatedOn = (obls.CreatedOn==DateTime.MinValue? DateTime.MinValue: obls.CreatedOn),

                                }).FirstOrDefault()
                 }).Where(x => x.Id == Modemid).FirstOrDefault();
        }

    }
}
