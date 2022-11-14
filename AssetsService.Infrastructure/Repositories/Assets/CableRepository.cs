using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
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
        public async Task<PagedList<Cable>> GetAllCable(GetAllCableRequest getAllCableRequest)
        {
            List<Cable> result = new List<Cable>();
            result = await _dbContext.Cables
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
                     //  NetworkId = m.NetworkId,
                     //  NetworkName = m.NetworkName,
                     SerialNumber = m.SerialNumber,
                     StatusId = m.StatusId,
                     //  SubNetworkId = m.SubNetworkId,
                     //  SubNetworkName = m.SubNetworkName,
                     WarrantyDuration = m.WarrantyDuration,
                     WarrantyExpiryDate = m.WarrantyExpiryDate,
                     WarrantyStartDate = m.WarrantyStartDate,
                     IsActive = m.IsActive,
                     LocationId = m.LocationId,
                     Model = m.Model,
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
                                       CreatedOn = obls.CreatedOn,//==DateTime.MinValue? DateTime.MinValue: obls.CreatedOn),
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
            var dataResult = PagedList<Cable>.ToPagedList(result,
   getAllCableRequest.PageNumber,
   getAllCableRequest.PageSize);
            return (dataResult);
        }
        public async Task<CableData> GetByIdCable(long Cableid)
        {
            return (from m in _dbContext.Cables.Where(t => t.Id == Cableid)
                    select new CableData
                    {
                        Id = m.Id,
                        AssetId = m.AssetId,
                        MakeMasterId = m.MakeMasterId,
                        ModelId = (long)m.ModelId,
                        SerialNumber = m.SerialNumber,
                        LocationName = m.Location.LocationName,
                        ModelName = m.Model.ModelName,
                        StatusName = m.Status.StatusName,
                        WarrantyDuration = m.WarrantyDuration,
                        WarrantyExpiryDate = m.WarrantyExpiryDate,
                        WarrantyStartDate = m.WarrantyStartDate,
                        IsActive = m.IsActive,
                        LocationId = m.LocationId,
                        StatusId = m.StatusId,
                        MakeMasterName = m.MakeMaster.Name

                    }).FirstOrDefault();
        }
        async Task<List<CableListDropDown>> ICableRepository.GetAllCableDropDown(string userId, int? dispenserId)
        {
            List<CableListDropDown> cables = null;
            List<Charger> dsipnser = _dbContext.Charger.Where(m => m.Id != dispenserId.Value).ToList();
            cables = _dbContext.Cables.ToList().Select(m => new CableListDropDown
            {
                Id = m.Id,
                CableSerialNumber = m.SerialNumber,
            }).Where(m => m.CableSerialNumber != "").Where(x => dsipnser.All(p2 => p2.CableId != x.Id)).OrderBy(m => m.CableSerialNumber).ToList();
            return cables;
        }
        public async Task<CreateCableResponse> CreateCable(Cable cable)
        {
            CreateCableResponse createCableResponse = new CreateCableResponse();
            cable.CreatedOn = DateTime.Now;
            cable.ModifiedOn = DateTime.Now;
            cable.IsActive = true;
            cable.ModifiedBy = "";
            _dbContext.Cables.Add(cable);
            _dbContext.SaveChanges();
            createCableResponse.Id = cable.Id;
            return (createCableResponse);
        }
        public async Task<Cable> Updatecable(Cable cable)
        {
            try
            {
                Cable oldCable = _dbContext.Cables.Find(cable.Id);
                oldCable.AssetId = cable.AssetId;
                oldCable.LocationId = cable.LocationId;
                oldCable.MakeMasterId = cable.MakeMasterId;
                oldCable.ModelId = cable.ModelId;
                oldCable.StatusId = cable.StatusId;
                oldCable.WarrantyDuration = cable.WarrantyDuration;
                oldCable.WarrantyExpiryDate = cable.WarrantyExpiryDate;
                oldCable.WarrantyStartDate = cable.WarrantyStartDate;
                oldCable.ModifiedBy = cable.ModifiedBy;
                oldCable.SerialNumber = cable.SerialNumber;
                oldCable.ModifiedOn = DateTime.Now;

                _dbContext.Update(oldCable);
                _dbContext.SaveChanges();

            }
            catch
            {
                cable.Id = 0;
            }
            return (cable);
        }
    }
}
