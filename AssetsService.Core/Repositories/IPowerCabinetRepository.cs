

using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;

namespace AssetsService.Core.Repositories.Assets
{
    public interface IPowerCabinetRepository : IRepository<AssetsService.Core.Entities.PowerCabinet>
    {

        Task<AssetsService.Core.Entities.PowerCabinet> GetPowerCabinetById(long powerCabinetId);


    }
}