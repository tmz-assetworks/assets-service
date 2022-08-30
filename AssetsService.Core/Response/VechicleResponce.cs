using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;
using AssetsService.Core.PagingHelper;

namespace AssetsService.Core.Responses.Assets
{


   

   
    public class AllVehicle
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Active {get; set;}
        public string Inactive {get; set;}
        public PagedList<Vehicle> data { get; set; }
        public PaginationResponse paginationResponse { get; set; }

    }

    public class StatusVehicleresponcse
    {
         public string Active {get; set;}
        public string Inactive {get; set;}
        public PagedList<Vehicle> data { get; set; }

    }
public class VehicleId{
    public int StatusCode { get; set;}
    public string StatusMessage { get;set;}

    public Vehicle data {get;set;}
}
 public class GetAllVehicleRequest : QueryStringParameters
    {
        public string? opratorid { get; set; }
    }
  
}
