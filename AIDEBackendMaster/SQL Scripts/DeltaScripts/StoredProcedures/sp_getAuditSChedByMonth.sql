USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAuditSChedByMonth]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getAuditSChedByMonth'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getAuditSChedByMonth
    END
GO

CREATE PROCEDURE [dbo].[sp_getAuditSChedByMonth]
       -- Add the parameters for the stored procedure here
	@AUDIT_GROUP_ID int,
	@YEAR int,
	@MONTH int
AS
BEGIN
	DECLARE @MONTHTODAY DATETIME = MONTH(GETDATE())

		
	  if @AUDIT_GROUP_ID = 1
		BEGIN
		  SELECT CONCAT(CONVERT(VARCHAR,WAS.PERIOD_START, 107),' - ', CONVERT(VARCHAR,WAS.PERIOD_END,107)) AS AUDITSCHED_MONTH , FY_WEEK FROM WORKPLACE_AUDIT_SCHEDULE WAS WHERE MONTH(WAS.PERIOD_START) = @MONTH and YEAR(WAS.PERIOD_START) = @YEAR
		END 
	ELSE IF @AUDIT_GROUP_ID = 2
		BEGIN
		CREATE TABLE #MONTHS(AUDITSCHED_MONTH nvarchar(20), FY_WEEK int)
		DECLARE @COUNT INT=0

		INSERT INTO #MONTHS
			SELECT 'January', 1
		INSERT INTO #MONTHS
			SELECT 'February', 2
		INSERT INTO #MONTHS
			SELECT 'March', 3
		INSERT INTO #MONTHS
			SELECT 'April', 4
		INSERT INTO #MONTHS
			SELECT 'May', 5
		INSERT INTO #MONTHS
			SELECT 'June', 6
		INSERT INTO #MONTHS
			SELECT 'July', 7
		INSERT INTO #MONTHS
			SELECT 'August', 8
		INSERT INTO #MONTHS
			SELECT 'September', 9
		INSERT INTO #MONTHS
			SELECT 'October', 10
		INSERT INTO #MONTHS
			SELECT 'November', 11
		INSERT INTO #MONTHS
			SELECT 'December', 12
		END
	SELECT * FROM #MONTHS
END

GO
