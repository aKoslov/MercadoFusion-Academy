

CREATE   PROCEDURE [dbo].UserType
	@Username nvarchar(50)
AS
	BEGIN
	SET NOCOUNT ON
	SELECT StatusId FROM Users WHERE Username = @Username
	END
