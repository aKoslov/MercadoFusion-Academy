
CREATE       PROCEDURE  [dbo].[UpdateUserPassword]  
	@Username nvarchar(50),
	@Password nvarchar(300)
AS

BEGIN
	SET NOCOUNT ON
	UPDATE Users SET Password = @Password WHERE Username = @Username
	SELECT Password FROM Users WHERE Username = @Username
END