using AssetsService.Core.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetsService.Application.Commands.Assets
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentResult>
    {
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        [MaxLength(200)]
        public string DepartmentName { get; set; }
        public decimal DeptkWhRate { get; set; }
    }
}
