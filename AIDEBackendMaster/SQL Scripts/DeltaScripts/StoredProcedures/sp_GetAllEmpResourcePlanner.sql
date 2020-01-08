USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmpResourcePlanner]    Script Date: 01/07/2020 8:46:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllEmpResourcePlanner'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllEmpResourcePlanner]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllEmpResourcePlanner]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max),
	@MONTH int,
	@YEAR int
		AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	---FISCAL YEAR STARTS AT APRIL
	DECLARE @fiscalYear INT
	IF @MONTH < 4
		SET @fiscalYear	= @YEAR + 1
	ELSE
		SET @fiscalYear = @YEAR

	-- Insert statements for procedure here
	CREATE TABLE #finalTblResource(DATE_ENTRY DATE, EMP_ID INT, EMPLOYEE_NAME NVARCHAR(MAX),  STATUS NVARCHAR(MAX))
	CREATE TABLE #SummarizeRecords(DATE_ENTRY DATE, EMP_ID INT, EMPLOYEE_NAME NVARCHAR(MAX),  STATUS NVARCHAR(MAX))

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE E INNER JOIN CONTACTS C ON E.EMP_ID = C.EMP_ID WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS)
	DECLARE @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE E INNER JOIN CONTACTS C ON E.EMP_ID = C.EMP_ID WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS)

	DECLARE @TODAYSTAT INT

	SELECT @TODAYSTAT = A.STATUS 
	FROM ATTENDANCE A 
	INNER JOIN CONTACTS C 
	ON A.EMP_ID = C.EMP_ID 
	WHERE C.EMAIL_ADDRESS = @EMAIL_ADDRESS 
	AND MONTH(A.DATE_ENTRY) = @MONTH 
	AND YEAR(A.DATE_ENTRY) = @fiscalYear

	BEGIN
		INSERT INTO #finalTblResource
		SELECT DISTINCT a.DATE_ENTRY, 
						c.EMP_ID, 
						c.LAST_NAME + ', ' + c.FIRST_NAME + ' ' + SUBSTRING(c.MIDDLE_NAME,1,1) AS EMPLOYEE_NAME, 
						STUFF((SELECT  '/' + CASE 
												WHEN r.STATUS=1 THEN 'O'
												WHEN r.STATUS=2 THEN 'P'
												WHEN r.STATUS=3 THEN 'SL'
												WHEN r.STATUS=4 THEN 'VL'
												WHEN r.STATUS=5 THEN 'HSL'
												WHEN r.STATUS=6 THEN 'HVL'
												WHEN r.STATUS=7 THEN 'H'
												WHEN r.STATUS=8 THEN 'EL'
												WHEN r.STATUS=9 THEN 'HEL'
												WHEN r.STATUS=10 THEN 'OL'
												WHEN r.STATUS=11 THEN 'L'
												WHEN r.STATUS=12 THEN 'HOL'
												WHEN r.STATUS=13 THEN 'OBA'
												WHEN r.STATUS=14 THEN 'HOBA'
											 ELSE ''
											 END
							   FROM ATTENDANCE r 
							   INNER JOIN STATUS cd ON (cd.STATUS = r.STATUS) 
							   AND Cd.STATUS_ID in (6,9,7)
							   AND r.EMP_ID = c.EMP_ID
							   AND CONVERT(VARCHAR(20), r.DATE_ENTRY, 111) = CONVERT(varchar(20), a.DATE_ENTRY, 111) 
							   ORDER BY R.DATE_ENTRY ASC
							   FOR XML PATH(''),TYPE ).value('.','VARCHAR(MAX)') ,1,1,'') AS STATUS
		FROM ATTENDANCE a 
		INNER JOIN EMPLOYEE c 
		ON a.EMP_ID = c.EMP_ID
		AND c.DEPT_ID = @DEPTID
		AND c.DIV_ID = @DIVID 
		INNER JOIN STATUS ss ON a.STATUS = ss.STATUS
		WHERE MONTH(DATE_ENTRY) = @MONTH AND YEAR(DATE_ENTRY) = @fiscalYear and c.ACTIVE <> 2
		ORDER BY  c.EMP_ID

		INSERT INTO #SummarizeRecords
		SELECT DISTINCT CONVERT(VARCHAR(20), ft.DATE_ENTRY, 111), ft.EMP_ID, ft. EMPLOYEE_NAME, ft.STATUS FROM #finalTblResource ft 

		SELECT DISTINCT DATE_ENTRY, * FROM #SummarizeRecords sr ORDER BY sr.EMPLOYEE_NAME ASC
	END
	
	DROP TABLE #SummarizeRecords
	DROP TABLE #finalTblResource
END


