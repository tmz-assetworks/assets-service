using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AssetsService.Core.Entities
{
    public partial class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }
        [StringLength(40, MinimumLength = 2)]
        public string DepartmentName { get; set; }
        public string ContactPersonName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal? DeptkWhRate { get; set; }
    }
}