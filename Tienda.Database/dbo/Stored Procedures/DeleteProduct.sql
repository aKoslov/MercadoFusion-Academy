CREATE   PROCEDURE dbo.DeleteProduct	(
	@ProductID [int]
		)
AS
	BEGIN
	SET NOCOUNT ON
	DELETE FROM dbo.Products WHERE ProductID = @ProductID
	END
