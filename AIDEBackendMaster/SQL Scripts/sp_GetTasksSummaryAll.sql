USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTasksSummaryAll]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetTasksSummaryAll]

@DATENOW DATE,
@EMAIL_ADDRESS VARCHAR(MAX)
 AS
 BEGIN

DECLARE @EMPID INT
DECLARE @DAY1 DATE
DECLARE @DAY2 DATE
DECLARE @DAY3 DATE
DECLARE @DAY4 DATE
DECLARE @DAY5 DATE

DECLARE @OutstandingMON INT
DECLARE @OutstandingTUE INT
DECLARE @OutstandingWED INT
DECLARE @OutstandingTHU INT
DECLARE @OutstandingFRI INT

DECLARE @PrevOutstanding INT

IF ((DATENAME(dw,@DATENOW)) ='Monday') BEGIN
SET @DAY1 = @DATENOW; END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Tuesday') BEGIN
SET @DAY1 = DATEADD(day,-1,@DATENOW); END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Wednesday') BEGIN
SET @DAY1 = DATEADD(day,-2,@DATENOW); END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Thursday')  BEGIN
SET @DAY1 = DATEADD(day,-3,@DATENOW); END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Friday') BEGIN
SET @DAY1 = DATEADD(day,-4,@DATENOW); END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Saturday') BEGIN
SET @DAY1 = DATEADD(day,2,@DATENOW); END

ELSE IF ((DATENAME(dw,@DATENOW)) ='Sunday') BEGIN
SET @DAY1 = DATEADD(day,3,@DATENOW); END
SET @DAY2 = DATEADD(day,1,@DAY1)
SET @DAY3 = DATEADD(day,1,@DAY2)
SET @DAY4 = DATEADD(day,1,@DAY3)
SET @DAY5 = DATEADD(day,1,@DAY4)

DECLARE @temptable TABLE (EmployeeName NVARCHAR(MAX), LastWeekOutstanding int, Mon_AT int, Mon_CT int, Mon_OT int, Tue_AT int,Tue_CT int, Tue_OT int, Wed_AT int, Wed_CT int, Wed_OT int, Thu_AT int, Thu_CT int, Thu_OT int, Fri_AT int, Fri_CT int, Fri_OT int)
DECLARE @counter INT = 1

WHILE (@counter <= (SELECT COUNT(EMP_ID) FROM EMPLOYEE))
BEGIN
	-- Selecting employee ID
	SET @EMPID = (SELECT EMP_ID FROM (SELECT ROW_NUMBER() OVER (ORDER BY EMP_ID ASC) AS rownumber, EMP_ID FROM EMPLOYEE
	WHERE DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
	ON A.EMP_ID = B.EMP_ID
	WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	AND DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
	ON A.EMP_ID = B.EMP_ID
	WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS))  as temptablename WHERE rownumber = @counter)

	-- Calculation of task summary before this week
	-- Number of assigned task before this week
	--SET @PrevOutstanding = (SELECT COUNT(TASK_ID) FROM TASKS 
	--						WHERE COMPLTD_DATE is NULL 
	--						AND EMP_ID = @EMPID 
	--						AND DATEPART(wk, DATE_STARTED) < DATEPART(wk, GETDATE())
	--						AND DATEPART(yy, DATE_STARTED) = DATEPART(yy, GETDATE()))

	SET @PrevOutstanding = ((SELECT COUNT(DATE_CREATED) FROM TASKS WHERE DATE_CREATED <= (DATEADD(day, -7, @DAY5)) AND EMP_ID = @EMPID) - 
	-- Number of completed task before this week
							(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE <= (DATEADD(day, -7, @DAY5)) AND EMP_ID = @EMPID))

	-- Calculations for outstanding task daily
	SET @OutstandingMON = ((SELECT COUNT (DATE_CREATED) FROM TASKS WHERE DATE_CREATED = @DAY1 AND EMP_ID = @EMPID) + (@PrevOutstanding)) - 
						   (SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY1 AND EMP_ID = @EMPID)
	SET @OutstandingTUE = ((SELECT COUNT (DATE_CREATED) FROM TASKS WHERE DATE_CREATED = @DAY2 AND EMP_ID = @EMPID) + (@OutstandingMON)) - 
						   (SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY2 AND EMP_ID = @EMPID)
	SET @OutstandingWED = ((SELECT COUNT (DATE_CREATED) FROM TASKS WHERE DATE_CREATED = @DAY3 AND EMP_ID = @EMPID) + (@OutstandingTUE)) - 
						   (SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY3 AND EMP_ID = @EMPID)
	SET @OutstandingTHU = ((SELECT COUNT (DATE_CREATED) FROM TASKS WHERE DATE_CREATED = @DAY4 AND EMP_ID = @EMPID) + (@OutstandingWED)) - 
						   (SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY4 AND EMP_ID = @EMPID)
	SET @OutstandingFRI = ((SELECT COUNT (DATE_CREATED) FROM TASKS WHERE DATE_CREATED = @DAY5 AND EMP_ID = @EMPID) + (@OutstandingTHU)) - 
						   (SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY5 AND EMP_ID = @EMPID)
 
	-- Columns insert into temporary table
	INSERT INTO @temptable
	-- For name
	SELECT RTrim(Coalesce(LAST_NAME + ' ', '') + Coalesce(FIRST_NAME + ' ','')) AS Name,
	@PrevOutstanding AS 'Last Week Outstanding',

	-- For Monday
	(SELECT COUNT(DATE_CREATED) FROM TASKS WHERE (DATE_CREATED = @DAY1) AND EMP_ID = @EMPID) AS 'Mon(AT)',
	(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY1 AND EMP_ID = @EMPID) AS 'Mon(CT)',
	@OutstandingMON AS 'Mon(OT)',

	-- For Tuesday
	(SELECT COUNT(DATE_CREATED) FROM TASKS WHERE (DATE_CREATED = @DAY2) AND EMP_ID = @EMPID) AS 'Tue(AT)',
	(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY2 AND EMP_ID = @EMPID) AS 'Tue(CT)',
	@OutstandingTUE AS 'Tue(OT)',

	-- For Wednesday
	(SELECT COUNT(DATE_CREATED) FROM TASKS WHERE (DATE_CREATED = @DAY3) AND EMP_ID = @EMPID) AS 'Wed(AT)',
	(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY3 AND EMP_ID = @EMPID) AS 'Wed(CT)',
	@OutstandingWED AS 'Wed(OT)',

	-- For Thursday
	(SELECT COUNT(DATE_CREATED) FROM TASKS WHERE (DATE_CREATED = @DAY4) AND EMP_ID = @EMPID) AS 'Thu(AT)',
	(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY4 AND EMP_ID = @EMPID) AS 'Thu(CT)',
	@OutstandingTHU AS 'Thu(OT)',

	-- For Friday
	(SELECT COUNT(DATE_CREATED) FROM TASKS WHERE (DATE_CREATED = @DAY5) AND EMP_ID = @EMPID) AS 'Fri(AT)',
	(SELECT COUNT(COMPLTD_DATE) FROM TASKS WHERE COMPLTD_DATE = @DAY5 AND EMP_ID = @EMPID) AS 'Fri(CT)',
	@OutstandingFRI  AS 'Fri(OT)'

	FROM EMPLOYEE  
	WHERE EMP_ID = @EMPID 

	SET @counter = @counter + 1
END

SELECT * FROM @temptable
ORDER BY EmployeeName
END
 



GO
