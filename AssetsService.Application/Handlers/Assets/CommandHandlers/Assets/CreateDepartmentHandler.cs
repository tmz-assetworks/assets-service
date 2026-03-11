using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentResult>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentResult> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Department>(request);
            if (departmentEntitiy is null)
            {
                throw new InvalidOperationException("Issue with mapper");
            }
            return await _departmentRepository.CreateDepartment(departmentEntitiy);
             
        }
    }
}
