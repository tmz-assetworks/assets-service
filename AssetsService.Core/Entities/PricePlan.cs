using AssetsService.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AssetsService.Core.Entities
{

    [DataContract]
    public partial class PricePlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "customerId", EmitDefaultValue = false)]
        public long CustomerId { get; set; }
        public virtual Customers Customer { get; set; }

        [DataMember(Name = "pricingPlanName", EmitDefaultValue = false)]
        public string PricingPlanName { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }


        public virtual Currency Currency { get; set; }

        [DataMember(Name = "Currencyid", EmitDefaultValue = false)]

        public long CurrencyId { get; set; }


        [DataMember(Name = "validFrom", EmitDefaultValue = false)]
        public DateTime ValidFrom { get; set; }

        [DataMember(Name = "validTo", EmitDefaultValue = false)]
        public DateTime ValidTo { get; set; }

        [DataMember(Name = "levelid", EmitDefaultValue = false)]

        public long LevelId { get; set; }

        public virtual Level Level { get; set; }

        public virtual PriceType PriceType { get; set; }

        [DataMember(Name = "priceTypeid", EmitDefaultValue = false)]

        public long PriceTypeId { get; set; }

        public virtual Unit Unit { get; set; }

        [DataMember(Name = "UnitId", EmitDefaultValue = false)]

        public long UnitId { get; set; }

        [DataMember(Name = "Price", EmitDefaultValue = false)]
        public double Price { get; set; }

        [DataMember(Name = "parkingFee", EmitDefaultValue = false)]

        public long ParkingFee { get; set; }

        [DataMember(Name = "gracePeriod", EmitDefaultValue = false)]

        public DateTime GracePeriod { get; set; }

        [DataMember(Name = "transactionFees", EmitDefaultValue = false)]

        public long TransactionFees { get; set; }

        [DataMember(Name = "salaryTax", EmitDefaultValue = false)]

        public double SalaryTax { get; set; }

        [DataMember(Name = "salesTax", EmitDefaultValue = false)]

        public double SalesTax { get; set; }

        [DataMember(Name = "PriceTypeName", EmitDefaultValue = false)]
        public string PriceTypeName { get; set; }

        [DataMember(Name = "isActive", EmitDefaultValue = false)]

        public bool IsActive { get; set; }

        [DataMember(Name = "CreatedBy", EmitDefaultValue = false)]

        public string CreatedBy { get; set; }

        [DataMember(Name = "CreatedOn", EmitDefaultValue = false)]

        public DateTime CreatedOn { get; set; }

        [DataMember(Name = "ModifiedBy", EmitDefaultValue = false)]

        public string ModifiedBy { get; set; }

        [DataMember(Name = "ModifiedOn", EmitDefaultValue = false)]

        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<PricePlanLocationsMapper> PricePlanLocationsMapper { get; set; }
    }

}