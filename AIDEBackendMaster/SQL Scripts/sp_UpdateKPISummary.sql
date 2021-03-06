USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateKPISummary]    Script Date: 9/12/2019 9:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateKPISummary'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateKPISummary]
    END
GO
CREATE PROCEDURE [dbo].[sp_UpdateKPISummary]
	@EMP_ID INT,
	@KPI_REF VARCHAR(20),
	@KPI_MONTH smallint, 
	@KPI_FY_START date,
	@KPI_FY_END date,
	@KPI_TARGET float,
	@KPI_ACTUAL float,
	@KPI_OVERALL float,
	@DATE_POSTED datetime
AS

BEGIN
	UPDATE KPI_SUMMARY
	SET 
	KPI_TARGET = @KPI_TARGET, 
	KPI_ACTUAL = @KPI_ACTUAL,
	KPI_OVERALL = @KPI_OVERALL,
	DATE_POSTED = @DATE_POSTED
	WHERE 
	EMP_ID = @EMP_ID AND
	KPI_REF = @KPI_REF AND
	KPI_MONTH = @KPI_MONTH AND
	FY_START = @KPI_FY_START AND
	FY_END = @KPI_FY_END
END 

