using System;
using System.Collections.Generic;

namespace AssetsService.Core.Entities
{
    public partial class ChargingSession
    {
        public int Id { get; set; }
        public int ChargerId { get; set; }
        public int? ChargingCost { get; set; }
        public string ChargingStatus { get; set; }
        public string? RfId { get; set; }
        public int? ConnectorId { get; set; }
        public string DeviceId { get; set; }
        public string ReasonForStop { get; set; }
        public int? StartMeterValue { get; set; }
        public int? StartSoc { get; set; }
        public DateTime? StartTime { get; set; }
        public int? EndMeterValue { get; set; }
        public int? EndSoc { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual Charger Charger { get; set; }
    }
}
