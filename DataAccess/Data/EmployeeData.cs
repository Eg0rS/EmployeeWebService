using DataAccess.DataBaseAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class EmployeeData : IEmployeeData
    {
        private readonly IDataBaseAccess _db;

        public EmployeeData(IDataBaseAccess db)
        {
            _db = db;
        }

        public async Task<int?> InsertEmployee(EmployeeModel model)
        {
            var result = await _db.GetData<int, dynamic>(
                "spEmployee_AddNew", new
                {
                    model.Name,
                    model.Surename,
                    model.Phone,
                    model.CompanyId,
                    model.Pasport.Type,
                    model.Pasport.Number,
                    model.Department.DepartmentName,
                    model.Department.DepartmentPhone
                });
            return result.FirstOrDefault();
        }
        public async Task<EmployeeModel?> GetEmployeeById(int id)
        {
            var result = await _db.GetData<EmployeeModel, dynamic>(
                "sp_Employee_Get_By_Id", new { id });
            return result.FirstOrDefault();
        }
        public Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyId(int id) =>
            _db.GetData<EmployeeModel, dynamic>("spEmployee_GetEmpCompany", new { id });

        public Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyIdDepartment(int id, string department) =>
           _db.GetData<EmployeeModel, dynamic>("spEmployee_GetEmpCompany", new { id, department });

        public Task DeleteEmployee(int id) => _db.SetData("spEmployee_Delete", new { id });

        public Task UpdateEmployee(EmployeeModel model) => _db.SetData("sp_Employee_Update", new
        {
            model.Name,
            model.Surename,
            model.Phone,
            model.CompanyId,
            model.Pasport.Type,
            model.Pasport.Number,
            model.Department.DepartmentName,
            model.Department.DepartmentPhone
        });


    }
}
