using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Responses.Assets
{


     public class CableQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public PagedList<AssetsService.Core.Entities.Cable> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }

    public class CableByIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public CableData data { get; set; }
    }

     public class CableData
    {
        public long Id {get; set;}
        public string SerialNumber { get; set; }
        public string AssetId { get; set; }
        public long LocationId { get; set; }
        public bool IsActive { get; set; }
        public long MakeMasterId { get; set; }
        public string MakeMasterName { get; set; }
        public long ModelId { get; set; }
        public string LocationName { get; set; }
        public string ModelName { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }

        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public long WarrantyDuration { get; set; }
    }

    public class GetAllCableRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
    }
    public class GetAllCableDropDownRequest
    {
        public string userId { get; set; }
        public int? dispenserId { get; set; } = 0;
    }
    public class CableListDropDown
    {
        public long Id { get; set; }
        public string CableSerialNumber { get; set; }
    }
    public class CreateCableResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public long Id { get; set; }
    }

      public class UpdateCableResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public long Id { get; set; }
    }
     public class DeleteCableResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public long Id { get; set; }
        public bool IsActive { get; set; }
    }


}