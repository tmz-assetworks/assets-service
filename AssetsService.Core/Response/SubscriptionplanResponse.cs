using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Responses.Assets
{

    public class AllSubscriptionplan
    {

        public int StatusCode;
        public string StatusMessage;

        public List<SubscriptionPlan> data { get; set; }
    }

    public class SubscriptionplanById
    {
     
        public int StatusCode;
        public string StatusMessage;
        public List<SubscriptionPlansByIdResponse> Data { get; set; }
        public SubscriptionplanById()
        {
            Data = new List<SubscriptionPlansByIdResponse>();
        }
    }
    public class AllSubscriptionPlansResponse
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public long SubscriptionsGroupId { get; set; }
        public string SubscriptionGroupName { get; set; }
        public string SubscriptionsDetails { get; set; }
        public string SubscriptionsValue { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class SubscriptionPlansByIdResponse
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public long SubscriptionsGroupId { get; set; }
        public string SubscriptionGroupName { get; set; }
        public string SubscriptionsDetails { get; set; }
        public string SubscriptionsValue { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class SubscriptionPlansResponse
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public long StatusId { get; set; }
        public long SubscriptionsGroupId { get; set; }
        public string SubscriptionsDetails { get; set; }
        public string SubscriptionsValue { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class SubscriptionPlans
    {
        public long CustomerId { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public long StatusId { get; set; }
        public long SubscriptionsGroupId { get; set; }
        public string SubscriptionsDetails { get; set; }
        public string SubscriptionsValue { get; set; }
        public string SubscriptionsGroupName { get; set; }

        public string StatusName { get; set; }
        public string CurrencyName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
    public class SubscriptionPlanResponse
    {
        public SubscriptionPlanResponse()
        {
            data = new List<AllSubscriptionPlansResponse>();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<CardData> CardData { get; set; }
        public List<AllSubscriptionPlansResponse> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }
    public class GetSubscriptionPlanRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
        //public string? SearchParam { get; set; }
    }
    public class GetCurrencyRequest
    {
        public string? userId { get; set; }
    }
    public class CurrencyListDropDown
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
    public class CardData
    {

        public string key { get; set; }
        public int value { get; set; }

    }

}