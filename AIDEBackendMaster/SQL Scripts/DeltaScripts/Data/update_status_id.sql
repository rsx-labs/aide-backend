USE AIDE

UPDATE dbo.[STATUS] SET DESCR = 'Partially Assigned' WHERE STATUS = 3 AND STATUS_ID = 11
UPDATE dbo.[STATUS] SET DESCR = 'Partially Unassigned' WHERE STATUS = 4 AND STATUS_ID = 11
UPDATE dbo.[STATUS] SET STATUS = 6 WHERE STATUS = 2 AND STATUS_ID = 12
UPDATE dbo.[STATUS] SET STATUS_ID = 11 WHERE STATUS_ID = 12