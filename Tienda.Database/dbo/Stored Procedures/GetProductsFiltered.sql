CREATE     PROCEDURE [dbo].[GetProductsFiltered] (
	@query nvarchar (max),
	@index [tinyint],
	@fetch tinyint
		)
AS
	BEGIN
		SET NOCOUNT ON
		SET @query = CONCAT('SELECT * FROM dbo.ProductsInfo WHERE ',@query,' ORDER BY Name OFFSET ', ((@index - 1) * @fetch), ' ROWS FETCH NEXT ', @fetch, ' ROWS ONLY')
		EXEC sp_executesql @query -- esto tengo que pulirlo más 
								  -- para prevenir sql injections
	END
