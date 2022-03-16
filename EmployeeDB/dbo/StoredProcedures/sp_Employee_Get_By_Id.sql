CREATE PROCEDURE [dbo].[sp_Employee_Get_By_Id]
	@Id int 
AS
Begin
SELECT 
	Employees.Id, Employees.Name, Employees.Surname, Employees.Phone, Employees.CompanyId, Pasports.Type, Pasports.Number, Departments.Name, Departments.Phone 
	FROM dbo.[Employees] JOIN Pasports ON Pasports.Id = Employees.PasportId JOIN Departments ON Departments.Id = Employees.DepatrmentId 
	WHERE Employees.Id = @Id
end
