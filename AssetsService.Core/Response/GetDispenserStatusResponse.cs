using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class GetDispenserStatusResponse
    {
        public class GetDispenserStatus
        {
            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }

            public List<DispenserStatusList> Data { get; set; }

        }
        public class DispenserStatusList
        {
            public long Id { get; set; }
            public string Status { get; set; }
        }
        public class DispenserStatusRequest
        {
            public int userId { get; set; }
        }
    }

}
