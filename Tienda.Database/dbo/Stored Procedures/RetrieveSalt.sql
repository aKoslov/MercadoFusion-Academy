CREATE     PROCEDURE  [dbo].[RetrieveSalt]  
	@Username nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON
	SELECT Salt FROM Users WHERE Username = @Username
	
END
