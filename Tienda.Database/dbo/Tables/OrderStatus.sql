CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusId] TINYINT      IDENTITY (1, 1) NOT NULL,
    [Description]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED ([OrderStatusId] ASC)
);



