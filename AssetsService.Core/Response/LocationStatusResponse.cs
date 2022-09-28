using AssetsService.Core.Entities;
namespace AssetsService.Core.Responses.Assets
{
    public class LocationStatusResponcse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<AllLocationStatuss> data { get; set; }
    }
    public class AllLocationStatuss
    {
        public long Id { get; set; }    
        public string LocationStatusName { get; set; }
    }


}