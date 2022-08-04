using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets.RFId
{
    public class UpdateRFIdCommand : IRequest<RFIdResponse>
    {
        public long Id { get; set; }
        public string AssetId { get; set; }
        public string CardReader { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public long MakeId { get; set; }
        public long ModelId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        // public long NetworkId { get; set; }
        // public string NetworkName { get; set; }
        public long SerialNumber { get; set; }
        public long StatusId { get; set; }
        // public long SubNetworkId { get; set; }
        // public string SubNetworkName { get; set; }
        public long WarrantyDuration { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public long LocationId { get; set; }
        public DateTime WarrantyStartDate { get; set; }
    }
}
