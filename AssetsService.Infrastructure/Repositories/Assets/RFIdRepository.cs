using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class RFIdRepository : Repository<AssetsService.Core.Entities.RFIDReader>, IRFIdRepository
    {
        public RFIdRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }
        public async Task<List<RFIDReader>> GetAllRfIdReader()
        {
            return await _dbContext.RFIDReaders
                 .Select(m => new RFIDReader
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CardReader = m.CardReader,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     IsActive = m.IsActive,
                     MakeId = m.MakeId,
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
                     LocationId = m.LocationId,
                     WarrantyStartDate = m.WarrantyStartDate,
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                           select new Location
                                           {
                                               Id = obls.Id,
                                               LocationAddressId = obls.LocationAddressId,
                                               LocationStatusId = obls.LocationStatusId,
                                            
                                               ContactPersonName = obls.ContactPersonName,
                                               GlobalTax = obls.GlobalTax,
                                               TotalCapacity = obls.TotalCapacity,
                                               UtilityService = obls.UtilityService,
                                               CreatedBy = m.CreatedBy,
                                               Description = obls.Description,
                                               IsActive = obls.IsActive,
                                               ModifiedBy = obls.ModifiedBy,
                                               ModifiedOn = obls.ModifiedOn,
                                               
                                               
                                               LocationName = obls.LocationName,
                                               LocationNumber = obls.LocationNumber,
                                               
                                               
                                               TimeZone = obls.TimeZone,
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
                 })
                 .ToListAsync();
        }

        public async Task<RFIDReader> GetByIdRfIdReader(long id)
        {
            return  _dbContext.RFIDReaders
                 .Select(m => new RFIDReader
                 {
                     Id = m.Id,
                     AssetId = m.AssetId,
                     CardReader = m.CardReader,
                     CreatedBy = m.CreatedBy,
                     CreatedOn = m.CreatedOn,
                     IsActive = m.IsActive,
                     MakeId = m.MakeId,
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
                     LocationId = m.LocationId,
                     WarrantyStartDate = m.WarrantyStartDate,
                     Location = (from obls in _dbContext.Locations.Where(x => x.Id == m.LocationId)
                                 select new Location
                                 {
                                     Id = obls.Id,
                                     LocationAddressId = obls.LocationAddressId,
                                     LocationStatusId = obls.LocationStatusId,
                                     
                                     ContactPersonName = obls.ContactPersonName,
                                     GlobalTax = obls.GlobalTax,
                                     TotalCapacity = obls.TotalCapacity,
                                     UtilityService = obls.UtilityService,
                                     CreatedBy = m.CreatedBy,
                                     Description = obls.Description,
                                     IsActive = obls.IsActive,
                                     ModifiedBy = obls.ModifiedBy,
                                     ModifiedOn = obls.ModifiedOn,
                                     
                                     
                                     LocationName = obls.LocationName,
                                     LocationNumber = obls.LocationNumber,
                                     
                                     
                                     TimeZone = obls.TimeZone,
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
                 }).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
