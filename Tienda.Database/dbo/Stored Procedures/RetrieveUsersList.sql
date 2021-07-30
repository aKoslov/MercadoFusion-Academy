

CREATE       PROCEDURE [dbo].[RetrieveUsersList]
AS 
	BEGIN
	SET NOCOUNT ON
	SELECT DocumentNumber, Name, Surname, Username, CreatedDate FROM Users 
	SELECT COUNT(*) FROM dbo.Users
	END