USE [AIDE]
GO

/****** Object:  Table [dbo].[WORKPLACE_AUDIT_QUESTIONS]    Script Date: 9/12/2019 8:56:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'WORKPLACE_AUDIT_QUESTIONS')
BEGIN
	DROP TABLE [dbo].[WORKPLACE_AUDIT_QUESTIONS]
END

CREATE TABLE [dbo].[WORKPLACE_AUDIT_QUESTIONS](
	[AUDIT_QUESTIONS_ID] [int]  NOT NULL,
	[EMP_ID] [int] NOT NULL,
	[AUDIT_QUESTIONS] [VARCHAR] (MAX) NOT NULL,
	[OWNER] [varchar](50) NOT NULL,
	[AUDIT_QUESTIONS_GROUP] [varchar](15) NOT NULL,
 CONSTRAINT [PK_WORKPLACE_AUDIT_QUESTIONS] PRIMARY KEY CLUSTERED 
(
	[AUDIT_QUESTIONS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


