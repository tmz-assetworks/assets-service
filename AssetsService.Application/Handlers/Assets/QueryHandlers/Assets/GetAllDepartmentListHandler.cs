using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using AssetsService.Core.Repositories.Assets;
using AssetsService.Core.Response;
using AssetsService.Core.Responses.Assets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllDepartmentListHandler : IRequestHandler<GetAllDepartmentListQuery, List<AllDepartmentList>>
    {
        private readonly ILocationRepository _LocationRepo;

        public GetAllDepartmentListHandler(ILocationRepository LocationRepository)
        {
            _LocationRepo = LocationRepository;
        }
        
        public async Task<List<AllDepartmentList>> Handle(GetAllDepartmentListQuery request, CancellationToken cancellationToken)
        {
           return (List<AllDepartmentList>)await _LocationRepo.GetAllDepartmentList();
        }
    }
}
