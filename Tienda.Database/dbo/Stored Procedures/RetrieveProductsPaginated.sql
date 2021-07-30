
CREATE    PROCEDURE [dbo].[RetrieveProductsPaginated] (
	@index [tinyint],
	@fetch [tinyint],
	@order [nvarchar](max)
	)
 AS
 BEGIN
	SET NOCOUNT ON
	SET @index = ((@index - 1) * @fetch)
	DECLARE @query nvarchar(max) = CONCAT('SELECT Id, Name, Description, Price, CreatedDate, CategoryId, StatusId FROM dbo.Products ORDER BY ', @order, ' OFFSET ', @index,  ' ROWS FETCH NEXT ', @fetch, ' ROWS ONLY')
	EXEC sp_executesql @query
	SELECT COUNT(*) FROM dbo.Products
	SELECT TOP(1) Price FROM dbo.Products ORDER BY Price DESC
	SELECT TOP(1) Price FROM dbo.Products ORDER BY Price ASC
END