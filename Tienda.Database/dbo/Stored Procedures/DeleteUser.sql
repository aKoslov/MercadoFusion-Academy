 
 ------------------ DELETE : borrado de usuario ------------------

CREATE   PROCEDURE DeleteUser (
	@UserID [int]
	)
AS 
BEGIN
	SET NOCOUNT ON
	IF (SELECT UserID FROM Orders WHERE UserID = @UserID GROUP BY UserID) IS NULL
	BEGIN
	DELETE FROM Users WHERE UserID = @UserID
	END
	ELSE
	BEGIN
	RAISERROR( '
	No vamos a borrar tu usuario pero podemos borrar tu data
	',1,1)
	END
END
