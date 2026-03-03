using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using AssetsService.Infrastructure.Repositories.Repository;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssetsService.Infrastructure.Repositories.Assets
{
    public class DepartmentRepository : Repository<Vehicle>, IDepartmentRepository
    {
        public DepartmentRepository(AssetsService.Infrastructure.DBContext.DBContextCore _dbContext) : base(_dbContext)
        {

        }

        public async Task<CreateDepartmentResult> CreateDepartment(Department department)
        {
            try
            {
                if (department == null || string.IsNullOrWhiteSpace(department.DepartmentName))
                {
                    return new CreateDepartmentResult
                    {
                        Id = 0,
                        DepartmentName = null
                    };
                }

                var deptName = department.DepartmentName.Trim();

                var exists = await _dbContext.Department.AnyAsync(x => x.DepartmentName.ToLower() == deptName.ToLower());

                if (exists)
                {
                    return new CreateDepartmentResult
                    {
                        Id = -1,
                        DepartmentName = deptName
                    };
                }

                var entity = new Department
                {
                    DepartmentName = deptName,
                    ContactPersonName = "N/A",
                    ModifiedBy = department.CreatedBy,
                    CreatedBy = department.CreatedBy,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    Address = "N/A",
                };

                _dbContext.Department.Add(entity);
                await _dbContext.SaveChangesAsync();

                return new CreateDepartmentResult
                {
                    Id = entity.Id,
                    DepartmentName = entity.DepartmentName
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while creating department");

                return new CreateDepartmentResult
                {
                    Id = 0,
                    DepartmentName = null
                };
            }
        }

        public async Task<CreateDepartmentResult> UpdateDepartment(Department department)
        {
            if (department == null || string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                return new CreateDepartmentResult
                {
                    Id = 0,
                    DepartmentName = null
                };
            }
            try
            {
                var existingDepartment = await _dbContext.Department.FirstOrDefaultAsync(d => d.Id == department.Id);
                var deptName = department.DepartmentName.Trim();
                var duplicateExists = await _dbContext.Department.AnyAsync(d => d.Id != department.Id && d.DepartmentName.ToLower() == deptName.ToLower());
                if (duplicateExists)
                {
                    return new CreateDepartmentResult
                    {
                        Id = -1,
                        DepartmentName = deptName
                    };
                }

                existingDepartment!.DepartmentName = deptName;
                existingDepartment.IsActive = department.IsActive;
                existingDepartment.ModifiedBy = department.CreatedBy;
                existingDepartment.ModifiedOn = DateTime.UtcNow;

                // 4️⃣ Save changes
                await _dbContext.SaveChangesAsync();

                return new CreateDepartmentResult
                {
                    Id = existingDepartment.Id,
                    DepartmentName = existingDepartment.DepartmentName
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while updating department");
                throw; // don't swallow update errors
            }
        }

        public async Task<StatusAllDepartmentResponse> GetAllDepartment(GetAllDepartmentRequest request)
        {
            try
            {
                var query =
                    from d in _dbContext.Department.AsNoTracking()
                    join u in _dbContext.Users.AsNoTracking()
                        on d.CreatedBy equals u.Id.ToString() into userJoin
                    from user in userJoin.DefaultIfEmpty() // LEFT JOIN
                    select new DepartmentListDto
                    {
                        Id = d.Id,
                        DepartmentName = d.DepartmentName,
                        ContactPersonName = d.ContactPersonName,
                        Address = d.Address,
                        IsActive = d.IsActive,
                        CreatedOn = d.CreatedOn,
                        CreatedByUserName = d.CreatedBy
                    };

                // 🔍 Search
                if (!string.IsNullOrWhiteSpace(request.SearchParam))
                {
                    var search = request.SearchParam.Trim().ToLower();

                    query = query.Where(d =>
                        d.DepartmentName.ToLower().Contains(search));
                }

                // 📊 Counts
                var activeCount = await query.CountAsync(d => d.IsActive);
                var inactiveCount = await query.CountAsync(d => !d.IsActive);

                // 📄 Paging
                var result = await query
                    .OrderByDescending(d => d.Id)
                    .ToListAsync();

                return new StatusAllDepartmentResponse
                {
                    data = PagedList<DepartmentListDto>.ToPagedList(
                        result,
                        request.PageNumber,
                        request.PageSize),

                    Active = activeCount.ToString(),
                    Inactive = inactiveCount.ToString()
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching departments");
                throw;
            }
        }


        public async Task<Department?> GetDepartmentInfoById(long id)
        {
            return await _dbContext.Department
                .AsNoTracking()
                .Select(d => new Department
                {
                    Id = d.Id,
                    DepartmentName = d.DepartmentName,
                    ContactPersonName = d.ContactPersonName,
                    Address = d.Address,
                    IsActive = d.IsActive
                })
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<bool> DeleteDepartmentById(int departmentId)
        {
            var department = await _dbContext.Department
                .FirstOrDefaultAsync(v => v.Id == departmentId);

            if (department == null)
                return false;

            _dbContext.Department.Remove(department);
            await _dbContext.SaveChangesAsync();

            return true;
        }


    }
}
