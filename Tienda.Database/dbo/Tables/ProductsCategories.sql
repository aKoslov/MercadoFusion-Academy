CREATE TABLE [dbo].[ProductsCategories] (
    [CategoryID]  TINYINT       IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [AddedDate]   DATETIME      DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_ProductsCategories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

