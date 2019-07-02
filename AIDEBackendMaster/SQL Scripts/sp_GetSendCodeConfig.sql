USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeEmail]    Script Date: 6/10/2019 2:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetSendCodeConfig]
	-- Add the parameters for the stored procedure here
AS
DECLARE @decryptVar VARCHAR(MAX), @decryptBin VARBINARY(200)
BEGIN

SET @decryptBin = CONVERT(VARBINARY(200),(SELECT SC_SENDER_PASSWORD FROM SEND_CODE_CONFIG),1)
SET @decryptVar = CONVERT(VARCHAR(MAX),DECRYPTBYPASSPHRASE('fujitsu.key.001', @decryptBin))

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

    -- Select statements for procedure here
	
	SELECT SC_SENDER_EMAIL,SC_SUBJECT,SC_BODY,
	SC_PORT,SC_HOST,SC_ENABLE_SSL,SC_TIMEOUT, 
	SC_USE_DFLT_CREDENTIALS,@decryptVar as SC_SENDER_PASSWORD,SC_PASSWORD_EXPIRY 
	FROM SEND_CODE_CONFIG
END 
