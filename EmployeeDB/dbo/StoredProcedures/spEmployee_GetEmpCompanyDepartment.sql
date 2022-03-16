CREATE PROCEDURE [dbo].[spEmployee_GetEmpCompanyDepartment]
	@CompanyId int,
	@DepartmentName nvarchar(50)
AS
BEGIN
	SELECT 
	Employees.Id, Employees.Name, Employees.Surname, Employees.Phone, Employees.CompanyId, Pasports.Type, Pasports.Number, Departments.DepartmentName, Departments.DepartmentPhone 
	FROM dbo.[Employees] JOIN Pasports ON Pasports.Id = Employees.PasportId JOIN Departments ON Departments.Id = Employees.DepatrmentId 
	WHERE CompanyId = @CompanyId AND Departments.DepartmentName = @DepartmentName
END
