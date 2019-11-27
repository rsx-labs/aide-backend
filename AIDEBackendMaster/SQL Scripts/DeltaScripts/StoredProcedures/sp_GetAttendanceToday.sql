USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttendanceToday]    Script Date: 11/27/2019 11:42:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAttendanceToday]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetAttendanceToday]
GO

CREATE PROCEDURE [dbo].[sp_GetAttendanceToday]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @ATTENDANCE_TODAY TABLE (EMP_ID INT,
								     EMPLOYEE_NAME VARCHAR(50),
								     DESCR VARCHAR(50),
								     DATE_ENTRY DATETIME,
								     STATUS INT,
								     IMAGE_PATH VARCHAR(MAX),
									 DSPLY_ORDR INT)
	DECLARE @DEPT_ID INT = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
							ON A.EMP_ID = B.EMP_ID
							WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	DECLARE @DIV_ID INT = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						   ON A.EMP_ID = B.EMP_ID
						   WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	DECLARE @DSPLY_ORDR INT
	DECLARE @counter INT = 1
	DECLARE @totalEmployees INT = (SELECT COUNT(A.EMP_ID) FROM ATTENDANCE A INNER JOIN EMPLOYEE B
								   ON A.EMP_ID = B.EMP_ID
								   WHERE CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
								   AND B.DEPT_ID = @DEPT_ID
								   AND B.DIV_ID = @DIV_ID)

	DECLARE @DT_TIME_TODAY TIME = '14:00:00'
	declare @startdate_today time
	declare @enddate_today time

	if @DT_TIME_TODAY between '00:00:00' and '13:59:59'
		begin
			set @startdate_today = '00:00:00'
			set @enddate_today = '13:59:59'
		end
	else
		begin
			set @startdate_today = '14:00:00'
			set @enddate_today = '23:59:59'
		end 

	WHILE (@counter <= @totalEmployees)
		BEGIN
		---date flag 1-morning 2-afternoon
			INSERT INTO @ATTENDANCE_TODAY (EMP_ID, EMPLOYEE_NAME, DESCR, DATE_ENTRY, STATUS, IMAGE_PATH, DSPLY_ORDR)
				select DISTINCT B.EMP_ID, B.LAST_NAME + ', ' + B.FIRST_NAME + ' ' + SUBSTRING(B.MIDDLE_NAME,1,1) + '' AS EMPLOYEE_NAME, 
						D.DESCR, 
						a.DATE_ENTRY,
						a.STATUS, 
						B.IMAGE_PATH, 
						case when  A.STATUS = 2 OR A.STATUS = 11 OR A.STATUS = 7 THEN  1  
							 WHEN  A.STATUS = 1 OR A.STATUS = 13 OR A.STATUS = 14 THEN 2
							 WHEN  A.STATUS = 4 OR A.STATUS = 6 OR A.STATUS = 8 OR A.STATUS = 9 OR A.STATUS = 10 OR A.STATUS = 12 THEN 3
							 WHEN  A.STATUS = 3 OR A.STATUS = 5 OR A.STATUS = 13 OR A.STATUS = 14 THEN 4	 
						else
						 5
						end  as DSPLAY_ORDER
					

				from ATTENDANCE a 
				inner join EMPLOYEE b on a.EMP_ID = b.EMP_ID
				INNER JOIN DIVISION D ON B.DIV_ID = D.DIV_ID
				where CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
				AND B.DEPT_ID = b.DEPT_ID
				AND B.DIV_ID = d.DIV_ID
				AND A.EMP_ID = b.EMP_ID
				ORDER BY B.EMP_ID
						
		SET @counter += 1
		END
	

