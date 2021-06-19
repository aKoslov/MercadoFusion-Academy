CREATE   PROCEDURE  [dbo].[NewUser]  
	@Name nvarchar(30),
	@LastName nvarchar(30),
	@DNI char(11),
	@Username nvarchar(50),
	@Password nvarchar(300),
	@Salt nvarchar(60)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @RowsAffected int
	INSERT INTO [dbo].[Users] (Name, LastName, DNI, Username, Password, Salt) VALUES (@Name, @LastName, @DNI, @Username, @Password, @Salt) 
	
END
