
CREATE   PROCEDURE [dbo].[RetrieveProductByName]
	@Name [nvarchar] (50)
AS
BEGIN
	SET NOCOUNT ON
	SET @Name = '%' + @Name + '%'
		DECLARE @query nvarchar(max) = CONCAT('SELECT Id, Name, Description, Price, CreatedDate, CategoryId, StatusId FROM dbo.Products WHERE Name LIKE ''', @name,''' ORDER BY id ASC')
		EXEC sp_executesql @query -- esto tengo que pulirlo más 
								  -- para prevenir sql injections
		SET @query = CONCAT('SELECT COUNT(*) FROM dbo.Products WHERE Name LIKE ''', @name,'''')
		EXEC sp_executesql @query
		SET @query = CONCAT('SELECT TOP(1) Price FROM dbo.Products WHERE Name LIKE ''', @name,''' ORDER BY Price DESC')
		EXEC sp_executesql @query
		SET @query = CONCAT('SELECT TOP(1) Price FROM dbo.Products WHERE Name LIKE ''', @name,''' ORDER BY Price ASC')
		EXEC sp_executesql @query
END