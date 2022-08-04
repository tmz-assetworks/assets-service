using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class DispenserByLocationsQueryResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<DispenserByLocationsResponse> data { get; set; }
    }
    public class DispenserByLocationsResponse
    {
        public long ChargerId { get; set; }
        public long LocationId { get; set; }

        public string LocationName { get; set; }
        public string DispenserName { get; set; }
        public string ContactPersonName { get; set; }

        public string AddressLine1 { get; set; }

        public string LocationStatusName { get; set; }

        public long LocationStatusId { get; set; }

        public string ChargeBoxId { get; set; }

        public string SerialNumber { get; set; }

        public string DispenserMake { get; set; }
        public string ProtocolName { get; set; }
        public string ChargerStatus { get; set; }
        public string DispenserModel { get; set; }
        public string ConnectorType { get; set; }
        public string NoofPort { get; set; }


    }

    public class DispenserByLocations
    {
        public List<long> LocationIds { get; set; }

        public string opratorid { get; set; }
    }
}
