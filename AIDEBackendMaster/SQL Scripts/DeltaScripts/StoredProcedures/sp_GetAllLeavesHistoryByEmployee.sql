USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsHistory]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllLeavesHistoryByEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetAllLeavesHistoryByEmployee]
GO

CREATE PROCEDURE [dbo].[sp_GetAllLeavesHistoryByEmployee]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@LEAVE_TYPE INT

AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

;WITH CTEDATES
AS
(
	SELECT ROW_NUMBER() OVER (ORDER BY DATE_ENTRY asc ) AS ROWNUMBER,R.DATE_ENTRY, R.COUNTS, R.STATUS_CD, R.STATUS, S.DESCR  FROM RESOURCE_PLANNER R INNER JOIN STATUS S ON 
	R.STATUS = S.STATUS WHERE S.STATUS_ID = 7 and R.EMP_ID = @EMP_ID and R.STATUS in (3,4) and R.DATE_ENTRY < CONVERT(DATE, GETDATE()) 
	or R.STATUS_CD = 0 and S.STATUS_ID = 7 
),
 CTEDATES1
AS
(
   SELECT ROWNUMBER, DATE_ENTRY, 1 as groupid, COUNTS, STATUS_CD, STATUS, DESCR FROM CTEDATES WHERE ROWNUMBER=1
   UNION ALL
   SELECT a.ROWNUMBER, a.DATE_ENTRY,case when datediff(d, b.DATE_ENTRY,a.DATE_ENTRY) = 1 and b.STATUS = a.STATUS  then b.groupid else b.groupid+1 end as gap, a.COUNTS as COUNTS, a.STATUS_CD as STATUS_CD, a.STATUS as STATUS, a.DESCR as DESCR FROM CTEDATES A INNER JOIN CTEDATES1 B ON A.ROWNUMBER-1 = B.ROWNUMBER
)

select min(DATE_ENTRY) as START_DATE, max(DATE_ENTRY) as END_DATE, SUM(COUNTS) as DURATION, MIN(STATUS_CD) as STATUS_CD, MIN(STATUS) as STATUS, MIN(DESCR) as DESCR  
from CTEDATES1 
group by groupid, STATUS_CD
order by START_DATE desc 	
option (maxrecursion 0)

