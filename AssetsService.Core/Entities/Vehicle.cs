using AssetsService.Core.Responses.Assets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


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

        [RegularExpression("^[a-zA-Z0-9]{20}*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [DataMember(Name = "LicencePlate", EmitDefaultValue = false)]

        public string LicencePlate { get; set; }
        // [StringLength(5, ErrorMessage = "LicencePlate name must be 5 characters or less")]
        [DataMember(Name = "Department", EmitDefaultValue = false)]
        public string Department { get; set; }

        [RegularExpression("^[a-zA-Z0-9]{25}*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [DataMember(Name = "DomicileLocation", EmitDefaultValue = false)]
        public string DomicileLocation { get; set; }

        [RegularExpression("^[a-zA-Z0-9]{25}*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
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


        [Required]
        [DataMember(Name = "ModelYear", EmitDefaultValue = false)]
        public long ModelYear { get; set; }           // i.e 2022,2023,2024

        [Required]
        [DataMember(Name = "makeName", EmitDefaultValue = false)]
        public string MakeName { get; set; }

        // / <summary>
        // / Gets or Sets Model
        // / </summary>
        [Required]
        [DataMember(Name = "modelName", EmitDefaultValue = false)]
        public string ModelName { get; set; }


        //this param is optinal
        [DataMember(Name = "UnitNumber", EmitDefaultValue = false)]
        public string? UnitNumber { get; set; }
        //this param is optinal
        [DataMember(Name = "AssetId", EmitDefaultValue = false)]
        public string? AssetId { get; set; }
        /// <summary>
        public virtual ICollection<VehicleRFID> vehicleRFID { get; set; }

        [NotMapped]
        public List<ApplicableSubscriptionPlan> applicableSubscriptionPlans { get; set; }

    }


}

