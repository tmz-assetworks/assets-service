using AssetsService.Application.Queries;
using AssetsService.Application.Responses.Assets;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetPlugTypeHandler : IRequestHandler<GetAllPlugTypeQuery, List<PlugTypeResponseData>>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public GetPlugTypeHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepo = dispenserRepository;
        }
        public async Task<List<PlugTypeResponseData>> Handle(GetAllPlugTypeQuery request, CancellationToken cancellationToken)
        {
            return (List<PlugTypeResponseData>)await _dispenserRepo.GetAllPlugType(request.userId);
        }
    }
}
