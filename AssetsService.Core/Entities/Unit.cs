using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AssetsService.Core.Entities

{
    
    [DataContract]
    public partial class Unit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        // [DataMember(Name = "unitId", EmitDefaultValue = false)]
        // public long UnitId { get; set; }

        

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "unitName", EmitDefaultValue = false)]
        public string UnitName { get; set; }

        [DataMember(Name = "priceTypeId", EmitDefaultValue = false)]
        public long PriceTypeId { get; set; }
        public virtual PriceType PriceType { get; set; }
        /// <summary>
        /// Gets or Sets ModifiedBy
        /// </summary>
        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedOn
        /// </summary>
        [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name = "isActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }


    }
}

