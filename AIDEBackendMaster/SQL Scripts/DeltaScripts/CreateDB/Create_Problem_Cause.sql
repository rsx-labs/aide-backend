USE [AIDE]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PROBLEM_CAUSE')
BEGIN
	DROP TABLE [dbo].[PROBLEM_CAUSE]
END

CREATE TABLE [dbo].[PROBLEM_CAUSE](
	[CAUSE_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROBLEM_ID] [int] NOT NULL,
	[CAUSE_DESCR] VARCHAR(50),
	[CAUSE_WHY] VARCHAR(MAX)
 CONSTRAINT [PK_PROBLEM_CAUSE] PRIMARY KEY CLUSTERED 
(
	[CAUSE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


