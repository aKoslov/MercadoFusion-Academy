
------------------------------------Stored Procedure para Product Insert--------------------------------------

CREATE     PROCEDURE [dbo].[NewProduct] (
	@CatID tinyint,
	@Name nvarchar(50),
	@Desc nvarchar(50),
	@Price decimal(6,2),
	@StatusID tinyint )
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[Products] (CategoryID, Name, Description, Price, StatusID) VALUES (@CatID,@Name,@Desc,@Price,@StatusID)
END
