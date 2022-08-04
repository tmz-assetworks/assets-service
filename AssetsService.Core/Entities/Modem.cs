using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using AssetsService.Core.Entities;


namespace AssetsService.Core.Entities
{
    
    [DataContract]
    public partial class Modem 
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }  
        
        [DataMember(Name="assetId", EmitDefaultValue=false)]
        public string AssetId { get; set; }

        [DataMember(Name="carrier", EmitDefaultValue=false)]
        public string Carrier { get; set; }
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }

        [DataMember(Name="createdOn", EmitDefaultValue=false)]
        public DateTime CreatedOn { get; set; }

        [DataMember(Name="imeiNumber", EmitDefaultValue=false)]
        public long ImeiNumber { get; set; }

        [DataMember(Name="installationDate", EmitDefaultValue=false)]
        public DateTime InstallationDate { get; set; }

        [DataMember(Name="ipAddress", EmitDefaultValue=false)]
        public string IpAddress { get; set; }

        [DataMember(Name="makeId", EmitDefaultValue=false)]
        public long MakeId { get; set; }
        [DataMember(Name="modelId", EmitDefaultValue=false)]
        public long ModelId { get; set; }

        [DataMember(Name="modifiedBy", EmitDefaultValue=false)]
        public string ModifiedBy { get; set; }

        [DataMember(Name="modifiedOn", EmitDefaultValue=false)]
        public DateTime ModifiedOn { get; set; }

        [DataMember(Name="networkId", EmitDefaultValue=false)]
        public long NetworkId { get; set; }

        [DataMember(Name="networkName", EmitDefaultValue=false)]
        public string NetworkName { get; set; }

        [DataMember(Name="serialNumber", EmitDefaultValue=false)]
        public long SerialNumber { get; set; }
        [DataMember(Name="simNumber", EmitDefaultValue=false)]
        public long SimNumber { get; set; }

        
        
        
        [DataMember(Name="statusId", EmitDefaultValue=false)]
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }

        
        [DataMember(Name="locationId", EmitDefaultValue=false)]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }

        [DataMember(Name="ModemTypeId", EmitDefaultValue=false)]

        public long ModemTypeId { get; set; }
        public virtual ModemType ModemType { get; set; }
      
        [DataMember(Name="subNetworkId", EmitDefaultValue=false)]
        public long SubNetworkId { get; set; }
        [DataMember(Name="subNetworkName", EmitDefaultValue=false)]
        public string SubNetworkName { get; set; }

        [DataMember(Name="warrantyDuration", EmitDefaultValue=false)]
        public long WarrantyDuration { get; set; }

        [DataMember(Name="warrantyExpiryDate", EmitDefaultValue=false)]
        public DateTime WarrantyExpiryDate { get; set; }
        [DataMember(Name="warrantyStartDate", EmitDefaultValue=false)]
        public DateTime WarrantyStartDate { get; set; }

       
        

    
        

        
    }
}
