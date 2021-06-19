
---------------------------------------------------------------------------------------------------------
--------------------------------------- SPs para Updates Simples ----------------------------------------
---------------------------------------------------------------------------------------------------------
/*******************************************************************************************************/

------------------------------------Stored Procedure para Cart.IsOpen Update------------------------------------

CREATE   PROCEDURE dbo.CloseCart (
	@UserID [int]	)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE dbo.Carts SET dbo.Carts.IsOpen = 0 WHERE UserID = @UserID AND CartID = (SELECT TOP(1) CartID FROM dbo.Carts WHERE UserID = @UserID ORDER BY CartID DESC)
END 
