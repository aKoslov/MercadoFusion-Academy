CREATE TABLE [dbo].[ProductToOrder] (
    [OrderID]   INT            NOT NULL,
    [ProductID] INT            NOT NULL,
    [Quantity]  SMALLINT       NULL,
    [UnitPrice] DECIMAL (6, 2) DEFAULT ((0)) NULL,
    [Subtotal]  AS             ([Quantity]*[UnitPrice]),
    CONSTRAINT [PK_ProductToOrder] PRIMARY KEY CLUSTERED ([OrderID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_ProductToOrder_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    CONSTRAINT [FK_ProductToOrder_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

