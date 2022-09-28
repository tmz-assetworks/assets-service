
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Runtime.Serialization;

namespace AssetsService.Core.Entities
{
    
    [DataContract]
    public partial class VehicleRFID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long  Id { get; set; }

        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string  Name { get; set; }

        [DataMember(Name = "IsActive", EmitDefaultValue = false)]
        public bool  IsActive { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string CreatedBy { get; set; }


         [DataMember(Name = "vehicleId", EmitDefaultValue = false)]
         public long VehicleId { get; set; }
      

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
    }
}
