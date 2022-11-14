using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{

    public class LocationsDispenserDetailsResponse 
    {
        public LocationsDispenserDetailsResponse()
        {
            data = new List<LocationsDispenserDetails>();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<LocationsDispenserDetails> data { get; set; }      
        public PaginationResponse paginationResponse { get; set; }
        
    }


    public class LocationsDispenserStatus
    {
        public long Id { get; set; }
        public string Status { get; set; }
    }
        public class LocationsDispenserDetails
    {
        public long locationId { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string status { get; set; }
        public string NoofPort { get; set; }
        public string Available { get; set; }
        public string Connected { get; set; }
        public string Faulted { get; set; }
        public string ContactNo { get; set; }
        public string ContactName { get; set; }

        public DateTime CreatedOn { get; set; }
    }

    public class LocationDispenserRequest : QueryStringParameters
    {
        public List<long> LocationIds { get; set; }
        public string? opratorid { get; set; }
    }
}

