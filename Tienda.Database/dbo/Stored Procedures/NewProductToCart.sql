
------------------------------------Stored Procedure para ProductToCart Insert------------------------------------

CREATE   PROCEDURE dbo.NewProductToCart (
	@CartID [int],
	@ProductID [int],
	@Quantity [smallint]	)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[ProductToCart] (CartID, ProductID, Quantity) VALUES (@CartID, @ProductID, @Quantity)
END
