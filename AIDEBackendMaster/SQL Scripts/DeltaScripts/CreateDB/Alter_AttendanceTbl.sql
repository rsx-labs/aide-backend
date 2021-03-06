USE [AIDE]
GO

/****** Object:  Table [dbo].[ATTENDANCE]    Script Date: 09/02/2019 1:53:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TABLE ATTENDANCE
ADD LOGOFF_FLG TINYINT
	CONSTRAINT df_Logoff_flg DEFAULT(0) WITH VALUES,
	LOGOFF_TIME DATETIME
	
GO

IF NOT EXISTS(SELECT (1) FROM INFORMATION_SCHEMA.COLUMNS WHERE [TABLE_NAME] = 'ATTENDANCE' AND [COLUMN_NAME] = 'COUNTS')
	BEGIN
		ALTER TABLE ATTENDANCE 
		ADD COUNTS FLOAT
	END

IF NOT EXISTS(SELECT (1) FROM INFORMATION_SCHEMA.COLUMNS WHERE [TABLE_NAME] = 'ATTENDANCE' AND [COLUMN_NAME] = 'STATUS_CD')
	BEGIN
		ALTER TABLE ATTENDANCE 
		ADD STATUS_CD SMALLINT NOT NULL DEFAULT(1)
	END

	BEGIN
		ALTER TABLE ATTENDANCE
		DROP CONSTRAINT PK__ATTENDAN__60A90BA5AE0CC413

		ALTER TABLE ATTENDANCE
		ALTER COLUMN [STATUS] INT NOT NULL

		ALTER TABLE ATTENDANCE
		ADD CONSTRAINT PK_Attendance PRIMARY KEY (EMP_ID, DATE_ENTRY, STATUS)
	END