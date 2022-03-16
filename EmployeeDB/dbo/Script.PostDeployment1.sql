IF NOT EXISTS (SELECT 1 FROM dbo.[Employees])
BEGIN
	
	INSERT INTO dbo.[Departments] (DepartmentName, DepartmentPhone) VALUES ('Dep1', '899999999');
	DECLARE @DepartmentId int =  IDENT_CURRENT('Departments');
	

	insert into dbo.[Pasports] (Type, Number) values ('Type1', '123444321');

	DECLARE @PasportId int = IDENT_CURRENT('Pasports');

	insert into dbo.[Employees] (Name, Surname, Phone, CompanyId, PasportId, DepatrmentId) values ('Ivan', 'Ivanov', '123123', 1, @PasportId, @DepartmentId)
	SELECT IDENT_CURRENT('Employees')
END