USE [AIDE]
GO

/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 07/07/2019 8:52:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [DBO].[RESOURCE_PLANNER]
	ADD STATUS_CD INT NOT NULL 
	DEFAULT (1)
	WITH VALUES

GO

SET ANSI_PADDING OFF
GO

