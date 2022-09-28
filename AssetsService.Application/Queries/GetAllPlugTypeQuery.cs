using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Queries
{
    public class GetAllPlugTypeQuery : IRequest<List<PlugTypeResponseData>>
    {
        public string userId { get; set; }
        public GetAllPlugTypeQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
