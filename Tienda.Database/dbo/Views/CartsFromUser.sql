
------------------------------------Vista Carros de Usuario------------------------------------

CREATE   VIEW dbo.CartsFromUser (
	CartID,
	UserID,
	Date,
	GrandTotal,
	Ended
	)
AS
	SELECT * FROM Carts 

