using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class AllTimeZone
    { 
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<TimeZoneResponse> Data { get; set; }
    }
    public class TimeZoneResponse
    {
        public int Id { get; set; }
        public string TimeZoneText { get; set; }
    }
}
