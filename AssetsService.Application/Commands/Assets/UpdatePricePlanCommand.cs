using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
   
    public class UpdatePricePlanCommand : IRequest<PricePlanResponse>
    {
        public long Id { get; set; } 

        
        public string CustomerName { get; set; }

        
        public string PricingPlanName { get; set; }

        public string Description { get; set; }

        
        

        public virtual long CurrencyId { get;set;}
        

        
        public DateTime ValidFrom { get; set; }

         
        public DateTime ValidTo { get; set; }

        

        public virtual long LevelId { get; set; }

        public virtual  long PriceTypeId {get; set;}

        public virtual long UnitId {get; set;}

       public double Price {get;set;}

       public long ParkingFee {get;set;}
       
       public DateTime GracePeriod {get;set;}
       
       public long TransactionFees {get;set;}

       public double SalaryTax {get;set;}
       
       public double SalesTax {get;set;}

        public string PriceTypeName { get;  set; }


        public bool IsActive { get;  set; }


        public string CreatedBy { get;  set; }

        public DateTime CreatedOn { get;  set; }


        public string ModifiedBy { get;  set; }

        

        public DateTime ModifiedOn { get;  set; }
    }
    }