USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertSabaCourses]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.[sp_InsertSabaCourses]'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_InsertSabaCourses]
    END
GO

CREATE PROCEDURE [dbo].[sp_InsertSabaCourses] 
	@EMP_ID INT, 
	@TITLE VARCHAR(100), 
	@END_DATE DATE
AS

	DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@NEW_SABA_ID INT

	DECLARE @guestAccount SMALLINT = 5

	-- Insert Saba Courses Table
	INSERT INTO SABA_COURSES (EMP_ID, TITLE, END_DATE)
	VALUES (@EMP_ID, @TITLE, @END_DATE)

	SET @NEW_SABA_ID = (SELECT TOP(1) SABA_ID FROM SABA_COURSES ORDER BY SABA_ID DESC)
	
	-- Insert Saba XREF Table
	INSERT INTO SABA_XREF (SABA_ID, EMP_ID)
	SELECT @NEW_SABA_ID, EMP_ID FROM EMPLOYEE 
	WHERE DIV_ID = @DIV_ID 
	AND DEPT_ID = @DEPT_ID
	AND GRP_ID != @guestAccount --guest account cannot be created

GO
