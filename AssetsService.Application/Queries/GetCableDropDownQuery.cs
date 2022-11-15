using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetCableDropDownQuery : IRequest<List<CableListDropDown>>
    {
        public string userId { get; set; }
        public int? dispenserId { get; set; }
        public GetCableDropDownQuery(string userId, int? dispenserId)
        {
            this.userId = userId;
            this.dispenserId = dispenserId.Value; 
        }
    }
}
