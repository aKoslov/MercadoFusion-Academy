
CREATE   PROCEDURE dbo.NewCategory (
	@Desc nvarchar(50)	)
AS
BEGIN
	SET NOCOUNT ON
    INSERT INTO [dbo].[Categories] (Description) VALUES (@Desc)
END
