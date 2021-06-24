

CREATE       PROCEDURE [dbo].[GetUsersList]
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT DocumentNumber, Name, Surname, Username, CreatedDate FROM Users 
	END
