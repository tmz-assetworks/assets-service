using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    [DataContract]
    public partial class SubscriptionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "customerId", EmitDefaultValue = false)]
        public long CustomerId { get; set; }
        public virtual Customers Customer { get; set; }


        [DataMember(Name = "subscriptionPlanName", EmitDefaultValue = false)]
        public string SubscriptionPlanName { get; set; }

        //[DataMember(Name = "description", EmitDefaultValue = false)]
        //public string Description { get; set; }

        [DataMember(Name = "currencyid", EmitDefaultValue = false)]
        public long CurrencyId { get; set; }
        public virtual Currency currency { get; set; }

        [DataMember(Name = "validFrom", EmitDefaultValue = false)]
        public DateTime ValidFrom { get; set; }

        [DataMember(Name = "validTo", EmitDefaultValue = false)]
        public DateTime ValidTo { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }

        [DataMember(Name = "subscriptionsGroupId", EmitDefaultValue = false)]
        public long SubscriptionsGroupId { get; set; }
        public virtual SubscriptionsGroup SubscriptionsGroup { get; set; }


        [DataMember(Name = "SubscriptionPlanTypeId", EmitDefaultValue = false)]
        public long SubscriptionPlanTypeId { get; set; }
        public virtual SubscriptionPlanType SubscriptionPlanType { get; set; }


        [DataMember(Name = "subscriptionsDetails", EmitDefaultValue = false)]
        public string SubscriptionsDetails { get; set; }

        [DataMember(Name = "subscriptionsValue", EmitDefaultValue = false)]
        public string SubscriptionsValue { get; set; }

        [DataMember(Name = "isActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string? CreatedBy { get; set; }


        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public DateTime? CreatedOn { get; set; }


        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        public string? ModifiedBy { get; set; }


        [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
        public DateTime? ModifiedOn { get; set; }
    }
}
