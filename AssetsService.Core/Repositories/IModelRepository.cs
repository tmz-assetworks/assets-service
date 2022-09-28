using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetsService.Core.Response.ModelResponse;

namespace AssetsService.Core.Repositories
{
    public interface IModelRepository : IRepository<AssetsService.Core.Entities.Model>
    {
        Task<List<Model>> GetAllModel();
        Task<Model> GetAllModelById(long id);
        Task<List<AssetsService.Core.Entities.Model>> GetAllModelData(ModelDataRequest modelDataRequest);
        Task<List<ModelList>> GetAllModelList();
    }
}
