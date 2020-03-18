USE [AIDE]
GO

-- Insert Contacts table
INSERT INTO [CONTACTS] ([EMP_ID],
						[EMAIL_ADDRESS], 
						[LOCATION],
						[DT_REVIEWED])
VALUES (0, 'retail.dev@fujitsu.com', 1, '2020-01-01')


-- Insert Employee table
INSERT INTO [EMPLOYEE] ([EMP_ID],
						[WS_EMP_ID],
						[LAST_NAME],
						[FIRST_NAME],
						[STATUS],
						[POS_ID],
						[GRP_ID],
						[DEPT_ID],
						[DIV_ID],
						[ACTIVE],
						[APPROVED])
VALUES (0, 0, 'RETAIL', 'DEV', 1, 5, 5, 1, 1, 1, 1)
