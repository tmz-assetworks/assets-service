using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
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
    public class CombineAssetRepository : Repository<CombineAsset>, ICombineAssetRepository
    {
#pragma warning disable
        public CombineAssetRepository(DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }

        public Task<CombineAssetResponse> GetCombineAssetList(CombineAssetRequest CombineAssetRequest)
        {
            CombineAssetResponse onj = new CombineAssetResponse();
            List<CombineAsset> Finallist = new List<CombineAsset>();
            List<CombineAsset> cablequery = new List<CombineAsset>();
            List<CombineAsset> Modemquery = new List<CombineAsset>();
            List<CombineAsset> powercabinetmquery = new List<CombineAsset>();
            List<CombineAsset> RFIDReadersquery = new List<CombineAsset>();
            List<CombineAsset> Padsquery = new List<CombineAsset>();

             Padsquery = (from Pads in _dbContext.Pads
                         join Locations in _dbContext.Locations
                                   on Pads.LocationId equals Locations.Id
                         join LocationStatus in _dbContext.LocationStatus
                         on Locations.LocationStatusId equals LocationStatus.Id
                         select new CombineAsset
                         {
                             Id = Pads.Id,
                             AssetId = Pads.AssetId,
                             LocationName = Locations.LocationName,
                             SerialNumber = Pads.SerialNumber.ToString(),
                             IsActive = Pads.IsActive,
                             locationStatus= LocationStatus.LocationStatusName,
                             Type = "Pads",
                             ModifiedAt = Pads.ModifiedOn
                         }).ToList();



            powercabinetmquery = (from PowerCabinet in _dbContext.PowerCabinet
                                  join Locations in _dbContext.Locations
                                   on PowerCabinet.LocationId equals Locations.Id
                                  join LocationStatus in _dbContext.LocationStatus
                                on Locations.LocationStatusId equals LocationStatus.Id

                                  select new CombineAsset
                                  {
                                      Id = PowerCabinet.Id,
                                      AssetId = PowerCabinet.AssetId,
                                      LocationName = Locations.LocationName,
                                      SerialNumber = PowerCabinet.SerialNumber.ToString(),
                                      IsActive = PowerCabinet.IsActive,
                                      locationStatus = LocationStatus.LocationStatusName,
                                      Type = "PowerCabinet",
                                      ModifiedAt = PowerCabinet.ModifiedOn
                                  }).ToList();

            RFIDReadersquery = (from RFIDReaders in _dbContext.RFIDReaders
                                join Locations in _dbContext.Locations
                                   on RFIDReaders.LocationId equals Locations.Id
                                join LocationStatus in _dbContext.LocationStatus
                                 on Locations.LocationStatusId equals LocationStatus.Id

                                select new CombineAsset
                                {
                                    Id = RFIDReaders.Id,
                                    AssetId = RFIDReaders.AssetId,
                                    LocationName = Locations.LocationName,
                                    SerialNumber = RFIDReaders.SerialNumber.ToString(),
                                    locationStatus = LocationStatus.LocationStatusName,
                                    IsActive = RFIDReaders.IsActive,
                                    Type = "RFIDReaders",
                                    ModifiedAt = RFIDReaders.ModifiedOn
                                }).ToList();

            Modemquery = (from Modem in _dbContext.Modem
                          join Locations in _dbContext.Locations
                          on Modem.LocationId equals Locations.Id
                          join LocationStatus in _dbContext.LocationStatus
                        on Locations.LocationStatusId equals LocationStatus.Id

                          select new CombineAsset
                          {
                              Id = Modem.Id,
                              AssetId = Modem.AssetId,
                              LocationName = Locations.LocationName,
                              SerialNumber = Modem.SerialNumber.ToString(),
                              locationStatus = LocationStatus.LocationStatusName,
                              IsActive = Modem.IsActive,
                              Type = "Modem",
                              ModifiedAt = Modem.ModifiedOn
                          }).ToList();

            


            cablequery = (from Cables in _dbContext.Cables
                          join Locations in _dbContext.Locations
                          on Cables.LocationId equals Locations.Id
                          join LocationStatus in _dbContext.LocationStatus
                        on Locations.LocationStatusId equals LocationStatus.Id
                          select new CombineAsset
                          {
                              Id = Cables.Id,
                              AssetId = Cables.AssetId,
                              LocationName = Locations.LocationName,
                              SerialNumber = Cables.SerialNumber,
                              IsActive = Cables.IsActive,
                              locationStatus = LocationStatus.LocationStatusName,
                              Type = "Cables",
                              ModifiedAt = Cables.ModifiedOn
                          }).ToList();

            Finallist.AddRange(cablequery);
            Finallist.AddRange(Modemquery);
            Finallist.AddRange(powercabinetmquery);
            Finallist.AddRange(RFIDReadersquery);
            Finallist.AddRange(Padsquery);

            onj.data= Finallist;

            return Task.FromResult(onj);
        }
    }
}
