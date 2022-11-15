using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetSwitchGearDDLQuery : IRequest<List<ListSwitchGear>>
    {
        public string userId { get; set; }
        public int? _dispenserId { get; set; }
        public GetSwitchGearDDLQuery(string userId, int? dispenserId)
        {
            this.userId = userId;
            this._dispenserId = dispenserId;
        }
    }
}
