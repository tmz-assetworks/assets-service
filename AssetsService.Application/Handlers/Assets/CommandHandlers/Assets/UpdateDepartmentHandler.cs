using AssetsService.Application.Commands.Assets;
using AssetsService.Core.Mapper;
using AssetsService.Core.Repositories;
using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Handlers.Assets.CommandHandlers.Assets
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, CreateDepartmentResult>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentResult> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            CreateDepartmentResult createDepartmentResponse = new();
            var departmentEntitiy = Mapper.Mappers.Map<AssetsService.Core.Entities.Department>(request);
            if (departmentEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            createDepartmentResponse = await _departmentRepository.UpdateDepartment(departmentEntitiy);
            return createDepartmentResponse;
        }
    }
}
