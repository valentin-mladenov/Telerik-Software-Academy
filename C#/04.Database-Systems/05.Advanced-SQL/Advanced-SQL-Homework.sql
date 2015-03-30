/****** Task 1. Write a SQL query to find the names and salaries of the employees
		that take the minimal salary in the company. Use a nested SELECT statement.  ******/
SELECT e.FirstName +' '+e.LastName AS EmployeeName, e.[Salary] AS Salary
	FROM [TelerikAcademy].[dbo].[Employees] e
WHERE Salary = 
	(SELECT MIN([Salary]) FROM [TelerikAcademy].[dbo].[Employees])

/****** Task 2. Write a SQL query to find the names and salaries of the employees that have a
		salary that is up to 10% higher than the minimal salary for the company.  ******/
-- Little tricky that one won't work without variable.
DECLARE @MinSalary int;
SET @MinSalary = (SELECT MIN(e.[Salary])
FROM [TelerikAcademy].[dbo].[Employees] e)

SELECT e.FirstName +' '+e.LastName AS EmployeeName, e.Salary
	FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary BETWEEN @MinSalary AND @MinSalary * 1.1

/****** Task 3. Write a SQL query to find the full name, salary and department of the
		employees that take the minimal salary in their department.
		Use a nested SELECT statement.  ******/
SELECT e.[FirstName] +' '+e.[LastName] AS EmployeeName, 
		e.[Salary], 
		d.[Name]
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Departments] d
		ON d.[DepartmentID] = e.[DepartmentID]
WHERE Salary = 
	(SELECT MIN(em.[Salary]) 
		FROM [TelerikAcademy].[dbo].[Employees] em
	WHERE em.[DepartmentID]=e.[DepartmentID])

