﻿
---------------------------------------------------------------------------------------------------------
------------------------------------------- SPs para Deletes  -------------------------------------------
---------------------------------------------------------------------------------------------------------
/*******************************************************************************************************/

-------------------------------Stored Procedure para ProductsCategory Delete-----------------------------

CREATE   PROCEDURE dbo.DeleteProductsCategory (
	@CategoryID [tinyint]
		)
AS
BEGIN 
	SET NOCOUNT ON 
	DELETE FROM dbo.[Categories] WHERE Id = @CategoryID
END
