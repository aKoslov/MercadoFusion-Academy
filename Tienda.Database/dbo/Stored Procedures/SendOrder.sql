
---------------------------------------------------------------------------------------------------------
--------------------------------------- SPs para Inserts Complejos --------------------------------------
---------------------------------------------------------------------------------------------------------
/*******************************************************************************************************/

------------------------------------Stored Procedure para Order + ProductToOrder Insert-------------------------

CREATE   PROCEDURE dbo.SendOrder (
	@UserID [int]
	)
AS
BEGIN
	SET NOCOUNT ON;
		-- Encontrar último carrrito cerrado del usuario del cual trasladar datos
	DECLARE @CartID int = (SELECT TOP(1) C.CartID FROM dbo.Carts C WHERE UserID = @UserID AND C.IsOpen = 0 ORDER BY C.CartID DESC)
		-- Ingresar nueva orden e inmediatamente guardar el valor de ID asignado
	INSERT INTO [dbo].[Orders] (UserID) VALUES (@UserID)
	DECLARE @OrderID int = (SELECT TOP(1) OrderID FROM dbo.Orders WHERE UserID = @UserID ORDER BY OrderID DESC)
		-- Veces por producto que se tiene que repetir el procesado
	DECLARE @NumberOfProducts tinyint = (SELECT COUNT(*) FROM dbo.ProductToCart WHERE CartID = @CartID GROUP BY CartID) 
		-- Declaración de variables a ingresar
	DECLARE @ProductID [int]
	DECLARE @Quantity [smallint]
	DECLARE @UnitPrice [decimal] (6,2)
		-- Declaración iterador e inicio del bucle
	DECLARE @Iterator [tinyint] = 0
	WHILE @NumberOfProducts > 0
	BEGIN

				-- Encontrar líneas de pedido dentro del carrito
				-- Guardar detalles temporalmente para ingresar en la Orden

		SELECT @ProductID = ProductID, @Quantity = Quantity, @UnitPrice = UnitPrice 
			FROM ProductToCart 
				WHERE CartID = @CartID ORDER BY CartID OFFSET @Iterator ROWS FETCH NEXT 1 ROW ONLY

				-- Ingresar valores encontrados
				
		INSERT INTO [dbo].[ProductToOrder] (OrderID, ProductID, Quantity, UnitPrice) 
			VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice)

				-- Recorrer Iteradores

		SET @NumberOfProducts = @NumberOfProducts - 1
		SET @Iterator = @Iterator + 1

	END
END
