USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetKPITargetByFiscalYear]    Script Date: 9/12/2019 9:03:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetKPITargetByFiscalYear'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetKPITargetByFiscalYear]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetKPITargetByFiscalYear]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@FYEAR DATE
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT A.ID, 
	       A.EMP_ID,
		   A.FY_START,
		   A.FY_END, 
		   A.KPI_REF, 
		   A.SUBJECT, 
		   A.DESCRIPTION, 
		   A.DATE_CREATED 
	FROM dbo.[KPI_TARGETS]  A INNER JOIN EMPLOYEE B
	ON  A.EMP_ID = B.EMP_ID
	AND B.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	WHERE @FYEAR BETWEEN A.FY_START AND A.FY_END
	ORDER BY ID ASC
END
