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

--DECLARE @count int
--DECLARE @countend int
--DECLARE @STARTDATE nvarchar(10)
--DECLARE @ENDDATE nvarchar(10)

--CREATE TABLE #FiscalYear(SEQ_ID int, FISCAL_YEAR nvarchar(20))

--IF CONVERT(INT, DATENAME(DAYOFYEAR,GETDATE())) <= CONVERT(INT, DATENAME(DAYOFYEAR,CONVERT(NVARCHAR, YEAR(GETDATE())) + '-03-31'))
--	BEGIN
--		SET @count = -2
--		SET @countend = 1
--	END
--ELSE
--	BEGIN
--		SET @count = -1
--		SET @countend = 2
--	END

--WHILE (@count < @countend)
--	BEGIN

--		SET @STARTDATE = YEAR(DATEADD(YEAR, @count ,GETDATE()))
--		SET @ENDDATE = YEAR(DATEADD(YEAR, @count + 1 ,GETDATE()))
--		INSERT INTO #FiscalYear
--		select @count + 1, @STARTDATE + '-' + @ENDDATE

--		SET @count = @count + 1
--	END

--Select FISCAL_YEAR from #FiscalYear

--DROP TABLE #FiscalYear

CREATE TABLE #FISCALTABLE
(
    SEQID INT,
	FY INT,
    FISCAL_YEAR NVARCHAR(20),
)

CREATE TABLE #TEMPTABLE
(
    ROWID INT,
    STARTDATE INT,
	ENDDATE INT
)

INSERT INTO #TEMPTABLE SELECT ROW_NUMBER() OVER(ORDER BY FY_START ASC) AS ROWID, YEAR(FY_START) AS FYSTART, YEAR(FY_END) AS FYEND FROM FISCAL_YEAR ORDER BY FY_START

DECLARE @COUNTER INT = (SELECT COUNT(*) FROM FISCAL_YEAR);
DECLARE @ROW INT = 1;

WHILE (@COUNTER >= @ROW)
BEGIN
	INSERT INTO #FISCALTABLE SELECT ROWID, STARTDATE, CAST(STARTDATE AS NVARCHAR(4)) + '-' + CAST(ENDDATE AS NVARCHAR(4)) AS FISCALYR FROM #TEMPTABLE WHERE ROWID = @ROW
	SET @ROW = @ROW + 1
END

SELECT FISCAL_YEAR FROM #FISCALTABLE WHERE FY <= YEAR(GETDATE()) + 1

DROP TABLE #TEMPTABLE
DROP TABLE #FISCALTABLE

END