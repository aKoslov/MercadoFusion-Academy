
CREATE   PROCEDURE [dbo].[RetrieveUserInfo]
	@userId smallint
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DocumentNumber DNI, UI.Name, UI.Surname LastName, UI.CreatedDate, UI.Username FROM Users UI WHERE UI.Id = @userId
	END
