using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Responses.Assets
{

    public class AllSubscriptionplan
    {

        public int StatusCode;
        public string StatusMessage;

        public List<SubscriptionPlan> data { get; set; }
    }

    public class SubscriptionplanById
    {

        public int StatusCode;
        public string StatusMessage;

        public SubscriptionPlan data { get; set; }
    }


}