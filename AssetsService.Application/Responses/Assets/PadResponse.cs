using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class PadResponse
    {
        public long Id { get; set; }

        public string AssetId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public DateTime InsertDate { get; set; }

        public bool IsActive { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public long NetworkId { get; set; }

        public string NetworkName { get; set; }

        public string PadName { get; set; }
        public long StatusId { get; set; }

        public long SubNetworkId { get; set; }

        public string SubNetworkName { get; set; }
    }
}
