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
    public class GetCityByStateIdHandler : IRequestHandler<GetCityByStateIdQuery, List<CityData>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetCityByStateIdHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<List<CityData>> Handle(GetCityByStateIdQuery request, CancellationToken cancellationToken)
        {
            return (List<CityData>)await _countryRepository.GetCityByStateId(Convert.ToInt32(request.Id));
        }
    }
}
