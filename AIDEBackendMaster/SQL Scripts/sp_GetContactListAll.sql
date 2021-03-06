USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetContactListAll]    Script Date: 11/28/2019 8:53:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetContactListAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetContactListAll]
GO

CREATE PROCEDURE [dbo].[sp_GetContactListAll]
	-- Add the parameters for the stored procedure here
	@EMPID INT,
	@SELECTION INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID),
			@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMPID)

	DECLARE @guestAccount SMALLINT = 5
    -- Insert statements for procedure here
	
	SELECT e.EMP_ID, e.LAST_NAME, e.FIRST_NAME, e.MIDDLE_NAME, e.NICK_NAME, 
		   e.ACTIVE, e.BIRTHDATE, e.DATE_HIRED AS 'DT_HIRED', e.IMAGE_PATH, p.DESCR AS 'POSITION', s.DESCR AS 'MARITAL_STATUS',
		   pg.DESCR AS 'PERMISSION_GROUP', dp.DESCR AS 'DEPARTMENT', dv.DESCR AS 'DIVISION', 
		   e.SHIFT_STATUS AS 'SHIFT', c.EMAIL_ADDRESS, c.EMAIL_ADDRESS2, l.LOCATION AS 'LOCATION', c.CEL_NO, c.LOCAL, c.HOMEPHONE, c.OTHER_PHONE, c.DT_REVIEWED,
		   e.STATUS AS 'MARITAL_STATUS_ID', 
		   e.POS_ID AS 'POSITION_ID', 
		   e.GRP_ID AS 'PERMISSION_GROUP_ID', 
		   e.DEPT_ID AS 'DEPARTMENT_ID', 
		   e.DIV_ID AS 'DIVISION_ID',
		   c.LOCATION AS 'LOCATION_ID'
	FROM [dbo].[EMPLOYEE] e 
	INNER JOIN [dbo].[CONTACTS] c 
	ON c.emp_id = e.emp_id 
	INNER JOIN [dbo].[LOCATION] l
	ON c.LOCATION = l.LOCATION_ID  
	INNER JOIN [dbo].[POSITION] p
	ON e.POS_ID = p.POS_ID
	INNER JOIN [dbo].[STATUS] s
	ON e.STATUS = s.STATUS
	INNER JOIN [dbo].[PERMISSION_GROUP] pg
	ON e.GRP_ID = pg.GRP_ID
	INNER JOIN [dbo].[DEPARTMENT] dp
	ON e.DEPT_ID = dp.DEPT_ID
	INNER JOIN [dbo].[DIVISION] dv
	ON e.DIV_ID = dv.DIV_ID
	WHERE (@SELECTION = 0 AND s.STATUS_ID = 1 AND e.DEPT_ID = @DEPTID AND e.DIV_ID = @DIVID AND e.APPROVED = 1 AND e.ACTIVE = 1 AND e.GRP_ID != @guestAccount)
	OR (@SELECTION = 1 AND s.STATUS_ID = 1 AND e.ACTIVE = 2 AND e.GRP_ID != @guestAccount)
	OR (@SELECTION = 2 AND s.STATUS_ID = 1 AND e.DEPT_ID = @DEPTID AND e.DIV_ID = @DIVID AND  e.APPROVED = 2 AND e.GRP_ID != @guestAccount)
	ORDER BY e.LAST_NAME
END