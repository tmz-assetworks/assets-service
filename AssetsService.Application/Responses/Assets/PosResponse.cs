using System;
using System.Collections.Generic;


namespace AssetsService.Core.Responses
{

      public partial class PosResponse
      {

        
    public string AssetId { get; set; }

     public long CardReaderType { get; set; }

         
      public string CreatedBy { get; set; }

      public DateTime CreatedOn { get; set; }

      public long Id { get; set; }

      public DateTime InstallationDate { get; set; }

      public long MakeId { get; set; }

      public long ModelId { get; set; }

      public string ModifiedBy { get; set; }

      public DateTime ModifiedOn { get; set; }

      public long NetworkId { get; set; }

       public string NetworkName { get; set; }

       public string Password { get; set; }

       public long SerialNumber { get; set; }

     //   public Status Status { get; set; }
       public  long StatusId { get; set; }

        public long SubNetworkId { get; set; }

        public string SubNetworkName { get; set; }

        public string UserName { get; set; }

         public long WarrantyDuration { get; set; }

         public DateTime WarrantyExpiryDate { get; set; }

         public DateTime WarrantyStartDate { get; set; }

}

}