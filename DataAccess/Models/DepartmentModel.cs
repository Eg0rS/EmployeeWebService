using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DepartmentModel
    {
        public string DepartmentName { get; set; }
        [Phone]
        public string DepartmentPhone { get; set; }
    }
}
