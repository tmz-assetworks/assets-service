using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;

namespace AssetsService.Core.Repositories.Assets
{
    
    public interface IModemRepository : IRepository<AssetsService.Core.Entities.Modem>
    {
        

        Task<List<Modem>> GetAllModem();
        Task<Modem> GetByIdModem(long id);
    }
}

