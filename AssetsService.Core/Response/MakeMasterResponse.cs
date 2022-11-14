using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Response
{

    public class AllMakeMaster{
        
        public int StatusCode;
        public string StatusMessage;

        public List<MakeMaster> data{get;set;}
    }

    public class MakeMasterById{
        
        public int StatusCode;
        public string StatusMessage;

        public MakeMaster data{get;set;}
    }

    public class MakeMasterListResponse
    {
        public int StatusCode;
        public string StatusMessage;
        public List<MakeMasterList> data { get; set; }
    }
    public class MakeMasterList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        
    }


}