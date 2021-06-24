
CREATE   PROCEDURE [dbo].[RetrieveUserInfo]
	@Username nvarchar(50)
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DocumentNumber, UI.Name, UI.Surname, UI.CreatedDate, UI.Username FROM Users UI WHERE UI.Username = @Username
	END
