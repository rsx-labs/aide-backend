USE [AIDE]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_GetContactListAll]
		@EMPID = 220002229,
		@SELECTION = 0

SELECT	'Return Value' = @return_value

GO
