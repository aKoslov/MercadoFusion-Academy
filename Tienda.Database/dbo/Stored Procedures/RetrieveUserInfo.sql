
CREATE   PROCEDURE [dbo].[RetrieveUserInfo]
	@Username nvarchar(50)
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DNI, UI.Name, UI.LastName, U.PhoneNumber, UI.Username, UI.CreationDate FROM UsersInfo UI JOIN Users U ON UI.Username = U.Username WHERE U.Username = @Username
	END
