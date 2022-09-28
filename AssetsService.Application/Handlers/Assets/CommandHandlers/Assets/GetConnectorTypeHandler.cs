using AssetsService.Application.Queries;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class GetConnectorTypeHandler : IRequestHandler<GetConnectorTypeQuery, List<ConnectorTypeResponseData>>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public GetConnectorTypeHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepo = dispenserRepository;
        }
        public async Task<List<ConnectorTypeResponseData>> Handle(GetConnectorTypeQuery request, CancellationToken cancellationToken)
        {
            return (List<ConnectorTypeResponseData>)await _dispenserRepo.GetConnectorType(request.userId);
        }
    }
}
