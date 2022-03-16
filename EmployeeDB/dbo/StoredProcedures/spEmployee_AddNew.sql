CREATE PROCEDURE [dbo].[spEmployee_AddNew]
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Phone nvarchar(50),
	@CompanyId int,
	@PasportType nvarchar(50),
	@PasportNumber nvarchar(50),
	@DepartmentName nvarchar(50),
	@DepartmentPhone nvarchar(50)
	
AS
begin
	DECLARE @DepartmentId int 

	IF NOT EXISTS (SELECT 1 FROM dbo.[Departments] where DepartmentName = @DepartmentName) 
	BEGIN
		INSERT INTO dbo.[Departments] (DepartmentName, DepartmentPhone) VALUES (@DepartmentName, @DepartmentPhone);
		SET @DepartmentId =  IDENT_CURRENT('Departments');
	END 
	ELSE
	BEGIN
		 SELECT TOP 1 @DepartmentId = Id FROM dbo.[Departments] where DepartmentName = @DepartmentName;
	END

	insert into dbo.[Pasports] (Type, Number) values (@PasportType, @PasportNumber);

	DECLARE @PasportId int = IDENT_CURRENT('Pasports');

	insert into dbo.[Employees] (Name, Surname, Phone, CompanyId, PasportId, DepatrmentId) values (@Name, @Surname, @Phone, @CompanyId, @PasportId, @DepartmentId)
	SELECT IDENT_CURRENT('Employees')
end

