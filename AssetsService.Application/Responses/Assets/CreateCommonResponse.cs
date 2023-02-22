using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class CreateCommonResponse
    {
        public long Id { get; set; }
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
    }
    public class CreateCommonResponseExternal
    {
        public long Id { get; set; }
        public int statusCode { get; set; }
        public string statusMessage { get; set; }
    }
}
