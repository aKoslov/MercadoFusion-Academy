CREATE   PROCEDURE [dbo].[UserTryLogin] (
	@username [nvarchar](50)
		)
AS
	BEGIN
	SELECT Salt FROM Users WHERE Username = @username
	END
