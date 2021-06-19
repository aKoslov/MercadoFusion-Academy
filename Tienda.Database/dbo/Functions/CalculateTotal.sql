
CREATE   FUNCTION [dbo].[CalculateTotal] (@ID int,@OrderOrCart bit)  
RETURNS decimal(12,2)
AS  
BEGIN  
DECLARE @Return decimal(12,2) 
SET @Return = 0
IF @OrderOrCart = 0
BEGIN
	SET @Return = (SELECT SUM([PTO].[Subtotal]) 
					FROM [dbo].[ProductToOrder] AS PTO 
						WHERE [PTO].[OrderID] = @ID)
END
ELSE
BEGIN 
	SET @Return =(SELECT SUM([PTC].[Subtotal]) 
					FROM [dbo].[ProductToCart] AS PTC
						WHERE [PTC].[CartID] = @ID)
END
RETURN @Return
END
