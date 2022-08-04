using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;

namespace AssetsService.Core.Repositories.Assets
{
    
    public interface IPosRepository : IRepository<AssetsService.Core.Entities.Pos>
    {
        

        Task<List<Pos>> GetAllPos();
        Task<Pos> GetByIdPos(long id);
    }
}

