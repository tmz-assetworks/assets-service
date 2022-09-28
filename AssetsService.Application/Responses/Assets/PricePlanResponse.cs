using System;
using System.Collections.Generic;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Responses
{

    public partial class PricePlanResponse
    {

        public long Id { get; set; }


        public string CustomerName { get; set; }


        public string PricingPlanName { get; set; }

        public string Description { get; set; }




        public long CurrencyId { get; set; }



        public DateTime ValidFrom { get; set; }


        public DateTime ValidTo { get; set; }



        public long LevelId { get; set; }

        public long PriceTypeId { get; set; }

        public long UnitId { get; set; }

        public double Price { get; set; }

        public long ParkingFee { get; set; }

        public DateTime GracePeriod { get; set; }

        public long TransactionFees { get; set; }

        public double SalaryTax { get; set; }

        public double SalesTax { get; set; }

        public string PriceTypeName { get; set; }


        public bool IsActive { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }


        public string ModifiedBy { get; set; }



        public DateTime ModifiedOn { get; set; }
    }

    public class AllPricePlan{
        
        public int StatusCode;
        public string StatusMessage;

        public List<PricePlan> data{get;set;}
    }

    public class PricePlanById{
        
        public int StatusCode;
        public string StatusMessage;

        public PricePlan data{get;set;}
    }
}
