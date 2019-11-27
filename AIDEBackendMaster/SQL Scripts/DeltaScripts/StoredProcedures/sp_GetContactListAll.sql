USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetContactListAll]    Script Date: 11/27/2019 1:47:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetContactListAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetContactListAll]
GO

CREATE PROCEDURE [dbo].[sp_GetContactListAll]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(MAX),
	@SELECTION INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

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
	WHERE @SELECTION = 0 AND s.STATUS_ID = 1
	AND e.DEPT_ID = (
		SELECT DEPT_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	AND e.DIV_ID = (
		SELECT DIV_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	 AND e.APPROVED = 1

	OR @SELECTION = 1 AND s.STATUS_ID = 1
	AND e.ACTIVE = 2

	OR @SELECTION = 2 AND s.STATUS_ID = 1
	AND e.DEPT_ID = (
		SELECT DEPT_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	AND e.DIV_ID = (
		SELECT DIV_ID FROM EMPLOYEE a
		INNER JOIN CONTACTS b 
		ON a.EMP_ID = b.EMP_ID
		WHERE b.EMAIL_ADDRESS = @EMAIL
		)
	AND  e.APPROVED = 2
	ORDER BY e.LAST_NAME
END