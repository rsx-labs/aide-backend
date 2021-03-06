USE [AIDE]
GO

/****** Object:  Table [dbo].[RESOURCE_PLANNER]    Script Date: 11/07/2019 5:41:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RESOURCE_PLANNER')
BEGIN
	DROP TABLE [dbo].[RESOURCE_PLANNER]
END
GO
CREATE TABLE [dbo].[RESOURCE_PLANNER](
	[EMP_ID] [int] NOT NULL,
	[DATE_ENTRY] [datetime] NOT NULL,
	[STATUS] [int] NOT NULL,
	[COUNTS] [float] NULL,
	[STATUS_CD] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC,
	[DATE_ENTRY] ASC,
	[STATUS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RESOURCE_PLANNER] ADD  DEFAULT ((1)) FOR [STATUS_CD]
GO


