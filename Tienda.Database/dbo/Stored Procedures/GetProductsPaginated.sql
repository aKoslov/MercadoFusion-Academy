
CREATE    PROCEDURE [dbo].[GetProductsPaginated] (
	@index [tinyint],
	@fetch [tinyint]
	)
 AS
 BEGIN
	SET NOCOUNT ON
 SELECT * FROM dbo.ProductsInfo ORDER BY Name OFFSET ((@index - 1) * @fetch) ROWS FETCH NEXT @fetch ROW ONLY
END