/****** Task 4. Write a SQL query to find the average salary in the department #1.  ******/
SELECT AVG(e.[Salary]) AS [Average Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.[DepartmentID] = 1

/****** Task 5. Write a SQL query to find the average salary  in the "Sales" department.  ******/
SELECT AVG(e.[Salary]) AS [Average Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.[DepartmentID] = d.[DepartmentID]
WHERE d.[Name] = 'Sales'

/****** Task 6. Write a SQL query to find the number of employees in the "Sales" department.  ******/
SELECT COUNT(*) AS [All Employees In Sales]
	FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.[DepartmentID] = d.[DepartmentID]
WHERE d.[Name] = 'Sales'

/****** Task 7. Write a SQL query to find the number of all employees that have manager.  ******/
SELECT COUNT(*) AS [All Employees With Manager]
  FROM [TelerikAcademy].[dbo].[Employees] e
  WHERE e.[ManagerID] IS NOT NULL

/****** Task 8. Write a SQL query to find the number of all employees that have no manager.  ******/
SELECT COUNT(*) AS [All Employees With Manager]
  FROM [TelerikAcademy].[dbo].[Employees] e
  WHERE e.[ManagerID] IS NULL

/****** Task 9. Write a SQL query to find all departments and the average salary for each of them.  ******/
SELECT d.[Name] AS [Departament Name], AVG(e.[Salary]) AS AvaregeSalary
  FROM [TelerikAcademy].[dbo].[Employees] e
  JOIN [TelerikAcademy].[dbo].[Departments] d
	ON d.[DepartmentID] = e.[DepartmentID]
GROUP BY d.[Name] 

/****** Task 10. Write a SQL query to find the count of all employees in each department and for each town.  ******/
SELECT d.[Name] AS [Departament Name], t.[Name] AS [TownName], COUNT(e.[FirstName]) AS EmployeeCount
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Departments] d
		ON d.[DepartmentID] = e.[DepartmentID]
	JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON a.[AddressID] = e.[AddressID]
	JOIN [TelerikAcademy].[dbo].[Towns] t
		ON a.[TownID] = t.[TownID]
GROUP BY t.[Name], d.[Name]

/****** Task 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.  ******/
SELECT m.[FirstName] + ' ' + m.[LastName] AS [ManagerName], COUNT(e.[EmployeeID]) AS [Count]
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.[ManagerID] = m.[EmployeeID]
	GROUP BY m.[FirstName] + ' ' + m.[LastName]
	HAVING COUNT(e.[EmployeeID]) = 5

/****** Task 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".  ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS [ManagerName]
	FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.[ManagerID] = m.[EmployeeID]
UNION
SELECT em.[FirstName] + ' ' + em.[LastName] AS [EmployeeName], ISNULL(CONVERT(nvarchar(50), em.[ManagerID]), '(no manager)') AS [ManagerName]
	FROM [TelerikAcademy].[dbo].[Employees] em
WHERE em.[ManagerID] IS NULL

/****** Task 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.  ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName]
	FROM [TelerikAcademy].[dbo].[Employees] e
WHERE LEN(e.[LastName]) = 5

/****** Task 14. Write a SQL query to display the current date and time in the following format 
				"day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.  ******/
SELECT CONVERT(VARCHAR(24),GETDATE(),113) AS [Current DateTime]
--OR
SELECT FORMAT(GETDATE(), 'dd.mm.yyyy hh:mm:ss:ff') AS [Current DateTime]

/****** Task 15. Write a SQL statement to create a table Users. 
		Users should have username, password, full name and last login time. 
		Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
		Define the primary key column as identity to facilitate inserting records.
		Define unique constraint to avoid repeating usernames.
		Define a check constraint to ensure the password is at least 5 characters long  ******/
CREATE TABLE [TelerikAcademy].[dbo].[Users] (
	UserID int IDENTITY PRIMARY KEY,
	UserName nvarchar(100) NOT NULL UNIQUE,
	[Password] nvarchar(100) NOT NULL CHECK (LEN([Password]) > 5),
	FullName nvarchar(100) NOT NULL,
	LastLogin datetime NOT NULL
 )

/****** Task 16. Write a SQL statement to create a view that displays the users from the 
		 Users table that have been in the system today. Test if the view works correctly.  ******/
CREATE VIEW [Users from today] AS 
SELECT *
FROM [TelerikAcademy].[dbo].[Users] e
WHERE DAY(e.[LastLogin]) = DAY(GETDATE())

/****** Task 17. Write a SQL statement to create a table Groups.
		Groups should have unique name (use unique constraint).
		Define primary key and identity column.  ******/
CREATE TABLE [TelerikAcademy].[dbo].[Groups] (
	GroupID int IDENTITY PRIMARY KEY,
	Name nvarchar(100) UNIQUE
)

/****** Task 18. Write a SQL statement to add a column GroupID to the table Users.
		 Fill some data in this new column and as well in the Groups table. 
	 	 Write a SQL statement to add a foreign key constraint 
		 between tables Users and Groups tables.  ******/
ALTER TABLE [TelerikAcademy].[dbo].[Users] 
	ADD GroupID int
ALTER TABLE [TelerikAcademy].[dbo].[Users] 
	ADD CONSTRAINT FK_Users_Group FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)

/****** Task 19. Write SQL statements to insert several records in the Users and Groups tables.  ******/
INSERT INTO [TelerikAcademy].[dbo].[Groups] ([Name])
VALUES ('Africa')

INSERT INTO [TelerikAcademy].[dbo].[Users] ([UserName],[Password],[FullName],[LastLogin],[GroupID])
VALUES ('LaLaDala', '789456','Penka Kineva', '20121120 09:57:00', 3)

INSERT INTO [TelerikAcademy].[dbo].[Users] ([UserName],[Password],[FullName],[LastLogin],[GroupID])
VALUES ('GaLaRazdala', '7894e56','Muncho Kunchev', '20141120 09:57:30', 1)

