USE [AIDE]
GO

DELETE FROM [dbo].[LOCATION]

DBCC CHECKIDENT ('LOCATION', RESEED, 0)

INSERT INTO [dbo].[LOCATION]([LOCATION],[ONSITE_FLG],[HOLIDAY_FLG])
     VALUES('Eco Tower, BGC',	0,	0),
			('Net Square, BGC',	1,	0),
			('Raleigh, Durham',	1,	1),
			('Work From Home',	1,	0)
GO


