using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class VehicleMakeResponse
    {
       
        public long Id { get; set; }

        public string Name { get; set; }
    
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }


        public string ModifiedBy { get; set; }
   
        public DateTime ModifiedOn { get; set; }
    }
}
