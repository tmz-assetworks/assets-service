using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Responses.Assets
{
    public class DispenserByLocationIdResponse
    {
        public long LocationId {get; set;}

        public string LocationName {get; set;}

        public string ContactPersonName {get; set;}

        public string AddressLine1 {get; set;}

        public string LocationStatusName {get; set;}

        public long LocationStatusId {get; set;}

        public string ChargeBoxId{get; set;}

        public long ChargerId { get; set; }
        
        public string SerialNumber{get; set;}


    }
}