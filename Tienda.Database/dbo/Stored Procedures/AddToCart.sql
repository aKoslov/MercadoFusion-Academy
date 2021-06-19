------------------------------------Stored Procedure para ProductToCart Insert----------------------------------

CREATE   PROCEDURE dbo.AddToCart (
	@UserID [int],
	@ProductID [int],
	@Quantity [smallint]	)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @CartID [int] = (SELECT TOP(1) C.CartID FROM dbo.Carts C WHERE UserID = @UserID)
    INSERT INTO [dbo].[ProductToCart] (CartID, ProductID, Quantity) VALUES (@CartID, @ProductID, @Quantity)
END
