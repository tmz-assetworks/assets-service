using MediatR;

namespace AssetsService.Application.Queries
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int DepartmentId { get; set; }
        public DeleteDepartmentCommand(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
