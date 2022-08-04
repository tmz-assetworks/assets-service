using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateModelCommand : IRequest<ModelResponse>
    {
        
       
        public long ConnectorCount { get; set; }

        public string CreatedBy { get; set; }
      
        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public long ManufactureId { get; set; }
     
        public string ModelName { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual long PortId { get; set; }
      
        public virtual long ProtocolId { get; set; }
    

        public virtual long LevelId { get; set; }
       
    }
}
