
CREATE   PROCEDURE [dbo].[GetProductByName]
	@Name [nvarchar] (50)
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM dbo.Products P WHERE P.Name LIKE '%' + @Name + '%'
END
