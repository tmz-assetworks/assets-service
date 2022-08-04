using AssetsService.Core.Responses;
using MediatR;


namespace AssetsService.Application.Commands.Assets
{
    public class CreateModemCommand : IRequest<ModemResponse>
    {
         public string AssetId { get; set; }

        public string Carrier { get; set; }

        
        public string CreatedBy { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public DateTime InstallationDate { get; set; }
        public long MakeId { get; set; }

        public long ModelId { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

       // public long NetworkId { get; set; }

        public long SimNumber { get; set; }

       // public string NetworkName { get; set; }

        public long SerialNumber { get; set; }


          public virtual long StatusId { get; set; }

          public long ModemTypeId { get; set; }

          public long LocationId { get; set; }
       // public long SubNetworkId { get; set; }
        
        public long ImeiNumber { get; set; }

        public string IpAddress { get; set; }

      //  public string SubNetworkName { get; set; }
        public long WarrantyDuration { get; set; }

        public DateTime WarrantyExpiryDate { get; set; }
        public DateTime WarrantyStartDate { get; set; }

    }
    }