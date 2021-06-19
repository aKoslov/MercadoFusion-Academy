
CREATE     PROCEDURE [dbo].GetUsersList
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DNI, UI.Name, UI.LastName, UI.PhoneNumber, UI.Username, UI.CreationDate FROM UserInfo UI
	END
