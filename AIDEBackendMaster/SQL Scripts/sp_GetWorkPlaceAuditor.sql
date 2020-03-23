USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetWorkPlaceAuditor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetWorkPlaceAuditor]
GO

CREATE PROCEDURE [dbo].[sp_GetWorkPlaceAuditor]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@CHOICE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		    @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)


	IF @CHOICE = 1
		BEGIN
			SELECT (e.FIRST_NAME + ' ' + e.LAST_NAME) AS 'EMPLOYEE_NAME',c.EMAIL_ADDRESS AS 'EMAIL_ADDRESS'
			FROM WORKPLACE_AUDIT_DAILY w INNER JOIN CONTACTS c
				ON w.EMP_ID = c.EMP_ID INNER JOIN EMPLOYEE e
				ON c.EMP_ID = e.EMP_ID
			WHERE WEEKDATE = CONVERT(DATE, GETDATE()) 
				AND e.ACTIVE = 1 AND e.DIV_ID = @DIVID AND e.DEPT_ID = @DEPTID
			GROUP BY e.FIRST_NAME,e.LAST_NAME,c.EMAIL_ADDRESS
		END
	ELSE IF @CHOICE = 2
		BEGIN
			SELECT (e.FIRST_NAME + ' ' + e.LAST_NAME) AS 'EMPLOYEE_NAME',c.EMAIL_ADDRESS AS 'EMAIL_ADDRESS'
			FROM WORKPLACE_AUDIT_WEEKLY w INNER JOIN CONTACTS c
				ON w.EMP_ID = c.EMP_ID INNER JOIN EMPLOYEE e
				ON c.EMP_ID = e.EMP_ID
			WHERE WEEKDATE BETWEEN CONVERT(DATE, GETDATE()) 
				AND CONVERT(DATE, DATEADD(DAY, 4, GETDATE()))
				AND e.ACTIVE = 1 AND e.DIV_ID = @DIVID AND e.DEPT_ID = @DEPTID
			GROUP BY e.FIRST_NAME,e.LAST_NAME,c.EMAIL_ADDRESS
		END
	ELSE
		BEGIN
			SELECT (e.FIRST_NAME + ' ' + e.LAST_NAME) AS 'EMPLOYEE_NAME',c.EMAIL_ADDRESS AS 'EMAIL_ADDRESS'
			FROM WORKPLACE_AUDIT_WEEKLY w INNER JOIN CONTACTS c
				ON w.EMP_ID = c.EMP_ID INNER JOIN EMPLOYEE e
				ON c.EMP_ID = e.EMP_ID
			WHERE MONTH(w.WEEKDATE) = MONTH(GETDATE())
				AND YEAR(w.WEEKDATE) = YEAR(GETDATE())
				AND e.ACTIVE = 1 AND e.DIV_ID = @DIVID AND e.DEPT_ID = @DEPTID
			GROUP BY e.FIRST_NAME,e.LAST_NAME,c.EMAIL_ADDRESS
		END

END
