using AssetsService.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{
    public class UpdateDepartmentCommand : IRequest<CreateDepartmentResult>
    {
        [Required]
        [MaxLength(200)]
        public string DepartmentName { get; set; }
        public decimal DeptkWhRate { get; set; }
        public string CreatedBy { get; set; }
        public int Id { get; set; }
    }
}
