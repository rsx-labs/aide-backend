USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBirthdayListAllByMonth]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Batongbacal, Aevan Camille N.
-- Create date: August 23, 2017
-- Description:	Used to get the list of Contact 
--				information of the department
-- =============================================

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetBirthdayListAllByMonth'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetBirthdayListAllByMonth]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetBirthdayListAllByMonth]
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE e, CONTACTS c
							WHERE e.EMP_ID = c.EMP_ID 
							AND c.EMAIL_ADDRESS = @EMAIL)

	DECLARE @DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE e, CONTACTS c
							WHERE e.EMP_ID = c.EMP_ID 
							AND c.EMAIL_ADDRESS = @EMAIL)
							
	DECLARE @guestAccount SMALLINT = 5 

	SELECT FIRST_NAME, LAST_NAME, BIRTHDATE, e.EMP_ID, IMAGE_PATH
	FROM [EMPLOYEE] e
	INNER JOIN [CONTACTS] c
	ON e.EMP_ID = c.EMP_ID
	WHERE DEPT_ID = @DEPT_ID
	AND DIV_ID = @DIV_ID
	AND ACTIVE = 1
	AND GRP_ID != @guestAccount -- guestAccount cannot be retrieved
	AND MONTH(BIRTHDATE) = MONTH(GETDATE())
	ORDER BY DAY(BIRTHDATE)
END

GO
