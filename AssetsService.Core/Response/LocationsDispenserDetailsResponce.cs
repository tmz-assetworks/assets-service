using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class LocationsDispenserDetailsResponce
    { 
    public LocationsDispenserDetailsResponce()
    {
        data = new List<LocationsDispenserDetails>();
    }
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; }

    public List<LocationsDispenserDetails> data { get; set; }
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
    public class LocationDispenserParams : QueryStringParameters
    {
        public LocationsDispenserDetails LocationsDispenserDetails { get; set; }

    }   
}

