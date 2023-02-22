using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    public partial class PaymentTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public virtual PricePlan PricePlan { get; set; }
        public long PricePlanId { get; set; }
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
        public long SubscriptionPlanId { get; set; }

        public decimal SalesTax { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal ParkingFee { get; set; }
        public decimal Tax { get; set; }
        public decimal GracePeriod { get; set; }
        public virtual Currency Currency { get; set; }
        public long CurrencyId { get; set; }
        public string ConsumedEnergy { get; set; }

        public long ConsumedTime { get; set; }
        public virtual PriceType PriceType { get; set; }
        public long PriceTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual ChargingSession ChargingSession { get; set; }
        public int ChargingSessionId { get; set; }
        public int PaymentStatus { get; set; }
        public int CardType { get; set; }
        public string Remark { get; set; }

        public string UnitName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public string? VIN { get; set; }
        public string? RFID { get; set; }

    }
}
