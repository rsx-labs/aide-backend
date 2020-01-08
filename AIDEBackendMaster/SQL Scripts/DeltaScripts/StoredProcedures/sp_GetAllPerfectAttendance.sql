USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPerfectAttendance]    Script Date: 01/06/2020 1:02:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllPerfectAttendance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetAllPerfectAttendance]
GO

CREATE PROCEDURE [dbo].[sp_GetAllPerfectAttendance]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max),
	@MONTH int,
	@YEAR int

AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	CREATE TABLE #TempTable(
	EMP_ID int)

	INSERT INTO #TempTable
		SELECT DISTINCT (A.EMP_ID) FROM ATTENDANCE A
		INNER JOIN EMPLOYEE B
		ON A.EMP_ID = B.EMP_ID
		WHERE Month(A.DATE_ENTRY) = @MONTH AND Year(A.DATE_ENTRY) = @YEAR AND A.STATUS IN (3,4,5,6,8,9,10,11,12) AND B.ACTIVE = 1
		and B.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID
						WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
		and B.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID
						WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)

	SELECT A.EMP_ID FROM ATTENDANCE A
	INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE A.EMP_ID NOT IN (SELECT * FROM #TempTable)
	AND Month(A.DATE_ENTRY) = @MONTH AND Year(A.DATE_ENTRY) = @YEAR AND B.ACTIVE = 1
	AND B.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID
						WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	AND B.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						ON A.EMP_ID = B.EMP_ID
						WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	GROUP BY A.EMP_ID,B.LAST_NAME
	ORDER BY B.LAST_NAME

	DROP TABLE #TempTable
END


