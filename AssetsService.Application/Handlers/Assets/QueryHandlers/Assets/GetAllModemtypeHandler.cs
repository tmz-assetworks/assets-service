using AssetsService.Core.Repositories.Assets;
using AssetsService.Application.Queries;
using MediatR;
using AssetsService.Core.Responses.Assets;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllModemTypeHandler : IRequestHandler<GetAllModemTypeDataQuery, List<ModemTypeNameList>>
    {
        private readonly IModemRepository _modemRepo;

        public GetAllModemTypeHandler(IModemRepository ModemRepository)
        {
            _modemRepo = ModemRepository;
        }
        public async Task<List<AssetsService.Core.Responses.Assets.ModemTypeNameList>> Handle(GetAllModemTypeDataQuery request, CancellationToken cancellationToken)
        {
            return (List<AssetsService.Core.Responses.Assets.ModemTypeNameList>) await _modemRepo.GetAllModemType();
        }
    }
}