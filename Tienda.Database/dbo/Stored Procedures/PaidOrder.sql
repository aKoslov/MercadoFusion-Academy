
----------------------------------- Stored Procedure para Orders.Paid Update ------------------------------------					

CREATE   PROCEDURE dbo.PaidOrder (
	@UserID [int]
	)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE dbo.Orders SET Paid = 1 WHERE OrderID = (SELECT TOP(1) OrderID FROM dbo.Orders WHERE UserID = @UserID ORDER BY OrderID DESC) 
END
