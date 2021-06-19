------------------------------------Stored Procedure para Cart Insert------------------------------------

CREATE   PROCEDURE dbo.NewCart (
	@UserID [int]	)
AS
BEGIN
SET NOCOUNT ON;
    INSERT INTO [dbo].[Carts] (UserID) VALUES (@UserID)
END
