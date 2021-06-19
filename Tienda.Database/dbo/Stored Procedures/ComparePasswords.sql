CREATE     PROCEDURE  [dbo].[ComparePasswords]  
	@Username nvarchar(50),
	@Password nvarchar(300)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Count(*) FROM Users WHERE Username = @Username AND Password = @Password GROUP BY Username
	
END