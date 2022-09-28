using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetConnectorTypeQuery : IRequest<List<ConnectorTypeResponseData>>
    {
        public string userId { get; set; }
        public GetConnectorTypeQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
