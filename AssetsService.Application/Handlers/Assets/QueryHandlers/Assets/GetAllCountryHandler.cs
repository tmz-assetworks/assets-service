using AssetsService.Core.Queries;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers
{
    public class GetAllCountryHandler : IRequestHandler<GetAllCountryQuery, List<CountryData>>
    {
        private readonly ICountryRepository _countryRepository;

        public GetAllCountryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<List<CountryData>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {

          return (List<CountryData>)await _countryRepository.GetAllCountry();

        }
    }
}
