USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsHistory]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllLeavesByEmployee]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetAllLeavesByEmployee]
GO

CREATE PROCEDURE [dbo].[sp_GetAllLeavesByEmployee]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@LEAVE_TYPE INT,
	@STATUS_CODE INT
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

;WITH CTEDATES
AS
(
	SELECT ROW_NUMBER() OVER (ORDER BY DATE_ENTRY asc ) AS ROWNUMBER,DATE_ENTRY, COUNTS, STATUS_CD  FROM RESOURCE_PLANNER
	WHERE EMP_ID = @EMP_ID and STATUS = @LEAVE_TYPE and STATUS_CD = @STATUS_CODE and DATE_ENTRY >= CONVERT(DATE, GETDATE())
),
 CTEDATES1
AS
(
   SELECT ROWNUMBER, DATE_ENTRY, 1 as groupid, COUNTS, STATUS_CD FROM CTEDATES WHERE ROWNUMBER=1
   UNION ALL
   SELECT a.ROWNUMBER, a.DATE_ENTRY,case datediff(d, b.DATE_ENTRY,a.DATE_ENTRY) when 1 then b.groupid else b.groupid+1 end as gap, a.COUNTS as COUNTS, a.STATUS_CD as STATUS_CD FROM CTEDATES A INNER JOIN CTEDATES1 B ON A.ROWNUMBER-1 = B.ROWNUMBER
)

select min(DATE_ENTRY) as START_DATE, max(DATE_ENTRY) as END_DATE, SUM(COUNTS) as DURATION, MIN(STATUS_CD) as STATUS_CD 
from CTEDATES1 b 
group by groupid 
order by START_DATE desc	
option (maxrecursion 0)
