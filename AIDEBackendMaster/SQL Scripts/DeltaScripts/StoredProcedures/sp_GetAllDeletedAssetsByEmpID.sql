USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDeletedAssetsByEmpID]    Script Date: 11/28/2019 4:47:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllDeletedAssetsByEmpID'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllDeletedAssetsByEmpID]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllDeletedAssetsByEmpID]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT CONCAT(E.FIRST_NAME, ' ', E.LAST_NAME) AS FULL_NAME, 
		   A.EMP_ID,A.ASSET_ID, 
		   A.ASSET_DESC, 
		   A.MANUFACTURER, 
		   A.MODEL_NO, 
		   A.SERIAL_NO, 
		   A.ASSET_TAG, 
		   A.DATE_PURCHASED, 
		   A.STATUS, 
		   A.OTHER_INFO
	FROM [dbo].[ASSETS] A
	INNER JOIN [dbo].[EMPLOYEE] E
	ON A.EMP_ID = E.EMP_ID
	WHERE E.DEPT_ID = @DEPT_ID AND E.DIV_ID = @DIV_ID AND A.STATUS = 5
	ORDER BY A.STATUS ASC
END
