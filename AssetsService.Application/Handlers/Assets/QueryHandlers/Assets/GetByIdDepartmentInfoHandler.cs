using AssetsService.Application.Queries;
using AssetsService.Core.Entities;
using AssetsService.Core.Repositories;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetByIdDepartmentInfoHandler : IRequestHandler<GetByIdDepartmentInfoQuery, Department?>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetByIdDepartmentInfoHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(GetByIdDepartmentInfoQuery request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetDepartmentInfoById(request.Id);
        }

    }
}
