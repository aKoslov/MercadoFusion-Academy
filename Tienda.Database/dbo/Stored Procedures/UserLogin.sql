
/*
USE [MercadoFusion]
GO
 Object:  StoredProcedure [dbo].[GetProductByID]    Script Date: 1/6/2021 1:55:42 
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON
GO 
GO

CREATE OR ALTER PROCEDURE [dbo].[UserTryLogin] (
	@username [nvarchar](50)
		)
AS
	BEGIN
	SELECT Salt FROM Users WHERE Username = @username
	END
GO
*/


CREATE PROCEDURE [dbo].[UserLogin]	(
	@username [nvarchar](50),
	@password [nvarchar](300)
		)
AS
	BEGIN
	SET NOCOUNT ON

		
		IF (SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password) > 0
		BEGIN
		SELECT Id, UserType FROM Users WHERE Username = @username AND Password = @password
		END
		ELSE
		BEGIN
		SELECT -1, 3
		END
	END
