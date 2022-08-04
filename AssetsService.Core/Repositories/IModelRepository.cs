using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IModelRepository : IRepository<AssetsService.Core.Entities.Model>
    {
        Task<List<Model>> GetAllModel();
        Task<Model> GetAllModelById(long id);
    }
}
