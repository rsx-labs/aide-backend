USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetKPITargetByFiscalYear]    Script Date: 9/12/2019 9:03:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetKPITargetByFiscalYear'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetKPITargetByFiscalYear]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetKPITargetByFiscalYear]
	-- Add the parameters for the stored procedure here
	@FYEAR DATE
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT ID, 
		   FY_START,
		   FY_END, 
		   KPI_REF, 
		   SUBJECT, 
		   DESCRIPTION, 
		   DATE_CREATED 
	FROM dbo.[KPI_TARGETS] 
	WHERE (@FYEAR >= FY_START AND @FYEAR <= FY_END)
	ORDER BY ID ASC
END
