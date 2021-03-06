USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBillableHoursByMonth]    Script Date: 01/06/2020 12:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Author:		Batongbacal, Aevan Camille N. / J.H. Sanchez
-- Create date: Aug. 1, 2018
-- Description:	Get Billable hours per Dept and Div
-- ================================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetBillableHoursByMonth'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetBillableHoursByMonth]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetBillableHoursByMonth]
	-- Add the parameters for the stored procedure here
	@EMPID INT,
	@MONTH INT,
	@YEAR INT,
	@WEEKID INT
AS
	
DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID),
		@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	DECLARE @BILLABLES TABLE (NAME VARCHAR(100), TOTAL_HOURS FLOAT, BILL_STATUS SMALLINT)

	DECLARE @fiscalYear VARCHAR(10)
	SET @fiscalYear = CAST(@year AS VARCHAR) + '-' + CAST((@year + 1) AS VARCHAR)

	DECLARE @counter INT = 1
	DECLARE @totalProjects INT = (SELECT COUNT(*) 
								  FROM PROJECT p, EMPLOYEE e
								  WHERE p.EMP_ID = e.EMP_ID 
								  AND e.DEPT_ID = @DEPTID 
								  AND e.DIV_ID = @DIVID
								  AND DSPLY_FLG = 1)

	WHILE (@counter <= @totalProjects)
		BEGIN
			-- Get the project by row number
			DECLARE @projID INT = (SELECT PROJ_ID FROM ( 
										SELECT ROW_NUMBER() OVER (ORDER BY PROJ_ID) As RowNum, p.PROJ_ID 
										FROM PROJECT p, EMPLOYEE e
										WHERE p.EMP_ID = e.EMP_ID 
										AND e.DEPT_ID = @DEPTID 
										AND e.DIV_ID = @DIVID
										AND DSPLY_FLG = 1) Data
								   WHERE RowNum = @counter)
			
			DECLARE @projName VARCHAR(50) = (SELECT PROJ_NAME FROM PROJECT WHERE PROJ_ID = @projID)
			DECLARE @status SMALLINT = (SELECT BILLABILITY FROM PROJECT WHERE PROJ_ID = @projID)

			IF EXISTS (SELECT * FROM PROJECT WHERE PROJ_ID = @projID AND DSPLY_FLG = 1)
				BEGIN
					DECLARE @totalHours FLOAT = (SELECT ISNULL(SUM(WR_ACT_EFFORT_WK), 0) 
										 FROM WEEKLY_REPORT WR
										 LEFT JOIN PROJECT P
											ON WR.WR_PROJ_ID = P.PROJ_ID 
										 LEFT JOIN WEEK_RANGE W
											ON WR.WR_WEEK_RANGE_ID = W.WEEK_ID
										 LEFT JOIN WEEKLY_REPORT_XREF WX
											ON WR.WR_WEEK_RANGE_ID = WX.WEEK_RANGE 
										 LEFT JOIN EMPLOYEE E
											ON WR.WR_EMP_ID = E.EMP_ID
											AND E.EMP_ID = WX.EMP_ID 
										 WHERE E.DEPT_ID = @DEPTID 
										    AND E.DIV_ID = @DIVID
											AND FISCAL_YEAR = @fiscalYear 
											AND MONTH = @MONTH 
											AND WR_WEEK_RANGE_ID <= @WEEKID 
											AND WR_PROJ_ID = @projID
											AND WX.STATUS = 3
											AND WR_DELETE_FG = 0)

					
					IF @totalHours > 0
						INSERT INTO @BILLABLES VALUES (@projName, @totalHours, @status) 
					
				END
			
			SET @counter += 1
		END

	SELECT * FROM @BILLABLES
END
