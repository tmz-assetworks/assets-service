using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PricePlanLocationsMapper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public long LocationId { get; set; }

        [DataMember(Name = "pricePlanId", EmitDefaultValue = false)]
        public long PricePlanId { get; set; }

        [DataMember(Name = "dispenserId", EmitDefaultValue = false)]
        public int ChargerId { get; set; }

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

    }
}