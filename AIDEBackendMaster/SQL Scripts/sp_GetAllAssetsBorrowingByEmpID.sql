USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsBorrowingByEmpID]    Script Date: 2/07/2020 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllAssetsBorrowingByEmpID'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllAssetsBorrowingByEmpID]
    END
GO


CREATE PROCEDURE [dbo].[sp_GetAllAssetsBorrowingByEmpID]
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
			D.DESCR AS DEPARTMENT, 
			I.ASSET_ID,
			I.EMP_ID,
			A.PREVIOUS_ID,
			CONCAT(F.FIRST_NAME, ' ', F.LAST_NAME) AS PREVIOUS_OWNER,
			A.ASSET_DESC, 
			A.OTHER_INFO,
			A.MANUFACTURER, 
			A.MODEL_NO, 
			A.SERIAL_NO, 
			A.ASSET_TAG,
			A.DATE_PURCHASED,
			I.DATE_ASSIGNED,
			I.COMMENTS,
			I.APPROVAL,
			I.STATUS
	FROM ASSETS A
	INNER JOIN ASSETS_INVENTORY I
	ON A.ASSET_ID = I.ASSET_ID
	INNER JOIN EMPLOYEE E
	ON I.EMP_ID = E.EMP_ID --AND A.PREVIOUS_ID = E.EMP_ID
	INNER JOIN DEPARTMENT D
	ON E.DEPT_ID = D.DEPT_ID
	LEFT JOIN EMPLOYEE F
	ON A.PREVIOUS_ID = F.EMP_ID
	WHERE E.DEPT_ID = @DEPT_ID AND E.DIV_ID = @DIV_ID AND A.BORROW_FG = 1 AND A.BORROW_STATUS <> 1
END



GO


