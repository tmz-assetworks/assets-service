using AssetsService.Core.Response;
using MediatR;

namespace AssetsService.Application.Queries
{
    public class GetAllDepartmentQuery : IRequest<StatusAllDepartmentResponse>
    {
        public GetAllDepartmentRequest GetAllDepartmentRequest { get; set; }

        public GetAllDepartmentQuery(GetAllDepartmentRequest getAllDepartmentRequest)
        {
            this.GetAllDepartmentRequest = getAllDepartmentRequest;

        }
    }
}
