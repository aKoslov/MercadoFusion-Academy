CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [CategoryID]  TINYINT         NOT NULL,
    [Name]        NVARCHAR (50)   NOT NULL,
    [Description] NVARCHAR (250)  NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [StatusID]    TINYINT         NOT NULL,
    [AddedDate]   DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_Product_ProductsCategories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[ProductsCategories] ([CategoryID]),
    CONSTRAINT [FK_Product_ProductsStates] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[ProductsStates] ([StateID])
);

