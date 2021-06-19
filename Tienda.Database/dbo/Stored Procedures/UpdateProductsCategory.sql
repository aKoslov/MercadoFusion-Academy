CREATE   PROCEDURE dbo.UpdateProductsCategory (
	@Description nvarchar(50),
	@CategoryID tinyint
		)
AS
BEGIN
	SET NOCOUNT ON
	UPDATE dbo.ProductsCategories SET dbo.ProductsCategories.Description = @Description WHERE CategoryID = @CategoryID
	SELECT 1
END 
