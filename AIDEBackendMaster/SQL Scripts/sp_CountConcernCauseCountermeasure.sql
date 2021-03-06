USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_CountConcernCauseCountermeasure]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CountConcernCauseCountermeasure](
	@REF_ID int ,
	@CONCERN varchar(20) ,
	@CAUSE varchar(max) ,
	@COUNTERMEASURE varchar(max), 
	@EMP_ID varchar(20) ,
	@ACT_REFERENCE varchar(max),
	@DUE_DATE date,
	@STATUS varchar(10),
	@DATE_CLOSED date,
	@DATE_RAISED date
)
AS
			
DECLARE @ttd int = 1,
		@countPlusOne int,
		@GetDateNow varchar(max),
		@num varchar(max),
		@counts varchar(10)=(SELECT COUNT(DATE_RAISED) FROM [dbo].[Concern_Cause_Countermeasure]);
		
	SET @countPlusOne = 1 + CONVERT(int, @counts)		
	SET @num = CONVERT(varchar(max), @countPlusOne)
	SET @GetDateNow = CONVERT(VARCHAR(10),GETDATE(),103)
		

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
	[ACT_REFERENCE],
	[DUE_DATE] ,
	[STATUS] ,
	[DATE_CLOSED] ,
	[DATE_RAISED]
)
VALUES
(
	'C'+ '1-' + @GetDateNow,
	@CONCERN,
	@CAUSE ,
	@COUNTERMEASURE , 
	@EMP_ID ,
	@ACT_REFERENCE,
	@DUE_DATE ,
	@STATUS ,
	@DATE_CLOSED ,
	@DATE_RAISED 

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
	[ACT_REFERENCE],
	[DUE_DATE] ,
	[STATUS] ,
	[DATE_CLOSED] ,
	[DATE_RAISED]
)
VALUES
(
	'C'+ @num +'-' + @GetDateNow,
	@CONCERN,
	@CAUSE ,
	@COUNTERMEASURE , 
	@EMP_ID ,
	@ACT_REFERENCE,
	@DUE_DATE ,
	@STATUS ,
	@DATE_CLOSED ,
	@DATE_RAISED 

)
	END

	END


GO
