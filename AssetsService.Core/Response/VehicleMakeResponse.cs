using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Entities;

namespace AssetsService.Core.Responses.Assets
{

    public class AllVehicleMake{
        
        public int StatusCode;
        public string StatusMessage;
        public List<VehicleMake> data{get;set;}
    }
   
    public class ListDropDown
    {
        public long Id { get; set; }
        public string Name { get; set; }
       public bool IsActive { get;set;}
    }

    public class VehicleMakeById{
        
        public int StatusCode;
        public string StatusMessage;
        public VehicleMake data{get;set;}
    }


}