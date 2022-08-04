using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Repositories
{
    public interface IVehicleRepository : IRepository<AssetsService.Core.Entities.Vehicle>
    {
        Task<List<Vehicle>> GetAllVehicle();
        Task<Vehicle> GetAllVehicleById(long id);
    }
}
