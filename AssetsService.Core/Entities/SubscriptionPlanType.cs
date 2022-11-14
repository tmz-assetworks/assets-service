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
    public partial class SubscriptionPlanType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "PlanTypeName", EmitDefaultValue = false)]
        public string PlanTypeName { get; set; }       
       

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
