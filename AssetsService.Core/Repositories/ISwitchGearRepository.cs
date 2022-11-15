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
    public interface ISwitchGearRepository : IRepository<AssetsService.Core.Entities.SwitchGear>
    {
        Task<GetSwitchGearResponse> GetSwitchGearById(long switchGearId);
        Task<AllSwitchGearResponse> GetAllSwitchGears(SwitchGearRequest switchGearRequest);
        Task<List<ListSwitchGear>> GetSwitchGearDLList(string userId, int? dispenserId);
    }
}
