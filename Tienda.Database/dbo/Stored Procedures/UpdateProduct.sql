
------------------------------- Stored Procedure para Product Update --------------------------------

CREATE   PROCEDURE dbo.UpdateProduct	(
	@ProductID [int],
	@CategoryID [tinyint],
	@Name [nvarchar] (50),
	@Description [nvarchar] (50),
	@Price [decimal] (18,2),
	@StatusID [tinyint]
		)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE dbo.Products SET CategoryID = @CategoryID, Name = @Name, Description = @Description, Price = @Price, StatusID = @StatusID WHERE ProductID = @ProductID
END
