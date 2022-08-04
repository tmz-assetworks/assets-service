using AssetsService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Responses.Assets
{
    public class ModelResponse
    {
       
        public long Id { get; set; }


       
        public long ConnectorCount { get; set; }


      
        public string CreatedBy { get; set; }


       
        public DateTime CreatedOn { get; set; }


        
        public bool IsActive { get; set; }




      
        public long ManufactureId { get; set; }


        
        public string ModelName { get; set; }


       
        public string ModifiedBy { get; set; }


        
        public DateTime ModifiedOn { get; set; }


       
        public long PortId { get; set; }
        public virtual Port Port { get; set; }

       
        public long ProtocolId { get; set; }
        public virtual Protocol Protocol { get; set; }

        public long LevelId { get; set; }
        public virtual Level Level { get; set; }
    }
}
