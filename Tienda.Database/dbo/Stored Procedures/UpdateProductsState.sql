
------------------------------- Stored Procedure para Products.Available Update --------------------------------

CREATE   PROCEDURE dbo.UpdateProductsState	(
	@ProductID [int],
	@NewState [tinyint]
		)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE dbo.Products SET StatusID = @NewState WHERE Id = @ProductID
END
