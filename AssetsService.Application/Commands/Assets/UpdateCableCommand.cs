using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{
   
    public class UpdateCableCommand : IRequest<CableResponse>
    {
        public long Id { get; set; }
        public string AssetId { get; set; }
        public DateTime InstallationDate { get; set; }
        public long MakeMasterId { get; set; }
        public long ModelId { get; set; }
        public string SerialNumber { get; set; }
        public virtual long StatusId { get; set; }
        public long WarrantyDuration { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public long NetworkId { get; set; }
        public string NetworkName { get; set; }
        public long SubNetworkId { get; set; }
        public string SubNetworkName { get; set; }
        public bool IsActive { get; set; }
    }
}
