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
    public partial class Pad 
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [DataMember(Name = "assetId", EmitDefaultValue = false)]
        public string AssetId { get; set; }

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
        /// Gets or Sets InsertDate
        /// </summary>
        [DataMember(Name = "insertDate", EmitDefaultValue = false)]
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name = "isActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or Sets Latitude
        /// </summary>
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or Sets Longitude
        /// </summary>
        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public double Longitude { get; set; }

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
        /// Gets or Sets NetworkId
        /// </summary>
        [DataMember(Name = "networkId", EmitDefaultValue = false)]
        public long NetworkId { get; set; }

        /// <summary>
        /// Gets or Sets NetworkName
        /// </summary>
        [DataMember(Name = "networkName", EmitDefaultValue = false)]
        public string NetworkName { get; set; }

        /// <summary>
        /// Gets or Sets PadName
        /// </summary>
        [DataMember(Name = "padName", EmitDefaultValue = false)]
        public string PadName { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "statusId", EmitDefaultValue = false)]
        //[ForeignKey("Status")]
        [ForeignKey("Id")]
        public long StatusId { get; set; }
        public Status Status { get; set; }

        /// <summary>
        /// Gets or Sets SubNetworkId
        /// </summary>
        [DataMember(Name = "subNetworkId", EmitDefaultValue = false)]
        public long SubNetworkId { get; set; }

        /// <summary>
        /// Gets or Sets SubNetworkName
        /// </summary>
        [DataMember(Name = "subNetworkName", EmitDefaultValue = false)]
        public string SubNetworkName { get; set; }

        
    }
}
