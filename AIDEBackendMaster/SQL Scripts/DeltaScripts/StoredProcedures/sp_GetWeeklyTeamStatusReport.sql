USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeeklyteamStatusReport]    Script Date: 09/30/2019 8:54:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetWeeklyteamStatusReport'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetWeeklyTeamStatusReport]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetWeeklyTeamStatusReport]
	@EMP_ID INT,
	@MONTH INT,
	@YEAR INT,
	@WEEKID INT,
	@ENTRYTYPE INT

AS
BEGIN
	
	DECLARE @STATUS_REPORT TABLE (WeekRangeID INT, 
								  EmployeeID INT, 
								  EmployeeName VARCHAR(MAX), 
								  TotalHours FLOAT, 
								  Status SMALLINT, 
								  Date_Submitted DATE)

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

	DECLARE @counter INT = 1
	DECLARE @totalEmployees INT
	DECLARE @employeeID INT

	IF @ENTRYTYPE = 0
		BEGIN
			SET @totalEmployees = (SELECT COUNT(*) 
								  FROM EMPLOYEE e
								  WHERE e.DEPT_ID = @DEPTID 
								  AND e.DIV_ID = @DIVID)

			WHILE (@counter <= @totalEmployees)
				BEGIN
					-- Get the employee by row number
					SET @employeeID = (SELECT EMP_ID FROM ( 
											SELECT ROW_NUMBER() OVER (ORDER BY LAST_NAME) As RowNum, EMP_ID
											FROM EMPLOYEE e
											WHERE e.DEPT_ID = @DEPTID 
											AND e.DIV_ID = @DIVID) Data
									   WHERE RowNum = @counter)
					-- Get total hours 
					DECLARE @totalHours FLOAT = (SELECT COALESCE(SUM(WR_ACT_EFFORT_WK), 0) FROM WEEKLY_REPORT
										WHERE WR_EMP_ID = @employeeID
										AND WR_WEEK_RANGE_ID = @WEEKID)

					INSERT INTO @STATUS_REPORT (WeekRangeID, EmployeeID, EmployeeName, TotalHours, Status, Date_Submitted)
					SELECT @WEEKID, e.EMP_ID, LAST_NAME + ', ' + FIRST_NAME, @totalHours, w.STATUS, w.DATE_SUBMITTED 
					FROM EMPLOYEE e 
					INNER JOIN WEEKLY_REPORT_XREF w 
						ON e.EMP_ID = w.EMP_ID
					WHERE e.EMP_ID = @employeeID 
					AND w.WEEK_RANGE = @WEEKID
			
					SET @counter += 1
				END
		END
	ELSE
		BEGIN
			SET @totalEmployees = (SELECT COUNT(*) 
								  FROM EMPLOYEE e
								  INNER JOIN ASSIGNED_PROJECTS a
									ON e.EMP_ID = a.EMP_ID
								  WHERE e.DEPT_ID = @DEPTID 
								  AND e.DIV_ID = @DIVID
								  AND e.EMP_ID in (SELECT DISTINCT(EMP_ID) FROM ASSIGNED_PROJECTS 
												   WHERE PROJ_ID IN (SELECT DISTINCT(PROJ_ID) 
																	 FROM ASSIGNED_PROJECTS 
																	 WHERE EMP_ID = @EMP_ID)))

			WHILE (@counter <= @totalEmployees)
				BEGIN
					-- Get the employee by row number
					SET @employeeID = (SELECT EMP_ID FROM ( 
											SELECT ROW_NUMBER() OVER (ORDER BY LAST_NAME) As RowNum, e.EMP_ID
											FROM EMPLOYEE e
											INNER JOIN ASSIGNED_PROJECTS a
												ON e.EMP_ID = a.EMP_ID
											WHERE e.DEPT_ID = @DEPTID 
											AND e.DIV_ID = @DIVID
											AND e.EMP_ID in (SELECT DISTINCT(EMP_ID) FROM ASSIGNED_PROJECTS 
												   WHERE PROJ_ID IN (SELECT DISTINCT(PROJ_ID) 
																	 FROM ASSIGNED_PROJECTS 
																	 WHERE EMP_ID = @EMP_ID))) Data
									   WHERE RowNum = @counter)
					-- Get total hours 
					SET @totalHours = (SELECT COALESCE(SUM(WR_ACT_EFFORT_WK), 0) FROM WEEKLY_REPORT
										WHERE WR_EMP_ID = @employeeID
										AND WR_WEEK_RANGE_ID = @WEEKID)

					INSERT INTO @STATUS_REPORT (WeekRangeID, EmployeeID, EmployeeName, TotalHours, Status, Date_Submitted)
					SELECT @WEEKID, e.EMP_ID, LAST_NAME + ', ' + FIRST_NAME, @totalHours, w.STATUS, w.DATE_SUBMITTED 
					FROM EMPLOYEE e 
					INNER JOIN WEEKLY_REPORT_XREF w 
						ON e.EMP_ID = w.EMP_ID
					WHERE e.EMP_ID = @employeeID 
					AND w.WEEK_RANGE = @WEEKID
			
					SET @counter += 1
				END
		END
	
	SELECT * FROM @STATUS_REPORT
END
 


