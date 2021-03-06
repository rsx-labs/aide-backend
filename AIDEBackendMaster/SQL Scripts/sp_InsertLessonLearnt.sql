USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLessonLearnt]    Script Date: 12/05/2019 10:41:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertLessonLearnt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertLessonLearnt]
GO

CREATE PROCEDURE [dbo].[sp_InsertLessonLearnt]
	@REF_NO varchar(20),
	@EMP_ID int ,
	@PROBLEM varchar(max) ,
	@RESOLUTION varchar(max) ,
	@ACTION_NO varchar(20)
AS
BEGIN
	INSERT INTO [dbo].[LESSON_LEARNT]
	(
		[REF_NO],
		[EMP_ID],
		[PROBLEM],
		[RESOLUTION],
		[ACTION_NO],
		[DATE_CREATED]
	)
	VALUES
	(
		@REF_NO,
		@EMP_ID,
		@PROBLEM,
		@RESOLUTION,
		@ACTION_NO,
		GETDATE()
	)
END
