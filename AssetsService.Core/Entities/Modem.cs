using AssetsService.Core.PagingHelper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace AssetsService.Core.Entities
{
    public class ModemData
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Modem data { get; set; }
    }
    [DataContract]
    public partial class Modem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "assetId", EmitDefaultValue = false)]
        public string AssetId { get; set; }

        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        [DataMember(Name = "createdOn", EmitDefaultValue = false)]
        public DateTime CreatedOn { get; set; }

        [DataMember(Name = "imeiNumber", EmitDefaultValue = false)]
        public string ImeiNumber { get; set; }

        [DataMember(Name = "installationDate", EmitDefaultValue = false)]
        public DateTime InstallationDate { get; set; }

        [DataMember(Name = "ipAddress", EmitDefaultValue = false)]
        public string IpAddress { get; set; }

        [DataMember(Name = "makeMasterId", EmitDefaultValue = false)]
        public long MakeMasterId { get; set; }
        public virtual MakeMaster MakeMaster { get; set; }

        [DataMember(Name = "modelId", EmitDefaultValue = false)]
        public long? ModelId { get; set; }
        public virtual Model Model { get; set; }

        [DataMember(Name = "modifiedBy", EmitDefaultValue = false)]
        public string ModifiedBy { get; set; }

        [DataMember(Name = "modifiedOn", EmitDefaultValue = false)]
        public DateTime ModifiedOn { get; set; }

        [DataMember(Name = "serialNumber", EmitDefaultValue = false)]
        public string SerialNumber { get; set; }
        [DataMember(Name = "simNumber", EmitDefaultValue = false)]
        public string SimNumber { get; set; }
        [DataMember(Name = "statusId", EmitDefaultValue = false)]
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }
        [DataMember(Name = "locationId", EmitDefaultValue = false)]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }

        [DataMember(Name = "ModemTypeId", EmitDefaultValue = false)]
        public long ModemTypeId { get; set; }
        public virtual ModemType ModemType { get; set; }

        [DataMember(Name = "warrantyDuration", EmitDefaultValue = false)]
        public long WarrantyDuration { get; set; }

        [DataMember(Name = "warrantyExpiryDate", EmitDefaultValue = false)]
        public DateTime WarrantyExpiryDate { get; set; }
        [DataMember(Name = "warrantyStartDate", EmitDefaultValue = false)]
        public DateTime WarrantyStartDate { get; set; }

        [DataMember(Name = "IsActive", EmitDefaultValue = false)]
        public bool IsActive { get; set; }
    }
    public class ModemDTO
    {

        public long Id { get; set; }
        public string AssetId { get; set; }
        public string Carrier { get; set; }
        public string ImeiNumber { get; set; }
        public DateTime InstallationDate { get; set; }
        public string IpAddress { get; set; }
        public long MakeMasterId { get; set; }
        public long ModelId { get; set; }

        public string MakeMasterName { get; set; }
        public string ModelName { get; set; }
        public string SerialNumber { get; set; }
        public string SimNumber { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public long ModemTypeId { get; set; }
        public string ModemTypeName { get; set; }
        public long WarrantyDuration { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public long LocationId { get; set; }
        public bool IsActive { get; set; }
        public string LocationName { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
    public class ModemResponse
    {
        public ModemResponse()
        {
            data = new List<ModemDTO>();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<ModemDTO> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }
    public class ModemByIDResponse
    {
        public ModemByIDResponse()
        {
            data = new ModemDTO();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public ModemDTO data { get; set; }
    }
    public class CreateModemByIDResponse
    {
        public CreateModemByIDResponse()
        {
            data = new Modem();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Modem data { get; set; }

    }
    public class ModemRequest : QueryStringParameters
    {
        public int? dispenserId { get; set; } = 0;
    }
}
