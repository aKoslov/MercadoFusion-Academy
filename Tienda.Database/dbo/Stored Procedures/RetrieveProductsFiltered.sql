CREATE     PROCEDURE [dbo].[RetrieveProductsFiltered] (
	@category nvarchar,
	@pricemin decimal,
	@pricemax decimal,
	@status nvarchar,
	@index [tinyint],
	@fetch [tinyint]
		)
AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @query nvarchar(max) = CONCAT('SELECT Id, Name, Description, Price, CreatedDate, CategoryId, StatusId FROM dbo.Products WHERE CategoryId LIKE ''', @category,''' AND Price > ', @pricemin, ' AND Price < ', @pricemax, ' AND StatusID LIKE ''', @status, ''' ORDER BY Name OFFSET ', ((@index - 1) * @fetch), ' ROWS FETCH NEXT ', @fetch, ' ROWS ONLY')
		EXEC sp_executesql @query -- esto tengo que pulirlo más 
								  -- para prevenir sql injections
		SET @query = CONCAT('SELECT COUNT(*) FROM dbo.Products WHERE CategoryId LIKE ''', @category,''' AND Price > ', @pricemin, ' AND Price < ', @pricemax, ' AND StatusID LIKE ''', @status, '''')
		EXEC sp_executesql @query
		SET @query = CONCAT('SELECT TOP(1) Price FROM dbo.Products WHERE CategoryId LIKE ''', @category,''' AND Price > ', @pricemin, ' AND Price < ', @pricemax, ' AND StatusID LIKE ''', @status, ''' ORDER BY Price DESC')
		EXEC sp_executesql @query
		SET @query = CONCAT('SELECT TOP(1) Price FROM dbo.Products WHERE CategoryId LIKE ''', @category,''' AND Price > ', @pricemin, ' AND Price < ', @pricemax, ' AND StatusID LIKE ''', @status, ''' ORDER BY Price ASC')
		EXEC sp_executesql @query
		
	END