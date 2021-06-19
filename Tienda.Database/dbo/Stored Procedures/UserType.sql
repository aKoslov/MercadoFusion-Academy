
CREATE   PROCEDURE [dbo].[UserType]
	@Username nvarchar(50)
AS
	BEGIN
	SET NOCOUNT ON
	SELECT UserType FROM Users WHERE Username = @Username
	END
