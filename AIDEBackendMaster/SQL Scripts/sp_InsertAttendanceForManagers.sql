USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendanceForManagers]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertAttendanceForManagers]
	@from datetime,
	@to datetime,
	@EMP_ID int ,
	@STATUS INT
AS
WHILE @from<=@to
BEGIN
	declare @COUNT tinyint = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = Convert(date, @from))

	if @COUNT = 0
		begin
			INSERT [dbo].[ATTENDANCE]
			(
				[EMP_ID],
				[DATE_ENTRY],
				[STATUS]
			)
			VALUES
			(
				@EMP_ID,
				@from,
				@STATUS	
			)
		end 
	else
		begin
			update ATTENDANCE set STATUS = 2 where EMP_ID = @EMP_ID and DATE_ENTRY = Convert(datetime, getdate())
		end
	SET @from=DATEADD(DAY,1,@from)
END






GO
