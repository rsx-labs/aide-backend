USE AIDE

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetFiscalYear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetFiscalYear]
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetFiscalYear]
	-- Add the parameters for the stored procedure here
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

DECLARE @count int
DECLARE @countend int
DECLARE @STARTDATE nvarchar(10)
DECLARE @ENDDATE nvarchar(10)

CREATE TABLE #FiscalYear(SEQ_ID int, FISCAL_YEAR nvarchar(20))

IF CONVERT(INT, DATENAME(DAYOFYEAR,GETDATE())) <= CONVERT(INT, DATENAME(DAYOFYEAR,CONVERT(NVARCHAR, YEAR(GETDATE())) + '-03-31'))
	BEGIN
		SET @count = -2
		SET @countend = 1
	END
ELSE
	BEGIN
		SET @count = -1
		SET @countend = 2
	END

WHILE (@count < @countend)
	BEGIN

		SET @STARTDATE = YEAR(DATEADD(YEAR, @count ,GETDATE()))
		SET @ENDDATE = YEAR(DATEADD(YEAR, @count + 1 ,GETDATE()))
		INSERT INTO #FiscalYear
		select @count + 1, @STARTDATE + '-' + @ENDDATE

		SET @count = @count + 1
	END

Select FISCAL_YEAR from #FiscalYear

DROP TABLE #FiscalYear

END