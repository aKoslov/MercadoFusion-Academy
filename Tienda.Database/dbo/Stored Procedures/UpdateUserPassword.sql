CREATE     PROCEDURE  [dbo].[UpdateUserPassword]  
	@Username nvarchar(50),
	@Password nvarchar(300),
	@NewSalt nvarchar(150)
AS

BEGIN
	SET NOCOUNT ON
	UPDATE Users set Password = @Password, Salt = @NewSalt WHERE Username = @Username
	SELECT Password FROM Users WHERE Username = @Username
END