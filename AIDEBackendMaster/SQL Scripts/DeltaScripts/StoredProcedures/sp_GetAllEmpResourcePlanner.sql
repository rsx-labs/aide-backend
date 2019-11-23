USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmpResourcePlanner]    Script Date: 11/07/2019 7:27:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllEmpResourcePlanner]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].sp_GetAllEmpResourcePlanner
GO

CREATE PROCEDURE [dbo].[sp_GetAllEmpResourcePlanner]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max),
	@MONTH int,
	@YEAR int
		AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 
   ---FISCAL YEAR STARTS AT APRIL
	IF (@MONTH = 1)			--- January
   begin
       SET @YEAR = @YEAR + 1 
   end
	ELSE IF (@MONTH = 2)	---February
   begin
       SET @YEAR = @YEAR + 1 
   end
	ELSE IF (@MONTH = 3 )	---March
   begin
       SET @YEAR = @YEAR + 1
   end
	ELSE IF (@MONTH = 4)	---April
   begin
        SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 5)	---May
   begin
        SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 6)	---June
   begin
        SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 7)	---July
   begin
         SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 8)	---August
   begin
         SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 9)	---September
   begin
         SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 10)	---October
   begin
         SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 11)	---November
   begin
        SET @YEAR = @YEAR
   end
	ELSE IF (@MONTH = 12)	---December
   begin
        SET @YEAR = @YEAR
   end

    -- Insert statements for procedure here
create table #finalTblResource(DATE_ENTRY DATE, EMP_ID int, EMPLOYEE_NAME NVARCHAR(MAX),  STATUS NVARCHAR(MAX))
create table #SummarizeRecords(DATE_ENTRY DATE, EMP_ID int, EMPLOYEE_NAME NVARCHAR(MAX),  STATUS NVARCHAR(MAX))

DECLARE @TODAYSTAT INT

SELECT @TODAYSTAT = A.STATUS FROM ATTENDANCE A INNER JOIN CONTACTS C ON A.EMP_ID = C.EMP_ID WHERE C.EMAIL_ADDRESS = @EMAIL_ADDRESS AND MONTH(A.DATE_ENTRY) = @MONTH and YEAR(A.DATE_ENTRY) = @YEAR



	BEGIN
		INSERT INTO #finalTblResource
			select DISTINCT a.DATE_ENTRY, c.EMP_ID, c.LAST_NAME + ', ' + c.FIRST_NAME + ' ' + SUBSTRING(c.MIDDLE_NAME,1,1) AS EMPLOYEE_NAME, 
				
				STUFF((SELECT  '/ ' +	case 
											when r.STATUS=1 then 'O'
											when r.STATUS=2 then 'P'
											when r.STATUS=3 then 'SL'
											when r.STATUS=4 then 'VL'
											when r.STATUS=5 then 'HSL'
											when r.STATUS=6 then 'HVL'
											when r.STATUS=7 then 'H'
											when r.STATUS=8 then 'EL'
											when r.STATUS=9 then 'HEL'
											when r.STATUS=10 then 'OL'
											when r.STATUS=11 then 'L'
											when r.STATUS=12 then 'HOL'
											when r.STATUS=13 then 'OBA'
											when r.STATUS=14 then 'HOBA'
											else ''
										END
						FROM ATTENDANCE r 
							INNER JOIN STATUS cd  On (cd.STATUS = r.STATUS) 
							and Cd.STATUS_ID in (6,9,7)
							and r.EMP_ID = c.EMP_ID
							and convert(varchar(20), r.DATE_ENTRY, 111)= convert(varchar(20), a.DATE_ENTRY, 111) 
							order by  R.DATE_ENTRY ASC
							
					
		FOR XML PATH(''),TYPE ).value('.','VARCHAR(MAX)') ,1,2,'') 
		as STATUS
		from ATTENDANCE a 
		inner join EMPLOYEE c 
			on a.EMP_ID = c.EMP_ID
		and c.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
		and c.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS) 
		inner join STATUS ss on a.STATUS = ss.STATUS
		
		where Month(DATE_ENTRY) = @MONTH AND Year(DATE_ENTRY) = @YEAR and c.ACTIVE <> 2
			ORDER BY  c.EMP_ID


	INSERT INTO #SummarizeRecords
		select  DISTINCT convert(varchar(20), ft.DATE_ENTRY, 111), ft.EMP_ID, ft. EMPLOYEE_NAME, ft.STATUS  from  #finalTblResource ft 

	select DISTINCT DATE_ENTRY, *  from #SummarizeRecords sr order by sr.EMP_ID
		END
	END

drop table #SummarizeRecords
drop table #finalTblResource

