using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentQuery, StatusAllDepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<StatusAllDepartmentResponse> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            return (StatusAllDepartmentResponse)await _departmentRepository.GetAllDepartment(request.GetAllDepartmentRequest);
        }
    }
}
