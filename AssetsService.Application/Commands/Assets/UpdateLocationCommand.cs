using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Responses;
using MediatR;

namespace AssetsService.Application.Commands.Assets
{

    public class UpdateLocationCommand : IRequest<LocationResponse>
    {

        public long Id { get; set; }

        public long LocationAddressId { get; set; }

        public long LocationStatusId { get; set; }

        public long LocationId { get; set; }

        public string ContactPersonName { get; set; }

        public string GlobalTax { get; set; }

        public string TotalCapacity { get; set; }

        public string UtilityService { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        //public long NetworkId { get; set; }

        // public string NetworkName { get; set; }

        public string LocationName { get; set; }

        public long LocationNumber { get; set; }

        // public long SubNetworkId { get; set; }

        // public string SubNetworkName { get; set; }

        public string TimeZone { get; set; }

        public string FuelProtectType { get; set; }


        // public LocationAddress locationAddress { get; set; }

        // public LocationStatus locationStatus { get; set; }

        // public List<LocationSchedule> locationSchedule { get; set; }
    }
}