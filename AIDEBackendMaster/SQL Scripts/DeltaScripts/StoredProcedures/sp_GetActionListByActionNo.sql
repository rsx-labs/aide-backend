USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActionListByActionNo]    Script Date: 12/10/2019 11:45:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetActionListByActionNo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetActionListByActionNo]
GO

CREATE PROCEDURE [dbo].[sp_GetActionListByActionNo] 
	@ACT_ID VARCHAR(50),
	@EMP_ID INT
AS

BEGIN
	DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

	SELECT * FROM ACTIONLIST a
	INNER JOIN EMPLOYEE e
	ON a.EMP_ID = e.EMP_ID
	WHERE ACTREF LIKE '%' + @ACT_ID + '%'
	AND DEPT_ID = @DEPT_ID
	AND DIV_ID = @DIV_ID
	ORDER BY A.DATE_CREATED DESC
END
