USE [AIDE]
GO

/****** Object:  StoredProcedure [dbo].[sp_EmployeeSkillsByDeptID]    Script Date: 11/06/2019 3:04:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================


IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_EmployeeSkillsByDeptID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].sp_EmployeeSkillsByDeptID
GO

CREATE PROCEDURE [dbo].[sp_EmployeeSkillsByDeptID]
	-- Add the parameters for the stored procedure here
	@empID as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT  A.EMP_ID, A.LAST_NAME + ', ' + A.FIRST_NAME AS EMPLOYEE_NAME,
			C.DESCR, B.PROF_LVL, B.LAST_REVIEWED
		FROM EMPLOYEE A INNER JOIN SKILLS_PROF B 
		on a.EMP_ID = B.EMP_ID
		INNER JOIN  SKILLS C 
		on B.SKILL_ID = C.SKILL_ID 
		INNER JOIN SKILLS_DEPT D 
		ON C.SKILL_ID = D.SKILL_ID
		WHERE D.DISPLAY_FG = 1
		AND A.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @empID)
		AND A.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @empID) AND A.ACTIVE <> 2
		ORDER BY  EMPLOYEE_NAME ASC, C.DSPLY_ORDR ASC, C.DESCR ASC

END
GO


