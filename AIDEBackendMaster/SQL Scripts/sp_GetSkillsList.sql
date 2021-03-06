USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSkillsList]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSkillsList]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	DECLARE @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

    -- Insert statements for procedure here
	SELECT A.SKILL_ID, A.DESCR FROM SKILLS A 
	INNER JOIN SKILLS_DEPT b on a.SKILL_ID = b.SKILL_ID
	INNER JOIN EMPLOYEE C ON B.EMP_ID = C.EMP_ID
	WHERE b.DISPLAY_FG = 1 AND C.DEPT_ID = @DEPTID AND C.DIV_ID = @DIVID OR B.DSPLY_TO_ALL = 1
	ORDER BY A.DSPLY_ORDR ASC, A.DESCR ASC

END



GO
