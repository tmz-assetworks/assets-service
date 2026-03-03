using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Response
{
    public class DepartmentResponse
    {
    }
    public class GetAllDepartmentRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
    }
    public class GetAllDepartment
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Active { get; set; }
        public string Inactive { get; set; }
        public PagedList<DepartmentListDto> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }

    public class StatusDepartmentResponse
    {
        public string Active { get; set; }
        public string Inactive { get; set; }
        public PagedList<Department> data { get; set; }

    }

    public class StatusAllDepartmentResponse
    {
        public string Active { get; set; }
        public string Inactive { get; set; }
        public PagedList<DepartmentListDto> data { get; set; }

    }
    public class DepartmentInfo
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Department data { get; set; }
    }
    public class DeleteDepartmentRequest
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
    public class DepartmentListDto
    {
        public long Id { get; set; }
        public string DepartmentName { get; set; }
        public string ContactPersonName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
