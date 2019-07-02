USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateConcernCauseCountermeasure]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateConcernCauseCountermeasure]
	@REF_ID int ,
	@CONCERN varchar(20) ,
	@CAUSE varchar(max) ,
	@COUNTERMEASURE varchar(max),	
	@DUE_DATE date,
	@STATUS INT	
		
AS

SET NOCOUNT ON
BEGIN
UPDATE CONCERN_CAUSE_COUNTERMEASURE

SET [REF_ID] = @REF_ID  ,
	[CONCERN] = @CONCERN  ,
	[CAUSE] = @CAUSE  ,	
	[COUNTERMEASURE] = @COUNTERMEASURE,
	[DUE_DATE] = @DUE_DATE,
	[STATUS] = @STATUS
	FROM CONCERN_CAUSE_COUNTERMEASURE
	WHERE REF_ID = @REF_ID
END

INSERT INTO CONCERN_CAUSE_COUNTERMEASURE(
			[REF_ID])
			VALUES(
			@REF_ID)
	
GO
