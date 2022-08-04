using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class SubscriptionPlanResponse
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SubscriptionPlanName { get; set; }
        public string Description { get; set; }
        public long CurrencyId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public long StatusId { get; set; }
        public long SubscriptionsGroupId { get; set; }
        public string SubscriptionsDetails { get; set; }
        public string SubscriptionsValue { get; set; }
    }
}
