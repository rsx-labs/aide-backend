USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLessonLearntListOfActionSummary]    Script Date: 12/10/2019 9:38:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetLessonLearntListOfActionSummary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetLessonLearntListOfActionSummary]
GO

CREATE PROCEDURE [dbo].[sp_GetLessonLearntListOfActionSummary]
	@EMP_ID int

AS

DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
						
BEGIN
	SELECT * FROM ACTIONLIST A
	INNER JOIN EMPLOYEE E
	ON A.EMP_ID = E.EMP_ID
	WHERE ACTREF NOT IN (SELECT ACTION_NO FROM LESSON_LEARNT WHERE ACTION_NO = ACTREF) 
	AND E.DEPT_ID = @DEPT_ID 
	AND E.DIV_ID = @DIV_ID
	ORDER BY DATE_CREATED DESC
END
