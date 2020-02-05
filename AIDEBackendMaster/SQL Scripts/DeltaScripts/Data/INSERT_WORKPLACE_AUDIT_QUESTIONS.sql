USE [AIDE]
GO

---THIS IS TO INSERT ALL QUESTION FROM AUDIT 
DELETE FROM WORKPLACE_AUDIT_QUESTIONS
---DAILY
	INSERT INTO WORKPLACE_AUDIT_QUESTIONS VALUES	(1,915000121,'1. Has the attendance of the team bee checked?',915000121,1 ),
													(3,915000121,'2. Does the team attendance match the Daily Resource Planner in the Comm. Cell Board?',915000121,1),
													(5,	915000121,	'3. Has corresponding tasks been assigned to all resources?',	915000121,	1),
													(7,	915000121,	'4. Has the previous weekly audit been completed?',	915000121,	1)


---WEEKLY
	INSERT INTO WORKPLACE_AUDIT_QUESTIONS VALUES	(9,		915000121,	'1. Has the OTL been logged by the team?',	915000121,	2),
													(10,	915000121,	'2. Has the SAP been logged by the team?',	915000121,	2),
													(11,	915000121,	'3. Has the SAP and OTL report been generated and without discrepancies?',	915000121,	2),
													(12,	915000121,	'4. Have the SAP and OTL discrepancies been corrected?',	915000121,	2),
													(13,	915000121,	'5. Has the status reports been submitted by the team?',	915000121,	2),
													(14,	915000121,	'6. Are assigned iLearn courses on track for completion, if any?',	915000121,	2),
													(16,	915000121,	'7. Is the Comm. Cell board up to date?- Evidence that team is having weekly Comm. Cells - Pending actions of Comm. Cells and problem solving been actioned.Success been registered in the Comm. Cell Board- Lessons learned been registered in the Comm. Cell Board',	915000121,	2),
													(18,	915000121,	'8. Have all non-conformances from the audit been raised as a concern on the Comm. Cell 3C document?',	915000121,	2),
													(19,	915000121,	'9. Has the daily audit of the previous week been completed?',	915000121,	2),
													(20,	915000121,	'10. Has the monthly audit been completed?',	915000121,	2)



---MONTHLY
	INSERT INTO WORKPLACE_AUDIT_QUESTIONS VALUES	(23,	915000121,	'1. Has the Monthly KPI report been submitted?',	915000121,	3),
													(24,	915000121,	'2. Has there been monthly staff meeting?',	915000121,	3),
													(25,	915000121,	'3. Has the weekly audit been completed?',	915000121,	3)





---QUARTERLY
	INSERT INTO WORKPLACE_AUDIT_QUESTIONS VALUES	(29,	915000121,	'1. Has there been quarterly review with customer?',	915000121,	4),
													(30,	915000121,	'2. Has the quarterly SI, team building or any team bonding activity been conducted?',	915000121,	4),
													(31,	915000121,	'3. Has the problem solving been implemented and reviewed?',	915000121,	4),
													(32,	915000121,	'4. Has the monthly audit been completed?',	915000121,	4),
													(33,	915000121,	'5. Has the BCP Call tree been Implemented?',	915000121,	4)



