using AssetsService.Application.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssetsService.Core.Response.ModelResponse;

namespace AssetsService.Application.Queries
{
    public class GetAllModelDataQuery : IRequest<List<AssetsService.Core.Entities.Model>>
    {
        public ModelDataRequest modelDataRequest { get; set; }
        public GetAllModelDataQuery(ModelDataRequest _modelDataRequest)
        {
            this.modelDataRequest = _modelDataRequest;
        }
    }
}
