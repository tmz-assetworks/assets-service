using AssetsService.Application.Queries;
using AssetsService.Core.Queries;
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
    public class GetStateByCountryIdHandler : IRequestHandler<GetStateByCountryIdQuery, List<StateData>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetStateByCountryIdHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<List<StateData>> Handle(GetStateByCountryIdQuery request, CancellationToken cancellationToken)
        {
            return (List<StateData>)await _countryRepository.GetStateByCountryId(Convert.ToInt32(request.Id));
        }
    }
}
