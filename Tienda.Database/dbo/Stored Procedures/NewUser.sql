CREATE   PROCEDURE  dbo.NewUser  
	@Name nvarchar(30),
	@LastName nvarchar(30),
	@DNI char(11),
	@Username nvarchar(50),
	@Password nvarchar(300)/*,
	@Salt nvarchar(60)*/
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO [dbo].[Users] (Name, Surname, DocumentNumber, Username, Password) VALUES (@Name, @LastName, @DNI, @Username, @Password) 
END
