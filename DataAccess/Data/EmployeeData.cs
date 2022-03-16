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
                    model.Surname,
                    model.Phone,
                    model.CompanyId,
                    model.Pasport.Type,
                    model.Pasport.Number,
                    model.Department.DepartmentName,
                    model.Department.DepartmentPhone
                });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyId(int CompanyId) {
           
            IEnumerable<DirtyEmployeeModel>? dirtyresult = await _db.GetData<DirtyEmployeeModel, dynamic>("spEmployee_GetEmpCompany", new { CompanyId });
            return GetModels(dirtyresult);
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyIdDepartment(int CompanyId, string DepartmentName)
        {
            IEnumerable<DirtyEmployeeModel>? dirtyresult = await _db.GetData<DirtyEmployeeModel, dynamic>("spEmployee_GetEmpCompanyDepartment", new { CompanyId, DepartmentName});
            return GetModels(dirtyresult);
        }
  

        public Task DeleteEmployee(int id) => _db.SetData("spEmployee_Delete", new { id });

        public Task UpdateEmployee(int Id, EmployeeModel model) => _db.SetData("sp_Employee_Update", new
        {
            Id,
            model.Name,
            model.Surname,
            model.Phone,
            model.CompanyId,
            model.Pasport.Type,
            model.Pasport.Number,
            model.Department.DepartmentName,
            model.Department.DepartmentPhone
        });

        private IEnumerable<EmployeeModel> GetModels(IEnumerable<DirtyEmployeeModel>? dirtyresult) {
            List<EmployeeModel> res = new List<EmployeeModel>();
            foreach (DirtyEmployeeModel model in dirtyresult)
            {
                res.Add(new EmployeeModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Surname = model.Surname,
                    Phone = model.Phone,
                    CompanyId = (int)model.CompanyId,
                    Pasport = new PasportModel() { Type = model.Type, Number = model.Number },
                    Department = new DepartmentModel() { DepartmentName = model.DepartmentName, DepartmentPhone = model.DepartmentPhone }
                });
            }
            return res;
        }

    }
}
