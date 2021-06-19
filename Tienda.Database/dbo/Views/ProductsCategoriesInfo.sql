
	-- SELECT * FROM dbo.GetProducts

--------------------------------Vista Categorías de Productos------------------------------------

CREATE   VIEW [dbo].[ProductsCategoriesInfo]		(
	CategoryID,
	Description,
	AddedDate
		)
	AS

	SELECT * FROM dbo.ProductsCategories
