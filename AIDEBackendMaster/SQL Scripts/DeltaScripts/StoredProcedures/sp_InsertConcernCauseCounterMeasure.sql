USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertConcernCauseCounterMeasure]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertConcernCauseCounterMeasure]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertConcernCauseCounterMeasure]
GO

CREATE PROCEDURE [dbo].[sp_InsertConcernCauseCounterMeasure](
	
	@CONCERN varchar(20) ,
	@CAUSE varchar(max) ,
	@COUNTERMEASURE varchar(max), 	
	@DUE_DATE date,	
	@EMAILADDRESS varchar(max)
)
AS
			
DECLARE 
		@GetDateToday date = CONVERT(datetime , GETDATE(), 101),
		@countPlusOne int,
		@GetDateNow varchar(max),
		@num varchar(max),
		@counts varchar(10)=(SELECT COUNT(DATE_RAISED) FROM [dbo].[Concern_Cause_Countermeasure]),
		@GetEMPID varchar(max) = (SELECT			
						dbo.EMPLOYEE.EMP_ID
					
			    
FROM            dbo.EMPLOYEE INNER JOIN
                         dbo.CONTACTS ON 
						 dbo.EMPLOYEE.EMP_ID = dbo.CONTACTS.EMP_ID 
						

 WHERE dbo.CONTACTS.EMAIL_ADDRESS = @EMAILADDRESS);
		
	SET @countPlusOne = 1 + CONVERT(int, @counts)		
	SET @num = CONVERT(varchar(max), @countPlusOne)
	SET @GetDateNow = CONVERT(VARCHAR(10),GETDATE(),101)
		

BEGIN
if (SELECT COUNT(DATE_RAISED) as Count FROM [dbo].[CONCERN_CAUSE_COUNTERMEASURE]) = 0
	BEGIN	
	INSERT [dbo].[CONCERN_CAUSE_COUNTERMEASURE]
(
	[REF_ID] ,
	[CONCERN],
	[CAUSE] ,
	[COUNTERMEASURE] ,
	[EMP_ID] ,	
	[DUE_DATE] ,
	[STATUS] ,	
	[DATE_RAISED]
)
VALUES
(
	'C'+ '1-' + @GetDateNow,
	@CONCERN,
	@CAUSE ,
	@COUNTERMEASURE , 
	@GetEMPID ,
	@DUE_DATE ,
	1 ,	
	@GetDateToday 

)
	END
ELSE
	BEGIN 
		INSERT [dbo].[CONCERN_CAUSE_COUNTERMEASURE]
(
	[REF_ID] ,
	[CONCERN],
	[CAUSE] ,
	[COUNTERMEASURE] ,
	[EMP_ID] ,	
	[DUE_DATE] ,
	[STATUS] ,	
	[DATE_RAISED]
)
VALUES
(
	'C'+ @num +'-' + @GetDateNow,
	@CONCERN,
	@CAUSE ,
	@COUNTERMEASURE , 
	 @GetEMPID ,	
	@DUE_DATE ,
	1 ,
	@GetDateToday 

)
	END

	END

	
GO
