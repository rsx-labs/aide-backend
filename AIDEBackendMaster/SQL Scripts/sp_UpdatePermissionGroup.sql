USE [AIDE]
GO

DELETE FROM [dbo].[PERMISSION_GROUP]

INSERT INTO [dbo].[PERMISSION_GROUP]
           ([GRP_ID]
           ,[DESCR])
     VALUES
           (1,	'Manager level'),
		   (2,	'User level')
GO