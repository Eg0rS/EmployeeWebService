CREATE PROCEDURE [dbo].[spEmployee_Delete]
	@Id int 
AS
BEGIN
	DELETE FROM dbo.[Employees] where Id = @Id
END
