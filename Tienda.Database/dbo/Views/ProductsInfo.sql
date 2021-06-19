CREATE   VIEW dbo.ProductsInfo (
	ProductID,
	Category,
	Name,
	Description,
	Price,
	AddedDate,
	StatusID
	)
AS
	SELECT P.ProductID, C.CategoryID, P.Name, P.Description, P.Price, P.AddedDate, P.StatusID FROM [dbo].[Products] P JOIN ProductsCategories C ON P.CategoryID = C.CategoryID

