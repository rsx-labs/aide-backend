USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLate]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetLate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetLate]
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetLate]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@MONTH INT,
	@YEAR INT,
	@ToDisplay INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @FIRSTMONTH DATE
	DECLARE @LASTMONTH DATE
	DECLARE @MONTH_NAME VARCHAR(15)
    -- Insert statements for procedure here
	IF @ToDisplay = 1 --VIEW MONTHLY
		BEGIN
			
			IF @MONTH < 4
				SET @YEAR = @YEAR + 1

			SELECT B.FIRST_NAME, COUNT(A.EMP_ID) AS 'STATUS' FROM ATTENDANCE A INNER JOIN EMPLOYEE B
			ON A.EMP_ID = B.EMP_ID
			WHERE A.STATUS = 11 --LATE ID
			AND DATEPART(MONTH, A.DATE_ENTRY) = @MONTH
			AND DATEPART(YEAR, A.DATE_ENTRY) = @YEAR
			AND B.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
			AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
			GROUP BY B.FIRST_NAME
		END
	ELSE -- VIEW FISCAL YEAR
		BEGIN
			
			SET @FIRSTMONTH = CONVERT(DATE, CONVERT(NVARCHAR, @YEAR) + '-04-01')
			SET @LASTMONTH = CONVERT(DATE, CONVERT(NVARCHAR, @YEAR + 1) + '-03-31')
			
			SELECT DATENAME(MONTH,A.DATE_ENTRY) AS 'MONTH', COUNT(A.EMP_ID) AS 'NUMBER_OF_LATE' FROM ATTENDANCE A INNER JOIN EMPLOYEE B
			ON A.EMP_ID = B.EMP_ID
			WHERE A.STATUS = 11 --LATE ID
			AND (A.DATE_ENTRY >= @FIRSTMONTH AND A.DATE_ENTRY < @LASTMONTH)
			AND B.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
			AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
			GROUP BY MONTH(A.DATE_ENTRY), DATENAME(MONTH,A.DATE_ENTRY)
			ORDER BY MONTH(A.DATE_ENTRY)

		END
END

GO
