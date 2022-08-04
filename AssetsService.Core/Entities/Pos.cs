using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Pos 
    {
        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [DataMember(Name="assetId", EmitDefaultValue=false)]
        public string AssetId { get; set; }

        /// <summary>
        /// Gets or Sets CardReaderType
        /// </summary>
        [DataMember(Name="cardReaderType", EmitDefaultValue=false)]
        public long CardReaderType { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets CreatedOn
        /// </summary>
        [DataMember(Name="createdOn", EmitDefaultValue=false)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets InstallationDate
        /// </summary>
        [DataMember(Name="installationDate", EmitDefaultValue=false)]
        public DateTime InstallationDate { get; set; }

        /// <summary>
        /// Gets or Sets MakeId
        /// </summary>
        [DataMember(Name="makeId", EmitDefaultValue=false)]
        public long MakeId { get; set; }

        /// <summary>
        /// Gets or Sets ModelId
        /// </summary>
        [DataMember(Name="modelId", EmitDefaultValue=false)]
        public long ModelId { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedBy
        /// </summary>
        [DataMember(Name="modifiedBy", EmitDefaultValue=false)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedOn
        /// </summary>
        [DataMember(Name="modifiedOn", EmitDefaultValue=false)]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or Sets NetworkId
        /// </summary>
        [DataMember(Name="networkId", EmitDefaultValue=false)]
        public long NetworkId { get; set; }

        /// <summary>
        /// Gets or Sets NetworkName
        /// </summary>
        [DataMember(Name="networkName", EmitDefaultValue=false)]
        public string NetworkName { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets SerialNumber
        /// </summary>
        [DataMember(Name="serialNumber", EmitDefaultValue=false)]
        public long SerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
      ///  [DataMember(Name="status", EmitDefaultValue=false)]

      [DataMember(Name="statusId", EmitDefaultValue=false)]
        public long StatusId { get; set; }
        public virtual Status Status  { get; set; }
        

        /// <summary>
        /// Gets or Sets SubNetworkId
        /// </summary>
        [DataMember(Name="subNetworkId", EmitDefaultValue=false)]
        public long SubNetworkId { get; set; }

        /// <summary>
        /// Gets or Sets SubNetworkName
        /// </summary>
        [DataMember(Name="subNetworkName", EmitDefaultValue=false)]
        public string SubNetworkName { get; set; }

        /// <summary>
        /// Gets or Sets UserName
        /// </summary>
        [DataMember(Name="userName", EmitDefaultValue=false)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or Sets WarrantyDuration
        /// </summary>
        [DataMember(Name="warrantyDuration", EmitDefaultValue=false)]
        public long WarrantyDuration { get; set; }

        /// <summary>
        /// Gets or Sets WarrantyExpiryDate
        /// </summary>
        [DataMember(Name="warrantyExpiryDate", EmitDefaultValue=false)]
        public DateTime WarrantyExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets WarrantyStartDate
        /// </summary>
        [DataMember(Name="warrantyStartDate", EmitDefaultValue=false)]
        public DateTime WarrantyStartDate { get; set; }

        
            
    }
}
