USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMyAssets]    Script Date: 03/05/2020 4:42:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetMyAssets'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetMyAssets]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetMyAssets]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT CONCAT(E.FIRST_NAME, ' ', E.LAST_NAME) AS FULL_NAME, 
			D.DESCR AS DEPARTMENT, 
			I.ASSET_ID,
			I.EMP_ID,
			A.PREVIOUS_ID,
			A.ASSET_DESC, 
			A.MANUFACTURER, 
			A.MODEL_NO, 
			A.SERIAL_NO, 
			A.ASSET_TAG,
			I.DATE_ASSIGNED,
			I.COMMENTS,
			I.STATUS,
			I.APPROVAL
	FROM ASSETS A
	INNER JOIN ASSETS_INVENTORY I
	ON A.ASSET_ID = I.ASSET_ID
	INNER JOIN EMPLOYEE E
	ON I.EMP_ID = E.EMP_ID
	INNER JOIN DEPARTMENT D
	ON E.DEPT_ID = D.DEPT_ID
	WHERE I.EMP_ID = @EMP_ID
	ORDER BY I.STATUS DESC
END 
