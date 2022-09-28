using AssetsService.Application.Queries;
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
    public class GetDispenserDetailByIdHandler : IRequestHandler<GetDispenserDetailByIdQuery, GetDispenserResponse>
    {
        private readonly IDispenserRepository _dispenserRepository;
        public GetDispenserDetailByIdHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepository = dispenserRepository;
        }
        public async Task<GetDispenserResponse> Handle(GetDispenserDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return (GetDispenserResponse)await _dispenserRepository.GetDispenserDetailsById(request.Id);
        }
    }
}
