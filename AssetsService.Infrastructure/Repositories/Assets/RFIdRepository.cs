using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{


    public class RFIdRepository : Repository<RFIDReader>, IRFIdRepository
    {
        public RFIdRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }
        public async Task<PagedList<RFIDReaderDetails>> GetAllRfIdReader(RfIdReaderRequest rFIDReaderRequest)
        {
            var rfIdReaders = (from RFIDReaders in _dbContext.RFIDReaders
                               join Models in _dbContext.Model
                                       on RFIDReaders.ModelId equals Models.Id
                               join MakeMasters in _dbContext.MakeMaster
                               on RFIDReaders.MakeMasterId equals MakeMasters.Id
                               join Locations in _dbContext.Locations
                                   on RFIDReaders.LocationId equals Locations.Id
                               join LocationStatus in _dbContext.LocationStatus
                               on Locations.LocationStatusId equals LocationStatus.Id
                               select new RFIDReaderDetails
                               {
                                   Id = RFIDReaders.Id,
                                   AssetId = RFIDReaders.AssetId,
                                   CardReader = RFIDReaders.CardReader,
                                   CreatedBy = RFIDReaders.CreatedBy,
                                   CreatedOn = RFIDReaders.CreatedOn,
                                   IsActive = RFIDReaders.IsActive,
                                   MakeMasterId = RFIDReaders.MakeMasterId,
                                   ModelId = RFIDReaders != null ? (long)RFIDReaders.ModelId : 0,
                                   ModifiedBy = RFIDReaders.ModifiedBy != null ? RFIDReaders.ModifiedBy : "",
                                   ModifiedOn = RFIDReaders.ModifiedOn,
                                   SerialNumber = RFIDReaders.SerialNumber,
                                   StatusId = RFIDReaders.StatusId,
                                   MakeMasterName = MakeMasters.Name != null ? MakeMasters.Name : "",
                                   ModelName = Models.ModelName != null ? Models.ModelName : "",
                                   WarrantyDuration = RFIDReaders.WarrantyDuration,
                                   WarrantyExpiryDate = RFIDReaders.WarrantyExpiryDate,
                                   LocationId = RFIDReaders.LocationId,
                                   WarrantyStartDate = RFIDReaders.WarrantyStartDate,
                                   LocationName = Locations.LocationName,
                                   StatusName = LocationStatus.LocationStatusName
                               }).Where(m => m.CardReader.ToLower().Contains(rFIDReaderRequest.SearchParam.ToLower())).ToList();
            rfIdReaders = rfIdReaders != null ? rfIdReaders.OrderByDescending(a => a.ModifiedOn).ToList() : rfIdReaders;

            //Paging on Records        
            var dataResult = PagedList<RFIDReaderDetails>.ToPagedList(rfIdReaders,
              rFIDReaderRequest.PageNumber,
              rFIDReaderRequest.PageSize);
            return await Task.FromResult(dataResult);
        }
        public async Task<List<RFIDReader>> GetAllRfIdReaderData(RfIdReaderDataRequest rFIDReaderRequest)
        {
            var rfIds = _dbContext.Charger.Where(m => m.Id != rFIDReaderRequest.dispenserId.Value).Select(m => m.RFIDReaderId).ToList();
            var data =  _dbContext.RFIDReaders
                 .Select(m => new RFIDReader
                 {
                     Id = m.Id,
                     CardReader = m.CardReader,
                     IsActive = m.IsActive                     
                 }).Where(m => m.CardReader != "").Where(x => rfIds.All(RFIDReaderId => RFIDReaderId != x.Id)).Where(m => m.CardReader != "").OrderBy(m => m.CardReader).ToList();
            return data;
        }
        public async Task<RFIDReaderDetails> GetByIdRfIdReader(long id)
        {
            RFIDReaderDetails data = new RFIDReaderDetails();
            try
            {
                data = (from RFIDReaders in _dbContext.RFIDReaders
                        join Models in _dbContext.Model
                                on RFIDReaders.ModelId equals Models.Id
                        join MakeMasters in _dbContext.MakeMaster
                        on RFIDReaders.MakeMasterId equals MakeMasters.Id
                        join Locations in _dbContext.Locations
                            on RFIDReaders.LocationId equals Locations.Id
                        join LocationStatus in _dbContext.LocationStatus
                        on Locations.LocationStatusId equals LocationStatus.Id
                        select new RFIDReaderDetails
                        {
                            Id = RFIDReaders.Id,
                            AssetId = RFIDReaders.AssetId,
                            CardReader = RFIDReaders.CardReader,
                            CreatedBy = RFIDReaders.CreatedBy,
                            CreatedOn = RFIDReaders.CreatedOn,
                            IsActive = RFIDReaders.IsActive,
                            MakeMasterId = RFIDReaders.MakeMasterId,
                            ModelId = RFIDReaders != null ? (long)RFIDReaders.ModelId : 0,
                            ModifiedBy = RFIDReaders.ModifiedBy != null ? RFIDReaders.ModifiedBy : "",
                            ModifiedOn = RFIDReaders.ModifiedOn,
                            SerialNumber = RFIDReaders.SerialNumber,
                            StatusId = RFIDReaders.StatusId,
                            MakeMasterName = MakeMasters.Name != null ? MakeMasters.Name : "",
                            ModelName = Models.ModelName != null ? Models.ModelName : "",
                            WarrantyDuration = RFIDReaders.WarrantyDuration,
                            WarrantyExpiryDate = RFIDReaders.WarrantyExpiryDate,
                            LocationId = RFIDReaders.LocationId,
                            WarrantyStartDate = RFIDReaders.WarrantyStartDate,
                            LocationName = Locations.LocationName,
                            StatusName = LocationStatus.LocationStatusName
                        }).Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return data;
        }
        public async Task<RFIDReader> GetByIdRfIdReaderData(long Id)
        {
            var data = await _dbContext.RFIDReaders.FindAsync(Id);
            return data;
        }
    }
}
