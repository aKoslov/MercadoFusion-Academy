
------------------------------------Vista Órdenes de Compra------------------------------------

CREATE   VIEW [dbo].[GetOrders] (
	ReceiptNumber,
	Username,
	FullName,
	Date,
	GrandTotal,
	Paid
	)
AS
	SELECT O.ReceiptNumber, U.Username, U.FullName, O.Date, O.GrandTotal, O.Paid FROM Orders O JOIN Users U ON U.UserID = O.UserID

