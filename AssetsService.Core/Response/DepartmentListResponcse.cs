using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Response
{

    public class DepartmentListResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllDepartmentList> data { get; set; }
    }
    public class AllDepartmentList
    {
        public long Id { get; set; }
        public string DepartmentName { get; set; }  
    }




}