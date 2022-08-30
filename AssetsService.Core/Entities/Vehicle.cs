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
    public partial class Vehicle
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "VIN", EmitDefaultValue = false)]
        public string VIN { get; set; }

        [DataMember(Name = "LicencePlate", EmitDefaultValue = false)]
        public string LicencePlate { get; set; }

        [DataMember(Name = "Department", EmitDefaultValue = false)]
        public string Department { get; set; }

        [DataMember(Name = "DomicileLocation", EmitDefaultValue = false)]
        public string DomicileLocation { get; set; }

        [DataMember(Name = "VehicleMacAddress", EmitDefaultValue = false)]
        public string VehicleMacAddress { get; set; }


        [DataMember(Name = "IsActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public DateTime CreatedOn { get; set; }


        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedOn
        /// </summary>
        [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
        public DateTime ModifiedOn { get; set; }


        [DataMember(Name = "VehicleModelYear", EmitDefaultValue = false)]
        public long VehicleModelYearid { get; set; }
        public virtual VehicleModelYear VehicleModelYear { get; set; }

        [DataMember(Name = "vehicleModelId", EmitDefaultValue = false)]
        public long VehicleModelId { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }

        [DataMember(Name = "VehicleMakeId", EmitDefaultValue = false)]
        public long VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }

        [DataMember(Name = "SubscriptionPlanCustomerId", EmitDefaultValue = false)]

         public long SubscriptionPlanCustomerId {get; set;}
        public virtual SubscriptionPlan SubscriptionPlan {get;set;}

        public virtual ICollection<VehicleRFID> vehicleRFID { get; set; }


    }
}
