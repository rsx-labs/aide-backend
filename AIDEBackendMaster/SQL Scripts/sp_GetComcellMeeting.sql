USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetComcellMeeting]    Script Date: 01/03/2020 3:26:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetComcellMeeting'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetComcellMeeting]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetComcellMeeting]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@YEAR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	DECLARE @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	DECLARE @FIRSTMONTH DATE, @LASTMONTH DATE

	-- Set Current Fiscal Year
	--SET @FIRSTMONTH = CAST('4/1/' + Cast(@YEAR as varchar) AS DATE)
	--SET @LASTMONTH = CAST('3/31/' + Cast(@YEAR + 1 as varchar) AS DATE)

	SET @FIRSTMONTH = (SELECT FY_START FROM FISCAL_YEAR WHERE YEAR(FY_START) = @YEAR)
	SET @LASTMONTH = (SELECT FY_END FROM FISCAL_YEAR WHERE YEAR(FY_START) = @YEAR)
	
    -- Insert statements for procedure here
	SELECT (SELECT FIRST_NAME FROM EMPLOYEE WHERE EMP_ID = A.FACILITATOR) AS FAC_NAME, (SELECT FIRST_NAME FROM EMPLOYEE WHERE EMP_ID = A.MINUTES_TAKER) AS MIN_NAME, A.*  FROM COMCELL_MEETING A INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE B.DEPT_ID = @DEPTID AND B.DIV_ID = @DIVID AND A.FY_START BETWEEN @FIRSTMONTH AND @LASTMONTH
	ORDER BY DSPLY_ORDR ASC
END

