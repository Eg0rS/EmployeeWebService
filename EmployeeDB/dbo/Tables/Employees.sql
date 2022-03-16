CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(50) NOT NULL, 
    [CompanyId] INT NOT NULL, 
    [PasportId] INT NOT NULL, 
    [DepatrmentId] INT NULL
)
