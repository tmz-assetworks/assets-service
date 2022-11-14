using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class SwitchGearResponse
    {
        public long Id { get; set; }
        public string SwitchGearName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
    public class GetSwitchGearResponseById
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public GetSwitchGearResponse Data { get; set; }
        public GetSwitchGearResponseById()
        {
            Data = new GetSwitchGearResponse();
        }
    }
    public class GetSwitchGearResponse
    {
        public long Id { get; set; }
        public string SwitchGearName { get; set; }
        public string AssetId { get; set; }
        public string SerialNumber { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
    public class SwitchGearRequest : QueryStringParameters
    {
        public string userId { get; set; }
    }
    public class SwitchGearDropDownRequest
    {
        public string userId { get; set; }
        public int? dispenserId { get; set; }
    }
    public class ListSwitchGear
    {
        public long Id { get; set; }
        public string SwitchGearName { get; set; }
        public bool IsActive { get; set; }
    }
    public class AllSwitchGearResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<GetSwitchGearResponse> Data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
        public AllSwitchGearResponse()
        {
            Data = new List<GetSwitchGearResponse>();
        }
    }
}
