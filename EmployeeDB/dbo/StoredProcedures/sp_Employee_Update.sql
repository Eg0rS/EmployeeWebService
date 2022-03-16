CREATE PROCEDURE [dbo].[sp_Employee_Update]
	@Id int,
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Phone nvarchar(50),
	@CompanyId int,
	@Type nvarchar(50),
	@Number nvarchar(50),
	@DepartmentName nvarchar(50),
	@DepartmentPhone nvarchar(50)
AS
BEGIN
	DECLARE  @DepartmentId int
	DECLARE @PasportId int

	UPDATE  Employees
	SET 
	Employees.Name = CASE  WHEN @Name IS NULL THEN Employees.Name ELSE @Name END,
	Employees.Surname = CASE WHEN @Surname IS NULL THEN Employees.Surname ELSE @Surname END,
	Employees.Phone = CASE WHEN @Phone IS NULL THEN Employees.Phone ELSE @Phone END
	WHERE Employees.Id = @Id 

	SELECT TOP 1 @PasportId =  Employees.PasportId FROM Employees WHERE Employees.Id = @Id

	UPDATE  Pasports
	SET 
	Pasports.Number = CASE WHEN @Number IS NULL THEN Pasports.Number ELSE @Number END,
	Pasports.Type = CASE WHEN @Type IS NULL THEN Pasports.Type ELSE @Type END
	WHERE Pasports.Id =  @PasportId

	SELECT TOP 1 @DepartmentId =  Employees.DepatrmentId FROM Employees WHERE Employees.Id = @Id

	UPDATE Departments
	SET
	Departments.DepartmentName =  CASE WHEN @DepartmentName IS NULL THEN Departments.DepartmentName ELSE @DepartmentName END,
	Departments.DepartmentPhone =  CASE WHEN @DepartmentPhone IS NULL THEN Departments.DepartmentPhone ELSE @DepartmentPhone END
	WHERE Departments.Id =  @PasportId
END
