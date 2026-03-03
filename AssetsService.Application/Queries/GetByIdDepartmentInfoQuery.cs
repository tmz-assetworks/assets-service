using AssetsService.Core.Entities;
using MediatR;

namespace AssetsService.Application.Queries
{
    public class GetByIdDepartmentInfoQuery : IRequest<Department>
    {
        public long Id { get; set; }
        public GetByIdDepartmentInfoQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
