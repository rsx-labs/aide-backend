USE [AIDE]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PROBLEM_OPTION')
BEGIN
	DROP TABLE [dbo].[PROBLEM_OPTION]
END

CREATE TABLE [dbo].[PROBLEM_OPTION](
	[OPTION_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROBLEM_ID] [int] NOT NULL,
	[OPTION_DESCR] VARCHAR(MAX)
 CONSTRAINT [PK_PROBLEM_OPTION] PRIMARY KEY CLUSTERED 
(
	[OPTION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


