CREATE TABLE [dbo].[ProductToCart] (
    [CartID]    INT            NOT NULL,
    [ProductID] INT            NOT NULL,
    [Quantity]  SMALLINT       NOT NULL,
    [UnitPrice] DECIMAL (6, 2) DEFAULT ((0)) NULL,
    [Subtotal]  AS             ([Quantity]*[UnitPrice]),
    CONSTRAINT [PK_ProductToCart] PRIMARY KEY CLUSTERED ([CartID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_ProductToCart_Cart] FOREIGN KEY ([CartID]) REFERENCES [dbo].[Carts] ([CartID]),
    CONSTRAINT [FK_ProductToCart_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);


GO

---------------------------------------------------------------------------------------------------------
------------------------------------------------ Triggers -----------------------------------------------
---------------------------------------------------------------------------------------------------------
/*******************************************************************************************************/

------------------------------------Trigger para Custom Insert en ProductToCart--------------------------
------------------Inserta en PTC.UnitPrice el precio unitario--------------
------------------Permite hacia el futuro chequear los precios al momento de la órden--------------------

CREATE   TRIGGER dbo.T_UnitPrice_ProductToCart
	ON dbo.ProductToCart
	INSTEAD OF INSERT
	AS
	BEGIN
		INSERT ProductToCart (CartID, ProductID, Quantity, UnitPrice)
		SELECT I.[CartID], I.[ProductID], I.[Quantity], P.[Price]
			FROM inserted I JOIN dbo.Products P ON I.[ProductID] = P.[ProductID]
	END

