using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;
using AssetsService.Core.Response;

namespace AssetsService.Core.Response
{

    public class AllCurrencyCodeResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllCurrencyCodeList> data { get; set; }
    }

    public class AllCurrencyCodeList
    {
        public long Id { get; set; }
        public string CurrencyName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllLevelResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllLevelList> data { get; set; }
    }

    public class AllLevelList
    {
        public long Id { get; set; }
        public string LevelRank { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllUnitResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllUnitList> data { get; set; }
    }

    public class AllUnitList
    {
        public long Id { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
    }

     public class AllPriceTypeResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllPriceTypeList> data { get; set; }
    }

    public class AllPriceTypeList
    {
        public long Id { get; set; }
        public string PriceTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}

    public class AllPricePlan
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<StatusData> statusData { get; set; }
        public PagedList<PricePlanDto> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }


    }
    public class PricePlanListData
    {
        public int Active { get; set; }
        public int Inactive { get; set; }
        public PagedList<PricePlanDto> data { get; set; }
    }
    public class PricePlanDetailResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<PricePlanDto> data { get; set; }
    }
    public class GetAllPricePlanRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
    }

    public class PricePlanDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PricePlanName { get; set; }
        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        // public long LocationId { get;set;}
        public int Location { get; set; }
        public string LevelName { get; set; }
        public long LevelId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }

    }
    public class PricePlanStatusResponse{
        public int StatusCode {get;set;}
        public string StatusMessage{get;set;}
        public PricePlanCommonResponse data{get;set;}
    }

    public class PricePlanCommonResponse{
        public long Id{get;set;}
        public long CustomerId { get;set;}
        public string CustomerName { get;set;}
        public bool IsActive { get;set;}
        public string PricePlanName{get;set;}
        public int Location { get;set;}
        public string Description { get;set;}
        public string CurrencyCode {get;set;}
        public string CurrencyName{get;set;}
        public DateTime ValidFrom { get;set;}
        public DateTime ValidTo { get;set;}
        public long LevelId { get;set;}
        public String LevelName { get;set;}
        public long PriceTypeId {get;set;}
        public long UnitId {get;set;}
        public string UnitName { get;set;}
        public double Price {get;set;}
        public long ParkingFess{get;set;}
        public DateTime GracePeriod{get;set;}
        public long TransactionFess{get;set;}




    }
    
    public class PricePlanById
    {

        public int StatusCode;
        public string StatusMessage;

        public PricePlan data { get; set; }
    }
    public class PricePlanResponse
    {
        public int Id { get; set; }

    }
    public class AllCurrencyCodeResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllCurrencyCodeList> data { get; set; }
    }

    public class AllCurrencyCodeList
    {
        public long Id { get; set; }
        public string CurrencyName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllLevelResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllLevelList> data { get; set; }
    }

    public class AllLevelList
    {
        public long Id { get; set; }
        public string LevelRank { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllUnitResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllUnitList> data { get; set; }
    }

    public class AllUnitList
    {
        public long Id { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AllPriceTypeResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllPriceTypeList> data { get; set; }
    }

    public class AllPriceTypeList
    {
        public long Id { get; set; }
        public string PriceTypeName { get; set; }
        public bool IsActive { get; set; }

    }

