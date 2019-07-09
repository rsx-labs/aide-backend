USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateContacts]    Script Date: 06/30/2019 11:25:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateContacts] 
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@LAST_NAME VARCHAR(50),
	@FIRST_NAME VARCHAR(50),
	@MIDDLE_NAME VARCHAR(50),
	@NICK_NAME VARCHAR(50),
	@ACTIVE SMALLINT,
	@BIRTHDATE DATE,
	@DT_HIRED Date,
	@IMAGE_PATH VARCHAR(255),
	@SHIFT VARCHAR(50),
	@EMAIL_ADDRESS VARCHAR(50),
	@EMAIL_ADDRESS2 VARCHAR(50),
	@LOCATION VARCHAR(50),
	@CEL_NO VARCHAR(50),
	@LOCAL INT,
	@HOMEPHONE VARCHAR(50),
	@OTHERPHONE VARCHAR(50),
	@DT_REVIEWED DATE,
	@MARITAL_STATUS_ID VARCHAR(50),
	@POSITION_ID SMALLINT,
	@PERMISSION_GROUP_ID SMALLINT,
	@DEPARTMENT_ID SMALLINT,
	@DIVISION_ID SMALLINT,
	@OLD_EMP_ID INT,
	@SELECTION INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @MANAGER_DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @OLD_EMP_ID)
	DECLARE @MANAGER_DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @OLD_EMP_ID)

	IF @SELECTION = 0
		BEGIN
		IF @MANAGER_DEPT_ID = @DEPARTMENT_ID
		AND @MANAGER_DEPT_ID = @DIVISION_ID
		BEGIN
		 -- UPDATE CONTACTS TABLE
	UPDATE [dbo].[CONTACTS]
	SET [EMAIL_ADDRESS2] = @EMAIL_ADDRESS2,
		[LOCATION] = @LOCATION,
		[CEL_NO] = @CEL_NO,
		[HOMEPHONE] = ISNULL(@HOMEPHONE, [HOMEPHONE]),
		[OTHER_PHONE] = ISNULL(@OTHERPHONE, [OTHER_PHONE]),
		[LOCAL] = ISNULL(@LOCAL, [LOCAL]),
		[DT_REVIEWED] = @DT_REVIEWED,
		[EMAIL_ADDRESS] = @EMAIL_ADDRESS
	WHERE [EMP_ID] = @EMP_ID


	-- UPDATE EMPLOYEE TABLE
	UPDATE EMPLOYEE SET [LAST_NAME] = @LAST_NAME,
		[FIRST_NAME] = @FIRST_NAME,
		[MIDDLE_NAME] = @MIDDLE_NAME,
		[NICK_NAME] = @NICK_NAME,
		[BIRTHDATE]= @BIRTHDATE,
		[POS_ID] = @POSITION_ID,
		[DATE_HIRED] = @DT_HIRED,
		[STATUS] = @MARITAL_STATUS_ID,
		[IMAGE_PATH] = @IMAGE_PATH,
		[GRP_ID] = @PERMISSION_GROUP_ID,
		[DEPT_ID] = @DEPARTMENT_ID,
		[ACTIVE] = @ACTIVE,
		[DIV_ID] = @DIVISION_ID,
		[SHIFT_STATUS] = @SHIFT
	WHERE EMP_ID = @EMP_ID

	--	--To mark as Onsite
	--IF @LOCATION != 'Eco Tower, BGC'
	--	BEGIN
	--		exec dbo.[sp_UpdateResourcePlanner] @from = @DT_REVIEWED, @to = @DT_REVIEWED, @EMP_ID = @EMP_ID, @STATUS = 1 
	--	END
	--ELSE IF @LOCATION = 'Eco Tower, BGC'
	--	BEGIN
	--		exec dbo.[sp_UpdateResourcePlanner] @from = @DT_REVIEWED, @to = @DT_REVIEWED, @EMP_ID = @EMP_ID, @STATUS = 2 
	--	END

		END
	ELSE
		BEGIN
		-- UPDATE CONTACTS TABLE
	UPDATE [dbo].[CONTACTS]
	SET [EMAIL_ADDRESS2] = @EMAIL_ADDRESS2,
		[LOCATION] = @LOCATION,
		[CEL_NO] = @CEL_NO,
		[HOMEPHONE] = ISNULL(@HOMEPHONE, [HOMEPHONE]),
		[OTHER_PHONE] = ISNULL(@OTHERPHONE, [OTHER_PHONE]),
		[LOCAL] = ISNULL(@LOCAL, [LOCAL]),
		[DT_REVIEWED] = @DT_REVIEWED,
		[EMAIL_ADDRESS] = @EMAIL_ADDRESS
	WHERE [EMP_ID] = @EMP_ID


	-- UPDATE EMPLOYEE TABLE
	UPDATE EMPLOYEE SET [LAST_NAME] = @LAST_NAME,
		[FIRST_NAME] = @FIRST_NAME,
		[MIDDLE_NAME] = @MIDDLE_NAME,
		[NICK_NAME] = @NICK_NAME,
		[BIRTHDATE]= @BIRTHDATE,
		[POS_ID] = @POSITION_ID,
		[DATE_HIRED] = @DT_HIRED,
		[STATUS] = @MARITAL_STATUS_ID,
		[IMAGE_PATH] = @IMAGE_PATH,
		[GRP_ID] = @PERMISSION_GROUP_ID,
		[DEPT_ID] = @DEPARTMENT_ID,
		[ACTIVE] = @ACTIVE,
		[DIV_ID] = @DIVISION_ID,
		[SHIFT_STATUS] = @SHIFT,
		[APPROVED] = 2
	WHERE EMP_ID = @EMP_ID
		END
		END
	ELSE IF @SELECTION = 1
		BEGIN
		-- UPDATE EMPLOYEE TABLE
	UPDATE EMPLOYEE SET 
		[DEPT_ID] = @MANAGER_DEPT_ID,
		[ACTIVE] = @ACTIVE,
		[DIV_ID] = @MANAGER_DEPT_ID,
		[APPROVED] = 1
	WHERE EMP_ID = @EMP_ID
		END
	ELSE IF @SELECTION = 2
		BEGIN
		UPDATE EMPLOYEE SET 
		[ACTIVE] = @ACTIVE,
		[APPROVED] = 1
	WHERE EMP_ID = @EMP_ID
		END

	
   


END
