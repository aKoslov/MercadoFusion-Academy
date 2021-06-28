 
 ------------------ DELETE : borrado de usuario ------------------

CREATE   PROCEDURE DeleteUser (
	@UserID [int]
	)
AS 
BEGIN
	SET NOCOUNT ON
	IF (SELECT U.UserId FROM Orders U WHERE U.UserId = @UserID GROUP BY U.UserId) IS NULL
	BEGIN
	DELETE FROM Users WHERE Id = @UserID
	END
	ELSE
	BEGIN
	RAISERROR( '
	No vamos a borrar tu usuario pero podemos borrar tu data
	',1,1)
	END
END
