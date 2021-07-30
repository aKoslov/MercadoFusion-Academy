CREATE       PROCEDURE [dbo].[NewOrder] (
	@userid smallint,
	@billingnumber varchar(100)
		)
AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO dbo.Orders (BillingNumber, UserId) VALUES (@billingnumber, @userid)
	END