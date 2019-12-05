USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSabaXref]    Script Date: 11/28/2019 10:36:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetAllSabaXref]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetAllSabaXref]
GO

CREATE PROCEDURE [dbo].[sp_GetAllSabaXref]
	@EMP_ID int,
	@SABA_ID int
AS

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

	BEGIN			
		SELECT  a.SABA_ID as SABA_ID, 
				a.EMP_ID AS EMP_ID, 
				a.DATE_COMPLETED as DATE_COMPLETED, 
				b.FIRST_NAME + ' ' + b.LAST_NAME as IMAGE_PATH 
		FROM [dbo].[SABA_XREF] a INNER JOIN EMPLOYEE B
		ON A.EMP_ID = B.EMP_ID
		WHERE B.DEPT_ID = @DEPTID 
		AND B.DIV_ID = @DIVID 
		AND a.SABA_ID = @SABA_ID
		AND B.ACTIVE = 1
	END