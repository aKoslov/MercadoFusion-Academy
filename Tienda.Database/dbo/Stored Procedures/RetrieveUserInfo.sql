
CREATE   PROCEDURE [dbo].[RetrieveUserInfo]
	@Username nvarchar(50)
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DNI, UI.Name, UI.LastName, UI.PhoneNumber, UI.Username, UI.CreationDate FROM UserInfo UI JOIN Users U ON UI.Username = U.Username WHERE U.Username = @Username
	END
