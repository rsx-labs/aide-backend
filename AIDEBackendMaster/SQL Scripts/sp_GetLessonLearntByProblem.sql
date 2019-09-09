USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLessonLearntByProblem]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetLessonLearntByProblem]
	@PROBLEM varchar(100),
	@EMAIL_ADDRESS varchar(max)
AS

	SELECT 
		[REF_NO], 
		[L].[EMP_ID], 
		[NICK_NAME], 
		[PROBLEM], 
		[RESOLUTION], 
		[ACTION_NO]
	FROM LESSON_LEARNT L INNER JOIN EMPLOYEE E on L.EMP_ID = E.EMP_ID 
	WHERE [PROBLEM] LIKE '%' + @PROBLEM + '%'
	AND E.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS) 
	AND E.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	ORDER BY SUBSTRING(L.REF_NO,4, 8) DESC
	
GO
