
CREATE    PROCEDURE [dbo].[GetProductsPaginated] (
	@index [tinyint],
	@fetch [tinyint]
	)
 AS
 BEGIN
	SET NOCOUNT ON
 SELECT * FROM dbo.Products ORDER BY Name OFFSET ((@index - 1) * @fetch) ROWS FETCH NEXT @fetch ROWS ONLY
END
