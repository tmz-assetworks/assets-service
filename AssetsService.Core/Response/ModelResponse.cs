using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class ModelResponse
    {
        public class ModelDataRequest
        {
            public string userId { get; set; }
        }
        public class AllModelData
        {

            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public List<ModelResults> Data { get; set; }
        }
        public class ModelResults
        {
            public long Id { get; set; }
            public string ModelName { get; set; }
        }
    }

    public class ModelListResponse
    {
        public int StatusCode;
        public string StatusMessage;
        public List<ModelList> data { get; set; }
    }
    public class ModelList
    {
        public long Id { get; set; }
        public string ModelName { get; set; }

    }
}
