
using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetModemDDLHandler : IRequestHandler<GetModemDDLQuery, List<ListDropDown>>
    {
        private readonly IDispenserRepository _dispenserRepo;

        public GetModemDDLHandler(IDispenserRepository dispenserRepository)
        {
            _dispenserRepo = dispenserRepository;
        }
        public async Task<List<ListDropDown>> Handle(GetModemDDLQuery request, CancellationToken cancellationToken)
        {
            return (List<ListDropDown>)await _dispenserRepo.GetModemDDLList(request.userId);
        }
    }
}
