USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertKPITargets]    Script Date: 9/12/2019 7:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertKPITargets'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_InsertKPITargets]
    END
GO
CREATE PROCEDURE [dbo].[sp_InsertKPITargets]
	-- Add the parameters for the stored procedure here
	@FY_START DATE,
	@FY_END DATE,
	@KPI_REF VARCHAR(20),
	@DESCRIPTION VARCHAR(255),
	@SUBJECT VARCHAR(50),
	@DATE_CREATED DATE
AS
	DECLARE @CUR_FY_START DATE, @CUR_FY_END DATE, @KPI_REF_NO VARCHAR(20), @REF_NO INT
	SET @CUR_FY_START = (SELECT TOP(1) FY_START FROM dbo.KPI_TARGETS WHERE FY_START = @FY_START)
	SET @CUR_FY_END = (SELECT TOP(1) FY_END FROM dbo.KPI_TARGETS WHERE FY_END = @FY_END)
	SET @REF_NO = (SELECT COUNT(*) FROM dbo.KPI_TARGETS WHERE FY_START = @FY_START)
	PRINT @FY_START
	PRINT @FY_END

	IF @CUR_FY_START IS NULL
		BEGIN
			SET @CUR_FY_START = @FY_START
		END
	IF @CUR_FY_END IS NULL
		BEGIN
			SET @CUR_FY_END = @FY_END
		END

	PRINT @CUR_FY_START
	PRINT @CUR_FY_END
	SET @KPI_REF_NO = N'KPI-' + CONVERT(VARCHAR,DATEPART(YEAR,@CUR_FY_START)) + N'-' + RIGHT('00'+CONVERT(VARCHAR,(@REF_NO+1)),2)
	PRINT @KPI_REF_NO
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	INSERT INTO [dbo].[KPI_TARGETS] (FY_START, FY_END, KPI_REF, SUBJECT, DESCRIPTION, DATE_CREATED)
	VALUES (@CUR_FY_START, @CUR_FY_END, @KPI_REF_NO, @SUBJECT, @DESCRIPTION, @DATE_CREATED )
END
