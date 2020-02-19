USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllLeavesHistoryByEmployee]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.[sp_GetAllLeavesHistoryByEmployee]'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllLeavesHistoryByEmployee]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllLeavesHistoryByEmployee]
	@EMP_ID INT,
	@LEAVE_TYPE INT
AS
	
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

;WITH CTEDATES
AS
(
	SELECT ROW_NUMBER() OVER (ORDER BY DATE_ENTRY asc ) AS ROWNUMBER, DATE_ENTRY, COUNTS, STATUS_CD, A.STATUS, DESCR  
	FROM ATTENDANCE A INNER JOIN STATUS S 
	ON A.STATUS = S.STATUS 
	WHERE S.STATUS_ID IN (7, 9) 
	AND A.EMP_ID = @EMP_ID 
	AND A.STATUS NOT IN (7, 13, 14) 
	AND (DATE_ENTRY < GETDATE() OR (DATE_ENTRY >= GETDATE() AND STATUS_CD = 0))
),
CTEDATES1
AS
(
	SELECT ROWNUMBER, DATE_ENTRY, 1 as groupid, COUNTS, STATUS_CD, STATUS, DESCR 
	FROM CTEDATES WHERE ROWNUMBER = 1
	UNION ALL
	SELECT a.ROWNUMBER, a.DATE_ENTRY, 
		   CASE WHEN DATEDIFF(d, b.DATE_ENTRY,a.DATE_ENTRY) <= 1 
					 AND b.STATUS = a.STATUS 
				THEN b.groupid 
		   ELSE b.groupid + 1 END AS gap, 
	a.COUNTS AS COUNTS, 
	a.STATUS_CD AS STATUS_CD, 
	a.STATUS AS STATUS, 
	a.DESCR AS DESCR 
	FROM CTEDATES A 
	INNER JOIN CTEDATES1 B ON A.ROWNUMBER - 1 = B.ROWNUMBER
)

	SELECT MIN(DATE_ENTRY) AS START_DATE, 
		   MAX(DATE_ENTRY) AS END_DATE, 
		   SUM(COUNTS) AS DURATION, 
		   MIN(STATUS_CD) AS STATUS_CD, 
		   CONVERT(NVARCHAR(10), MIN(STATUS)) AS 'STATUS', 
		   MIN(DESCR) AS DESCR  
	FROM CTEDATES1 
	GROUP BY groupid, STATUS_CD
	ORDER BY START_DATE DESC 	
	OPTION (maxrecursion 0)

