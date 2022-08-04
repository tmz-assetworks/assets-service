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
    public partial class Location
    {

        // public Location()  
        // {  
        //     this.LocationSchedule = newHashSet < LocationSchedule > ();  

        //     this.OperatorUserMapper = newHashSet < OperatorUserMapper > ();  
        // } 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "locationAddressId", EmitDefaultValue = false)]
        public long LocationAddressId { get; set; }
        public virtual LocationAddress LocationAddress { get; set; }

        // [DataMember(Name = "locationScheduleId", EmitDefaultValue = false)]
        // public long LocationScheduleId { get; set; }
        // public virtual LocationSchedule LocationSchedule { get; set; }



        [DataMember(Name = "locationStatusId", EmitDefaultValue = false)]
        public long LocationStatusId { get; set; }
        public virtual LocationStatus LocationStatus { get; set; }

        public virtual Department Department { get; set; }

        [DataMember(Name = "departmentId", EmitDefaultValue = false)]
        public long DepartmentId { get; set; }





        [DataMember(Name = "contactPersonName", EmitDefaultValue = false)]
        public string ContactPersonName { get; set; }


        [DataMember(Name = "globalTax", EmitDefaultValue = false)]
        public string GlobalTax { get; set; }


        [DataMember(Name = "totalCapacity", EmitDefaultValue = false)]
        public string TotalCapacity { get; set; }

        [DataMember(Name = "utilityService", EmitDefaultValue = false)]
        public string UtilityService { get; set; }


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
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name = "isActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

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
        /// Gets or Sets LocationName
        /// </summary>
        [DataMember(Name = "locationName", EmitDefaultValue = false)]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or Sets LocationNumber
        /// </summary>
        [DataMember(Name = "locationNumber", EmitDefaultValue = false)]
        public long LocationNumber { get; set; }

        /// <summary>
        /// Gets or Sets TimeZone
        /// </summary>
        [DataMember(Name = "timeZone", EmitDefaultValue = false)]
        public string TimeZone { get; set; }

        public string FuelProtectType {get;set;}



        public virtual ICollection<LocationSchedule> LocationSchedule { get; set; }
        public virtual ICollection<OperatorUserMapper> OperatorUserMapper { get; set; }

        

    }
}
