USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_PROJECT_Insert]    Script Date: 01/09/2020 10:31:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_PROJECT_Insert'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_PROJECT_Insert]
    END
GO

CREATE PROCEDURE [dbo].[sp_PROJECT_Insert]
	@PROJ_CD nvarchar(10) ,
	@PROJ_NAME VARCHAR(50) ,
	@CATEGORY smallint ,
	@BILLABILITY smallint,
	@EMP_ID int

AS

INSERT [dbo].[PROJECT]
(
	[PROJ_CD],
	[PROJ_NAME],
	[CATEGORY],
	[BILLABILITY],
	[EMP_ID]
)
VALUES
(
	@PROJ_CD,
	@PROJ_NAME,
	@CATEGORY,
	@BILLABILITY,
	@EMP_ID

)


