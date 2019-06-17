USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertContacts]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertContacts] 
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@EMAIL_ADDRESS VARCHAR(50),
	@EMAIL_ADDRESS2 VARCHAR(50) = NULL,
	@LOCATION VARCHAR(50),
	@HOMEPHONE VARCHAR(50) = NULL,
	@OTHERPHONE VARCHAR(50) = NULL,
	@CEL_NO VARCHAR(50),
	@LOCAL INT  = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[CONTACTS]
	VALUES( @EMP_ID,
			@EMAIL_ADDRESS,
			ISNULL(@EMAIL_ADDRESS2, NULL),
			@LOCATION,
			@CEL_NO,
			ISNULL(@LOCAL, NULL),
			ISNULL(@HOMEPHONE, NULL),
			ISNULL(@OTHERPHONE, NULL),
			GETDATE())
END

GO
