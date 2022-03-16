using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        [Phone]
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public PasportModel Pasport { get; set; }
        public DepartmentModel Department { get; set; }
    }
}
