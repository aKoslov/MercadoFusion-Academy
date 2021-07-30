CREATE   PROCEDURE [dbo].[DeleteProduct]	(
	@ProductID [int]
		)
AS
	BEGIN
	SET NOCOUNT ON
	IF (SELECT COUNT(*) FROM dbo.Products WHERE Id = @ProductID) > 0
	BEGIN
	DELETE FROM dbo.Products WHERE Id = @ProductID
	SELECT 1
	END
	ELSE
	BEGIN 
	SELECT 0
	END
END
