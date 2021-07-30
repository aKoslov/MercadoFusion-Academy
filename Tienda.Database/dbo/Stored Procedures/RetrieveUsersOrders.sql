CREATE         PROCEDURE [dbo].[RetrieveUsersOrders] (
	@userid nvarchar(100)
		)
AS
	BEGIN
		SET NOCOUNT ON
		SELECT Id, BillingNumber, CreatedDate, UserId, StatusId FROM dbo.Orders WHERE UserId LIKE @userid ORDER BY CreatedDate DESC
		SELECT OL.ProductId, OL.OrderId, OL.Quantity, OL.UnitPrice FROM dbo.OrderLines OL JOIN dbo.Orders O ON OL.OrderId = O.Id WHERE O.UserId LIKE  @userid
		SELECT COUNT(*) FROM dbo.Orders WHERE UserId LIKE @userid
	END