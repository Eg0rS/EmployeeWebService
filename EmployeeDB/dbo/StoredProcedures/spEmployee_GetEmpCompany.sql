CREATE PROCEDURE [dbo].[spEmployee_GetEmpCompany]
	@CompanyId int
AS
BEGIN
	SELECT 
	Employees.Id, Employees.Name, Employees.Surname, Employees.Phone, Employees.CompanyId, Pasports.Type, Pasports.Number, Departments.Name, Departments.Phone 
	FROM dbo.[Employees] JOIN Pasports ON Pasports.Id = Employees.PasportId JOIN Departments ON Departments.Id = Employees.DepatrmentId 
	WHERE CompanyId = @CompanyId 
END
