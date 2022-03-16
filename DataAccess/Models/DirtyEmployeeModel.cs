using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DirtyEmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentPhone { get; set; }
        public string? Type { get; set; }
        public string? Number { get; set; }
    }
}
