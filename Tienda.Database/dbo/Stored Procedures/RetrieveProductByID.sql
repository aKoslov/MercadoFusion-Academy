
CREATE   PROCEDURE [dbo].[RetrieveProductByID]
	@ID [int]
AS 
BEGIN
	SET NOCOUNT ON
	SELECT * FROM dbo.Products P WHERE P.Id = @ID
END