using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class GetPowerCabinetResponse
    {
        public long Id { get; set; }

        public string AssetId { get; set; }

        public double BreakerRating { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int DcPortQuantityRating { get; set; }

        public DateTime InstallationDate { get; set; }

        public long MakeMasterId { get; set; }
        public string MakeMasterName { get; set; }
        public long ModelId { get; set; }
        public string ModelName { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int PeakCurrent { get; set; }

        public string SerialNumber { get; set; }

        public long ServiceVolts { get; set; }

        public long StatusId { get; set; }
        public string StatusName { get; set; }

        public bool IsActive { get; set; }
        public long WarrantyDuration { get; set; }

        public DateTime WarrantyExpiryDate { get; set; }

        public DateTime WarrantyStartDate { get; set; }

        public long LocationId { get; set; }

        public string LocationName { get; set; }
    }
}
