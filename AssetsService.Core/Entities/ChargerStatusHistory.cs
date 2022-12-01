using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Entities
{
    public partial class ChargerStatusHistory
    {
        public int Id { get; set; }
        public int ChargerId { get; set; }
        public string ChargerStatus { get; set; }
        public int? ConnectorId { get; set; }
        public string ConnectorStatus { get; set; }
        public string Operation { get; set; }
        public DateTime? CreatedOn { get; set; }
        public virtual Charger Charger { get; set; }
    }

}