INSERT INTO [TelerikAcademy].[dbo].[Users] ([UserName],[Password],[FullName],[LastLogin],[GroupID])
VALUES ('VaLaRala', '78d9456','Kina Pesheva', '20141120 09:57:01', 2)

/****** Task 20. Write SQL statements to update some of the records in the Users and Groups tables.  ******/
UPDATE [TelerikAcademy].[dbo].[Groups]
SET [Name] = 'North America'
WHERE [Name] = 'Africa'

UPDATE [TelerikAcademy].[dbo].[Users] 
SET [Password] = 'qwerty'
WHERE [UserName] = 'hudson'

UPDATE [TelerikAcademy].[dbo].[Users]
SET [UserName] = 'qwerty'
WHERE [Password] = '654321'

/****** Task 21. Write SQL statements to delete some of the records from the Users and Groups tables.  ******/
DELETE FROM [TelerikAcademy].[dbo].[Users]
WHERE [Password] = '654321'
GO
DELETE FROM [TelerikAcademy].[dbo].[Users] 
WHERE [UserName] = 'LaLaDala'
GO
DELETE FROM [TelerikAcademy].[dbo].[Groups]
WHERE [Name] = 'North America'

/****** Task 22. Write SQL statements to insert in the Users table the names of all employees
		 from the Employees table. Combine the first and last names as a full name.
		 For username use the first letter of the first name + the last name (in lowercase).
		 Use the same for the password, and NULL for last login time.  ******/
INSERT INTO [TelerikAcademy].[dbo].[Users]([UserName],[Password],[FullName])
SELECT LOWER(SUBSTRING(e.[FirstName], 1, 1) + e.[LastName]),
	LOWER(SUBSTRING(e.[FirstName], 1, 1) + e.[LastName]),
	e.[FirstName]+ ' ' + e.[LastName]
FROM [TelerikAcademy].[dbo].[Employees] e

/****** Task 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.  ******/
UPDATE [TelerikAcademy].[dbo].[Users]
SET [Password] = NULL
WHERE [LastLogin] <= CAST('10.03.2010 00:00:00' AS smalldatetime)

/****** Task 24. Write a SQL statement that deletes all users without passwords (NULL password).  ******/
DELETE FROM [TelerikAcademy].[dbo].[Users]
WHERE [Password] = NULL

/****** Task 25. Write a SQL query to display the average employee salary by department and job title.  ******/
SELECT d.[Name] AS [Departament Name], e.[JobTitle] AS [JobTitle], AVG(e.[Salary]) AS AvaregeSalary
  FROM [TelerikAcademy].[dbo].[Employees] e
  JOIN [TelerikAcademy].[dbo].[Departments] d
	ON d.[DepartmentID] = e.[DepartmentID]
GROUP BY d.Name, e.[JobTitle]

/****** Task 26. Write a SQL query to display the minimal employee salary by department and
				 job title along with the name of some of the employees that take it.  ******/
SELECT d2.Name, e.JobTitle, e.FirstName + ' ' + e.LastName as Name, e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
JOIN [TelerikAcademy].[dbo].[Departments] d2 ON d2.DepartmentID = e.DepartmentID
WHERE e.Salary IN 
	(SELECT MIN(em.Salary)
FROM [TelerikAcademy].[dbo].[Employees] em
JOIN [TelerikAcademy].[dbo].[Departments] d on d.DepartmentID = em.DepartmentID
WHERE d2.DepartmentID = d.DepartmentID AND e.JobTitle = em.JobTitle
GROUP BY d.Name, em.JobTitle)

/****** Task 27. Write a SQL query to display the town where maximal number of employees work.  ******/
SELECT TOP 1 t.Name AS TownName, COUNT(*) AS [EmployeeCount]
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON a.[AddressID] = e.[AddressID]
	JOIN [TelerikAcademy].[dbo].[Towns] t
		ON a.[TownID] = t.[TownID]
GROUP BY  t.Name 
ORDER BY COUNT(*) DESC

