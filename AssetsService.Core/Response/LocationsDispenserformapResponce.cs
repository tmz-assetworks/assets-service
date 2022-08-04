using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class LocationsDispenserformapResponce
    {
        public LocationsDispenserformapResponce()
        {
            data = new List<LocationsDispenser>();
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<LocationsDispenser> data { get; set; }
    }

    public class LocationsDispenser
    {
        public long locationId { get; set; }
        public long DispenserId { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }

        public string status { get; set; }


    }

   
}
