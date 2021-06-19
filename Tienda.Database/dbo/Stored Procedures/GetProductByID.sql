
CREATE   PROCEDURE [dbo].[GetProductByID]
	@ID [int]
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM dbo.ProductsInfo P WHERE P.ProductID = @ID
END
