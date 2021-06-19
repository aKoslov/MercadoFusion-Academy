
CREATE   PROCEDURE dbo.NewCategory (
	@Desc nvarchar(50)	)
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO [dbo].[ProductsCategories] (Description) VALUES (@Desc)
END
