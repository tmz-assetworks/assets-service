namespace AssetsService.Core.Entities
{
    public class ChargerConfiguration
    {
        public int Id { get; set; }
        public int ChargerId { get; set; }
        public string? DeviceSerialNumber { get; set; }
        public string? ChargePointModel { get; set; }
        public string? ChargePointSerialNumber { get; set; }
        public string? ChargePointVendor { get; set; }
        public Charger? Charger { get; set; }
    }
}
