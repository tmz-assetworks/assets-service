using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{

    public class AllLocationNameResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<LocationData> data { get; set; }
    }

    public class LocationData
    {
        public long Id { get; set; }
        public string LocationName { get; set; }
    }

}