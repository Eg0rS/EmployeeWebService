using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IEmployeeData
    {
        Task DeleteEmployee(int id);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyId(int id);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByCompanyIdDepartment(int id, string department);
        Task<int?> InsertEmployee(EmployeeModel model);
        Task UpdateEmployee(int id, EmployeeModel model);
    }
}