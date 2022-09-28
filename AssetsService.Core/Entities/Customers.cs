using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    [DataContract]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [Required]
        [DataMember(Name = "userName", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(200)")]
        public string userName { get; set; }
        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public long phoneNumber { get; set; }


        [DataMember(Name = "AddressLine1", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(200)")]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "AddressLine2", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(200)")]
        public string AddressLine2 { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        public long? CountryID { get; set; }

        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        public long? StateID { get; set; }
        public long? CityID { get; set; }

        //[DataMember(Name = "city", EmitDefaultValue = false)]
        //[Column(TypeName = "nvarchar(100)")]
        //public string city { get; set; }
        [DataMember(Name = "pointofcontact", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string pointofcontact { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string description { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string zipCode { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string createdBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public DateTime createdOn { get; set; }

        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        [Column(TypeName = "nvarchar(100)")]
        public string modifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedOn
        /// </summary>
        [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
        public DateTime modifiedOn { get; set; }

        [DataMember(Name = "isActive", EmitDefaultValue = true)]
        [DefaultValue(true)]
        public bool isActive { get; set; }

        //public virtual IEnumerable<Users>? UsersList { get; set; }
    }


}
