
CREATE     PROCEDURE [dbo].[UpdateUserInfo]
	@Username nvarchar(50),
	@Name nvarchar(50),
	@LastName nvarchar(50),
	@DNI int,
	@PhoneNumber nvarchar(15)
AS 
	BEGIN
	SET NOCOUNT ON
	UPDATE Users SET Name = @Name, LastName = @LastName, DNI = @DNI, PhoneNumber = @PhoneNumber WHERE Username = @Username
	END
