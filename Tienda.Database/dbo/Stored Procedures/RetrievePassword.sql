CREATE     PROCEDURE [dbo].[RetrievePassword]
	@Username nvarchar(50)
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT Password FROM Users WHERE Username = @Username
	END
