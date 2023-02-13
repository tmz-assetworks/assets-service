using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Core.Repositories.Assets
{
    
    public interface IModemRepository : IRepository<AssetsService.Core.Entities.Modem>
    {


        Task<PagedList<ModemDTO>> GetAllModem(ModemRequest ModemRequest);
        Task<ModemByIDResponse> GetByIdModem(long id);
        Task<List<ModemTypeNameList>> GetAllModemType();
    }
}