create table #summaryTbl (EMP_ID int, EMPLOYEE_NAME nvarchar(50), DESCR nvarchar(50), DATE_ENTRY datetime, STATUS int, IMAGE_PATH nvarchar(100), DSPLY_ORDR int)
create table #summaryTbl2 (EMP_ID int, EMPLOYEE_NAME nvarchar(50), DESCR nvarchar(50), DATE_ENTRY datetime, STATUS int, IMAGE_PATH nvarchar(100), DSPLY_ORDR int)




 INSERT INTO #summaryTbl 
	SELECT DISTINCT EMP_ID, EMPLOYEE_NAME, DESCR, DATE_ENTRY, STATUS, IMAGE_PATH,DSPLY_ORDR FROM @ATTENDANCE_TODAY order by DSPLY_ORDR ASC

	if @DT_TIME_TODAY between  '00:00:00' and '13:59:59' 
			begin
			insert into #summaryTbl2
				select distinct at.emp_id, at.EMPLOYEE_NAME,at.DESCR,
						case when  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select DATE_ENTRY from #summaryTbl where convert(time, date_entry) between  @startdate_today and @enddate_today and EMP_ID = at.EMP_ID)
							else
							at.DATE_ENTRY
						end  as DATE_ENTRY,
						CASE WHEN  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select st.STATUS from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between '00:00:00' and '13:59:59' and st.EMP_ID = at.EMP_ID) 
								ELSE
								 (select STATUS from #summaryTbl where  CONVERT(VARCHAR(10),DATE_ENTRY, 108)  between '00:00:00' and '13:59:59' and EMP_ID = at.EMP_ID )	
						END  as STATUS,
							at.IMAGE_PATH,
							CASE WHEN  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select st.DSPLY_ORDR from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between '00:00:00' and '13:59:59' and st.EMP_ID = at.EMP_ID) 
								ELSE
									 (select DSPLY_ORDR from #summaryTbl where  CONVERT(VARCHAR(10),DATE_ENTRY, 108)  between '00:00:00' and '13:59:59' and EMP_ID = at.EMP_ID )							
							END  as DSPLY_ORDR																
	FROM #summaryTbl at inner join ATTENDANCE a  on AT.EMP_ID = A.EMP_ID 
	order by at.EMPLOYEE_NAME ASC

			end
		else
			begin
			insert into #summaryTbl2
			select distinct at.emp_id, at.EMPLOYEE_NAME,at.DESCR,
						case when  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select DATE_ENTRY from #summaryTbl where convert(time, date_entry) between  @startdate_today and @enddate_today and EMP_ID = at.EMP_ID)
							else
							at.DATE_ENTRY
						end  as DATE_ENTRY,
						CASE	WHEN	EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select st.STATUS from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between  '14:00:00' and '23:59:59' and st.EMP_ID = at.EMP_ID) 
								WHEN	EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID AND CONVERT(VARCHAR(10), AA.DATE_ENTRY, 108)  BETWEEN '14:00:00' and '23:59:59'  GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) = 1 ) THEN  (select st.STATUS from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between  '14:00:00' and '23:59:59' and st.EMP_ID = at.EMP_ID)
								ELSE
								 (select STATUS from #summaryTbl where  CONVERT(VARCHAR(10),DATE_ENTRY, 108)   between '00:00:00' and '13:59:59' and EMP_ID = at.EMP_ID )	
						END  as STATUS,
							at.IMAGE_PATH,
							CASE	WHEN  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) > 1 ) THEN  (select st.DSPLY_ORDR from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between '14:00:00' and '23:59:59' and st.EMP_ID = at.EMP_ID) 
									WHEN  EXISTS (SELECT EMP_ID FROM #summaryTbl AA WHERE AA.EMP_ID = AT.EMP_ID AND CONVERT(VARCHAR(10), AA.DATE_ENTRY, 108)  BETWEEN '14:00:00' and '23:59:59' GROUP BY AA.EMP_ID, AA.EMPLOYEE_NAME HAVING COUNT(AA.EMP_ID) = 1 ) THEN  (select st.DSPLY_ORDR from #summaryTbl st where  CONVERT(VARCHAR(10), st.DATE_ENTRY, 108)  between '14:00:00' and '23:59:59' and st.EMP_ID = at.EMP_ID) 
								ELSE
									 (select DSPLY_ORDR from #summaryTbl where  CONVERT(VARCHAR(10),DATE_ENTRY, 108)   between '00:00:00' and '13:59:59' and EMP_ID = at.EMP_ID )							
							END  as DSPLY_ORDR																
	FROM #summaryTbl at inner join ATTENDANCE a  on AT.EMP_ID = A.EMP_ID 
	order by at.EMPLOYEE_NAME ASC
			end




select * from #summaryTbl2 order by DSPLY_ORDR , EMPLOYEE_NAME asc


END

