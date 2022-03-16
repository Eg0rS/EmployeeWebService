CREATE PROCEDURE [dbo].[sp_Employee_Update]
	@Id int,
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Phone nvarchar(50),
	@CompanyId int,
	@PasportType nvarchar(50),
	@PasportNumber nvarchar(50),
	@DepartmentName nvarchar(50),
	@DepartmentPhone nvarchar(50)
AS
BEGIN
	DECLARE  @DepartmentId int
	DECLARE @PasportId int

	UPDATE  Employees
	SET 
	Employees.Name = CASE WHEN @Name = NULL THEN Employees.Name ELSE @Name END,
	Employees.Surname = CASE WHEN @Surname = NULL THEN Employees.Surname ELSE @Surname END,
	Employees.Phone = CASE WHEN @Phone = NULL THEN Employees.Phone ELSE @Phone END
	WHERE Employees.Id = @Id 

	SELECT TOP 1 @PasportId =  Employees.PasportId FROM Employees WHERE Employees.Id = @Id

	UPDATE  Pasports
	SET 
	Pasports.Number = CASE WHEN @PasportNumber = NULL THEN Pasports.Number ELSE @PasportNumber END,
	Pasports.Type = CASE WHEN @PasportType = NULL THEN Pasports.Type ELSE @PasportType END
	WHERE Pasports.Id =  @PasportId

	SELECT TOP 1 @DepartmentId =  Employees.DepatrmentId FROM Employees WHERE Employees.Id = @Id

	UPDATE Departments
	SET
	Departments.Name =  CASE WHEN @DepartmentName = NULL THEN Departments.Name ELSE @DepartmentName END,
	Departments.Phone =  CASE WHEN @DepartmentPhone = NULL THEN Departments.Phone ELSE @DepartmentPhone END
	WHERE Departments.Id =  @PasportId
END
