

CREATE   PROCEDURE [dbo].[UserLogin]	(
	@username [nvarchar](50),
	@password [nvarchar](300)
		)
AS
	BEGIN
	SET NOCOUNT ON
		SELECT UserID, Username FROM Users WHERE Username = @username AND Password = @password
	END
