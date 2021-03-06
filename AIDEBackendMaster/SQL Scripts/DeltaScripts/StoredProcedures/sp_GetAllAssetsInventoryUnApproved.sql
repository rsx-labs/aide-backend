USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsInventoryUnApproved]    Script Date: 12/06/2019 2:10:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllAssetsInventoryUnApproved'))
	DROP PROCEDURE [dbo].[sp_GetAllAssetsInventoryUnApproved]
GO

CREATE PROCEDURE [dbo].[sp_GetAllAssetsInventoryUnApproved]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

DECLARE @guestAccount SMALLINT = 5

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT  I.ASSET_ID,
			I.EMP_ID,
			CONCAT(E.FIRST_NAME, ' ', E.LAST_NAME) AS FULL_NAME, 
			D.DESCR AS DEPARTMENT, 				
			A.PREVIOUS_ID, 
			CONCAT(F.FIRST_NAME, ' ', F.LAST_NAME) AS PREVIOUS_OWNER,
			A.ASSET_DESC, 
			A.MANUFACTURER, 
			A.MODEL_NO, 
			A.SERIAL_NO, 
			A.ASSET_TAG,
			A.DATE_PURCHASED,
			A.OTHER_INFO,
			I.DATE_ASSIGNED,
			I.COMMENTS,
			I.STATUS,
			I.APPROVAL
	FROM ASSETS A
	INNER JOIN ASSETS_INVENTORY I
	ON A.ASSET_ID = I.ASSET_ID
	INNER JOIN STATUS B
	ON A.STATUS = B.STATUS
	INNER JOIN EMPLOYEE E
	ON I.EMP_ID = E.EMP_ID
	INNER JOIN DEPARTMENT D
	ON E.DEPT_ID = D.DEPT_ID
	LEFT JOIN EMPLOYEE F
	ON A.PREVIOUS_ID = F.EMP_ID
	WHERE E.DEPT_ID = @DEPT_ID AND E.DIV_ID = @DIV_ID
	AND e.GRP_ID != @guestAccount 
	AND I.APPROVAL = 6
	AND B.STATUS_ID = 11
	AND B.STATUS IN (3,4) --PARTIALLY ASSIGNED/UNASSIGNED

END
