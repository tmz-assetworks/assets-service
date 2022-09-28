using AssetsService.Core.Repositories.Assets.Base;
using AssetsService.Core.Response;
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
        Task<List<GetPadResponse>> GetAllPad();
        Task<GetPadResponse> GetPadById(long padId);



    }
}
