using AssetsService.Application.Queries;
using AssetsService.Core.Repositories;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.QueryHandlers.Assets
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.DeleteDepartmentById(request.DepartmentId);
        }
    }
}
