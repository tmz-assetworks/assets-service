using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;


namespace AssetsService.Core.Response
{

    public class RfIdReaderRespnse
    {
        
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<RFIDReaderDetails> data {get;set;}
        public PaginationResponse paginationResponse { get; set; }
    }
    public class RfIdReaderDataRespnse
    {

        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<RFIDReaderResult> Data { get; set; }
    }
    public class RFIDReaderResult
    {
        public long Id { get; set; }
        public string CardReader { get; set; }
        public bool IsActive { get; set; }
    }
    public  class RFIDReaderDetails
    {
       
        public long Id { get; set; }       
        public string AssetId { get; set; }     
        public string CardReader { get; set; }
        public string CreatedBy { get; set; }       
        public DateTime CreatedOn { get; set; }        
        public bool IsActive { get; set; }
        public long MakeMasterId { get; set; }
        public string MakeMasterName { get; set; }
        public long ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModifiedBy { get; set; }      
        public DateTime ModifiedOn { get; set; }       
       // public long NetworkId { get; set; }       
        //public string NetworkName { get; set; }       
        public string SerialNumber { get; set; }       
        public long StatusId { get; set; }
        public string StatusName { get; set; }       
       // public long SubNetworkId { get; set; }       
       // public string SubNetworkName { get; set; }      
        public long WarrantyDuration { get; set; }       
        public DateTime WarrantyExpiryDate { get; set; }   
        public long LocationId { get; set; }
        public string  LocationName { get; set; }       
        public DateTime WarrantyStartDate { get; set; }

    }
    public class RfIdReaderRequest : QueryStringParameters
    {
        public string operatorId { get; set; }
    }
    public class RfIdReaderDataRequest
    {
        public string userId { get; set; }
        public int? dispenserId { get; set; } = 0;
    }
    public class RfIdReaderDetailsResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public RFIDReaderDetails data { get; set; }       
        
    }

    //public class RFIDReaderData
    //{
    //    public long Id { get; set; }
    //    public string AssetId { get; set; }
    //    public string CardReader { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public bool IsActive { get; set; }
    //    public long MakeId { get; set; }
    //    public long ModelId { get; set; }
    //    public string ModifiedBy { get; set; }
    //    public DateTime ModifiedOn { get; set; }
    //    public long NetworkId { get; set; }
    //    public string NetworkName { get; set; }
    //    public long SerialNumber { get; set; }
    //    public long StatusId { get; set; }
    //    public string StatusName { get; set; }
    //    public long SubNetworkId { get; set; }
    //    public string SubNetworkName { get; set; }
    //    public long WarrantyDuration { get; set; }
    //    public DateTime WarrantyExpiryDate { get; set; }
    //    public long LocationId { get; set; }
        
    //    public  string  LocationName { get; set; }
    //    public DateTime WarrantyStartDate { get; set; }
    //}


}
