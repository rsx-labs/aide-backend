USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_AllGetKPISummary]    Script Date: 9/12/2019 9:03:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllKPISummary'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllKPISummary]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetAllKPISummary]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@FY_START DATE,
	@FY_END DATE
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT A.ID, 
	       A.EMP_ID,
		   A.FY_START,
		   A.FY_END, 
		   A.KPI_REF, 
		   B.SUBJECT, 
		   B.DESCRIPTION, 
		   A.KPI_MONTH,
		   A.KPI_TARGET,
		   A.KPI_ACTUAL,
		   A.KPI_OVERALL,
		   A.DATE_POSTED,
		   case
			when A.KPI_MONTH < 4 then A.KPI_MONTH + 12
			else A.KPI_MONTH
			end as sortOrder
	FROM dbo.[KPI_SUMMARY] A
	INNER JOIN dbo.[KPI_TARGETS] B ON
	A.KPI_REF = B.KPI_REF AND
	A.FY_START = B.FY_START AND
	A.FY_END = B.FY_END
	INNER JOIN dbo.[EMPLOYEE] C ON
	A.EMP_ID = C.EMP_ID
	AND C.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	AND C.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	WHERE A.FY_START = @FY_START AND A.FY_END = @FY_END
	--ORDER BY A.KPI_MONTH, A.KPI_REF ASC
	--ORDER BY A.DATE_POSTED ASC, A.KPI_MONTH
	order by sortOrder ASC
	
END
