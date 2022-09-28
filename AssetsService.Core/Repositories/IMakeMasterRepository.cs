using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IMakeMasterRepository : IRepository<AssetsService.Core.Entities.MakeMaster>
    {
        Task<List<MakeMaster>> GetAllMakeMaster();
        Task<MakeMaster> GetAllMakeMasterById(long id);
        Task<List<MakeMasterList>> GetAllMakeMasterList();
    }
}
