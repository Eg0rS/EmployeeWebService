using DataAccess.Data;
using DataAccess.Models;
using

namespace EmployeeWebService
{
    public static class Api
    {
        public static void CofigureApi(this WebApplication app) 
        {
            app.MapPost("/Employee", InsertEmployee);
            app.MapGet("/Employee/Company{id}", GetEmployeesByCompanyId);
            app.MapGet("/Employee/Company/{id}/Depatment/{name}", GetEmployeesByCompanyIdDepartment);
            app.MapPut("/Employee", UpdateEmployee);
            app.MapDelete("/Employee/{id}", DeleteEmployee);
        }

        ///<summary>
        ///Endpoint for adding an employee to the database.
        ///<summary>
        private static async Task<IResult> InsertEmployee(EmployeeModel model, IEmployeeData data) 
        {
            try
            {
                int? i = await data.InsertEmployee(model);
                return Results.Json(new {id = i});
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }
        ///<summary>
        ///Endpoint to get all company employees with a given ID.
        ///<summary>
        private static async Task<IResult> GetEmployeesByCompanyId(int companyid, IEmployeeData data)
        {
            try
            { 
                return Results.Json(await data.GetEmployeesByCompanyId(companyid));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        ///<summary>
        ///Endpoint to get all company employees with a given ID and department name.
        ///<summary>
        private static async Task<IResult> GetEmployeesByCompanyIdDepartment(int companyid, string departmentName, IEmployeeData data)
        {
            try
            {
                return Results.Json(await data.GetEmployeesByCompanyIdDepartment(companyid, departmentName));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        ///<summary>
        ///Endpoint for updating information about an employee with a given ID.
        ///<summary>
        private static async Task<IResult> UpdateEmployee(int id, EmployeeModel model, IEmployeeData data)
        {
            try
            {
                await data.UpdateEmployee(id, model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        ///<summary>
        ///Endpoint for deleting information about an employee with a given ID.
        ///<summary>
        private static async Task<IResult> DeleteEmployee(int id, IEmployeeData data)
        {
            try
            {
                await data.DeleteEmployee(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
