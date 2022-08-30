using AssetsService.Core.PagingHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
     
   // For Chargers Details Grid
    /// <summary>
    /// Auther: Pradeep Date: 08/08/2022
    /// </summary>
   
    public class DispensersDetailResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public List<DispensersDetail> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }
    }

    public class DispensersDetail
    {

        public string ChargerName { get; set; }
        public string ChargerBoxId { get; set; }
        public string ChargerType { get; set; }
        public string FaultSince { get; set; }
        public string LocationContactName { get; set; }
        public string TimeReported { get; set; }
        public long LocationId { get; set; }
        public string State { get; set; }
        public string LocationContactNumber { get; set; }
    }

    public class DispensersDetailRequest : QueryStringParameters
    {
        public string operatorId { get; set; }
    }

    public class ValidateChargerIdRequest
    {
        public string ChargeBoxId {get; set;}

    }


    public class ValidateChargerIdResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public  ChargerResponse data { get; set; }
    }

    public class ChargerResponse 
    {
        public long Id {get; set;}
        public string ChargeBoxId {get;set;}
        public bool status {get; set;}
    }

}
