using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Response
{
    public class CreateDepartmentResult
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public string DepartmentName { get; set; }
    }
}