/****** Task 28. Write a SQL query to display the number of managers from each town.  ******/
SELECT t.[Name] as Town, COUNT(e.[ManagerID]) AS ManagersCount
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Addresses] a 
		ON e.[AddressID] = a.[AddressID]
	JOIN [TelerikAcademy].[dbo].[Towns] t 	
		ON t.[TownID] = a.[TownID]
WHERE e.[EmployeeID] IN 
	(SELECT DISTINCT ManagerID
	 FROM [TelerikAcademy].[dbo].[Employees])
GROUP BY t.[Name]

/****** Task 29. Write a SQL to create table WorkHours to store work 
				 reports for each employee (employee id, date, task, hours, comments).
				 Don't forget to define identity, primary key and appropriate foreign key. 
				 Issue few SQL statements to insert, update and delete of some data in the table.
				 Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
				 For each change keep the old record data, the new record data and the
				 command (insert / update / delete).  ******/
-- I mess it up... :(
CREATE TABLE WorkHours (
	EmployeeID int PRIMARY KEY IDENTITY,
	[Date] datetime,
	Task nvarchar(100),
	[Hours] int,
	Comments nvarchar(200),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES [TelerikAcademy].[dbo].[Employees](EmployeeID)
)

INSERT INTO WorkHours(Date, Task, Hours)
VALUES (getdate(), 'Sample Task1', 23),
	(getdate(), 'Sample Task2', 3)

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Sample Task2'

CREATE TABLE WorkHoursLog(
	Id int IDENTITY PRIMARY KEY,
	OldRecord nvarchar(100) NOT NULL,
	NewRecord nvarchar(100) NOT NULL,
	Command nvarchar(10) NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES [TelerikAcademy].[dbo].[WorkHours](EmployeeID)
)

ALTER TRIGGER tr_WorkHoursInsert 
ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values(' ',
(SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment
	FROM Inserted),
'INSERT',
(SELECT EmployeeID FROM Inserted))
GO
ALTER TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
(SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Inserted),
'UPDATE',
(SELECT EmployeeID FROM Inserted))
GO
ALTER TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
' ',
'DELETE',
(SELECT EmployeeID FROM Deleted))
GO
INSERT INTO WorkHours([Date], Task, Hours, Comment)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')
DELETE FROM WorkHours
WHERE Task = 'Random task3'
UPDATE WorkHours
	SET Task = 'Random task12'
WHERE EmployeeID = 8

/****** Task 30. Start a database transaction, delete all employees from the 'Sales'
				 department along with all dependent records from the pother tables.
				 At the end rollback the transaction.  ******/
BEGIN TRAN
DELETE FROM [TelerikAcademy].[dbo].[Employees]
SELECT d.[Name]
FROM [TelerikAcademy].[dbo].[Employees] e
	JOIN [TelerikAcademy].[dbo].[Departments] d
		ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
	GROUP BY d.[Name]
ROLLBACK TRAN

/****** Task 31. Start a database transaction and drop the table EmployeesProjects.
				 Now how you could restore back the lost table data?  ******/
BEGIN TRAN
	DROP TABLE [TelerikAcademy].[dbo].[EmployeesProjects]
ROLLBACK TRAN

/****** Task 32. Find how to use temporary tables in SQL Server.
				 Using temporary tables backup all records from EmployeesProjects
				 and restore them back after dropping and re-creating the table.  ******/
CREATE TABLE #TemporaryTable(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)
INSERT INTO #TemporaryTable
	SELECT EmployeeID, ProjectID
	FROM [TelerikAcademy].[dbo].[EmployeesProjects]
DROP TABLE [TelerikAcademy].[dbo].[EmployeesProjects]

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES [TelerikAcademy].[dbo].[Employees](EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES [TelerikAcademy].[dbo].[Projects](ProjectID)
)
INSERT INTO EmployeesProjects
	SELECT EmployeeID, ProjectID
FROM #TemporaryTable