using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class PadDataRequest
    {
        public string userId { get; set; }
        public int? dispenserId { get; set; } = 0;
    }
    public class GetPadResponse
    {
        public long Id { get; set; }

        public string AssetId { get; set; }
        public string SerialNumber { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime InstallationDate { get; set; }

        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string PadName { get; set; }
        public long StatusId { get; set; }
        public string StatusName { get; set; }
        public long LocationId { get; set; }
        public string LocationName { get; set; }
    }
    public class PadResults
    {
        public long Id { get; set; }
        public string PadName { get; set; }
        public bool IsActive { get; set; }
    }
}
