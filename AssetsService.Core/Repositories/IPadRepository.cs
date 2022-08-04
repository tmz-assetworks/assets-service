using AssetsService.Core.Repositories.Assets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IPadRepository : IRepository<AssetsService.Core.Entities.Pad>
    {
        //custom operations here
        Task<List<AssetsService.Core.Entities.Pad>> GetAllPad();
        Task<AssetsService.Core.Entities.Pad> GetPadById(long padId);



    }
}
