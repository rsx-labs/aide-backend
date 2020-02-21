USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsHistory]    Script Date: 12/10/2019 1:34:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllAssetsHistory'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllAssetsHistory]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllAssetsHistory]
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
	SELECT H.ASSET_ID,
		   CONCAT(E.FIRST_NAME, ' ', E.LAST_NAME) AS FULL_NAME,
		   A.ASSET_DESC,
		   A.MANUFACTURER,
		   A.MODEL_NO,
		   A.SERIAL_NO,
		   A.ASSET_TAG,
		   S.DESCR AS STATUS_DESCR,
		   H.DATE_ASSIGNED
	FROM ASSETS_HISTORY H
	INNER JOIN EMPLOYEE E
	ON E.EMP_ID = H.EMP_ID 
	INNER JOIN STATUS S
	ON H.STATUS = S.STATUS
	INNER JOIN ASSETS A
	ON A.ASSET_ID = H.ASSET_ID
	WHERE S.STATUS_ID = 11
	AND E.DEPT_ID = @DEPT_ID
	AND E.DIV_ID = @DIV_ID
	ORDER BY H.DATE_ASSIGNED DESC
	
END 