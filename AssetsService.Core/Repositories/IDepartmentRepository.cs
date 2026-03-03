using AssetsService.Core.Entities;
using AssetsService.Core.Response;

namespace AssetsService.Core.Repositories
{
    public interface IDepartmentRepository
    {
        Task<CreateDepartmentResult> CreateDepartment(Department department);
        Task<CreateDepartmentResult> UpdateDepartment(Department department);
        Task<StatusAllDepartmentResponse> GetAllDepartment(GetAllDepartmentRequest getAllDepartmentRequest);
        Task<Department?> GetDepartmentInfoById(long Id);
        Task<bool> DeleteDepartmentById(int vehicleId);
    }
}
