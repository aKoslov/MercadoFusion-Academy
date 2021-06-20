
CREATE     PROCEDURE [dbo].GetUsersList
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT UI.DNI, UI.Name, UI.LastName, U.PhoneNumber, UI.Username, UI.CreationDate FROM UsersInfo UI JOIN Users U ON U.Username = UI.Username
	END
