USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSabaCourses]    Script Date: 07/10/2019 2:20:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllMessage]
@MESSAGE_ID INT,
@SEC_ID INT
AS
BEGIN							
	
	SELECT  MESSAGE_DESCR,TITLE 
	FROM [DBO].[AIDE_MESSAGE]
	WHERE MESSAGE_ID = @MESSAGE_ID AND SEC_ID = @SEC_ID
	ORDER BY ORDER_BY ASC

END
