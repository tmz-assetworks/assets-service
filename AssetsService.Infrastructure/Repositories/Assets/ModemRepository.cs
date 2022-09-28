using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class ModemRepository : Repository<AssetsService.Core.Entities.Modem>, IModemRepository
    {
        #pragma warning disable
        public ModemRepository(AssetsService.Infrastructure.DBContext.DBContextCore dbContext) : base(dbContext)
        {

        }        
        public  Task<PagedList<ModemDTO>> GetAllModem(ModemRequest ModemRequest)
        {
            ModemResponse re = new ModemResponse();           
          
                List<ModemDTO> query = (from Modem in _dbContext.Modem
                                        
                                        select new ModemDTO
                                        {
                                            Id = Modem.Id,
                                            AssetId = Modem.AssetId,
                                            Carrier = Modem.Carrier,
                                            ImeiNumber = Modem.ImeiNumber,
                                            InstallationDate = Modem.InstallationDate,
                                            IpAddress = Modem.IpAddress,
                                            MakeMasterId = Modem.MakeMasterId,
                                            ModelId =(long) Modem.ModelId,
                                            MakeMasterName = Modem.MakeMaster.Name,
                                            ModelName = Modem.Model.ModelName,
                                            SerialNumber = Modem.SerialNumber,
                                            SimNumber = Modem.SimNumber,
                                            StatusId = Modem.StatusId,
                                            ModemTypeId = Modem.ModemTypeId,
                                            ModemTypeName = Modem.ModemType.ModemTypeName,
                                            WarrantyDuration = Modem.WarrantyDuration,
                                            WarrantyExpiryDate = Modem.WarrantyExpiryDate,
                                            WarrantyStartDate = Modem.WarrantyStartDate,
                                            LocationId = Modem.LocationId,
                                            IsActive = Modem.IsActive,
                                            LocationName = Modem.Location.LocationName,
                                            ModifiedAt = Modem.ModifiedOn,
                                            StatusName = Modem.Status.StatusName,
                                        }
                           ).OrderByDescending(a => a.ModifiedAt).ToList();
                
                var dataResult = PagedList<ModemDTO>.ToPagedList(query,
             ModemRequest.PageNumber,
             ModemRequest.PageSize);
                return Task.FromResult(dataResult);         

        }    
        async Task<ModemByIDResponse> IModemRepository.GetByIdModem(long id)
        {
            ModemByIDResponse re = new ModemByIDResponse();

            try
            {
                ModemDTO query = (from Modem in _dbContext.Modem
                                        
                                        select new ModemDTO
                                        {
                                            Id = Modem.Id,
                                            AssetId = Modem.AssetId,
                                            Carrier = Modem.Carrier,
                                            ImeiNumber = Modem.ImeiNumber,
                                            InstallationDate = Modem.InstallationDate,
                                            IpAddress = Modem.IpAddress,
                                            MakeMasterId = Modem.MakeMasterId,
                                            ModelId = (long)Modem.ModelId,
                                            MakeMasterName = Modem.MakeMaster.Name,
                                            ModelName = Modem.Model.ModelName,
                                            SerialNumber = Modem.SerialNumber,
                                            SimNumber = Modem.SimNumber,
                                            StatusId = Modem.StatusId,
                                            ModemTypeId = Modem.ModemTypeId,
                                            ModemTypeName = Modem.ModemType.ModemTypeName,
                                            WarrantyDuration = Modem.WarrantyDuration,
                                            WarrantyExpiryDate = Modem.WarrantyExpiryDate,
                                            WarrantyStartDate = Modem.WarrantyStartDate,
                                            LocationId = Modem.LocationId,
                                            IsActive = Modem.IsActive,
                                            LocationName = Modem.Location.LocationName,
                                            ModifiedAt = Modem.ModifiedOn,
                                            StatusName= Modem.Status.StatusName,
                                            

                                        }
                           ).Where(d => d.Id == id).OrderByDescending(a => a.ModifiedAt).FirstOrDefault();
                if (query !=null)
                {
                    re.StatusCode = 200;
                    re.StatusMessage = "Record found!";
                    re.data = query;
                   
                }
                else
                {
                    re.StatusCode = 200;
                    re.StatusMessage = "Record not found";
                    re.data = null;
                }
            }
            catch (Exception ex)
            {
                re.StatusCode = 500;
                re.StatusMessage = "Internal server Error";
            }
            return re;
        }
    }
}
