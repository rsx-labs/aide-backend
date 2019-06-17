USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetGeneratedRefNo]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetGeneratedRefNo]

AS
DECLARE		@GENERATEDREF_ID varchar(max),
			@countPlusOne int,
			@GetDateNow varchar(max),
			@num varchar(max),
			@counts varchar(10)=(SELECT COUNT(DATE_RAISED) FROM [dbo].[Concern_Cause_Countermeasure]);
	
	SET @countPlusOne = 1 + CONVERT(int, @counts)		
	SET @num = CONVERT(varchar(max), @countPlusOne)
	SET @GetDateNow = CONVERT(VARCHAR(10),GETDATE(),103)
	SET @GENERATEDREF_ID = 'C'+ @num +'-' + @GetDateNow


		
	

		BEGIN 

				SELECT 
						@GENERATEDREF_ID  AS GENERATEDREF_ID
	

		END


GO
