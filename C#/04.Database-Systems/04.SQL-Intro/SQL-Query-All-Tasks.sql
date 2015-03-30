/****** Task4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).   ******/
SELECT * 
  FROM [TelerikAcademy].[dbo].[Departments];

/****** Task 5. Write a SQL query to find all department names.   ******/
SELECT d.[Name] 
  FROM [TelerikAcademy].[dbo].[Departments] d

/****** Task 6. Write a SQL query to find the salary of each employee. ******/
SELECT e.[Salary] 
  FROM [TelerikAcademy].[dbo].[Employees] e

/****** Task 7. Write a SQL to find the full name of each employee. ******/
SELECT e.[FirstName] + ' ' + e.[MiddleName] + ' ' + e.[LastName] AS Name
  FROM [TelerikAcademy].[dbo].[Employees] e
  WHERE e.[MiddleName] IS NOT NULL
  UNION
  SELECT e.[FirstName] + ' ' + e.[LastName] AS Name
  FROM [TelerikAcademy].[dbo].[Employees] e
  WHERE e.[MiddleName] IS NULL

/****** Task 8. Write a SQL query to find the email addresses of each employee (by his first and last name).
		Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
		The produced column should be named "Full Email Addresses". ******/
SELECT e.[FirstName] + '.' + e.[LastName] + '@telerik.com' AS [Full Email Addresses]
  FROM [TelerikAcademy].[dbo].[Employees] e

/****** Task 9. Write a SQL query to find all different employee salaries". ******/
SELECT 
	DISTINCT e.[Salary]
FROM [TelerikAcademy].[dbo].[Employees] e

/****** Task 10. Write a SQL query to find all information about the employees whose job title is “Sales Representative". ******/
SELECT * FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[JobTitle] = 'Sales Representative'

/****** Task 11. Write a SQL query to find the names of all employees whose first name starts with "SA". ******/
SELECT *
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[FirstName] LIKE 'SA%'

/****** Task 12. Write a SQL query to find the names of all employees whose last name contains "ei". ******/
SELECT *
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[LastName] LIKE '%ei%'

/****** Task 13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS Name, e.[Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[Salary] BETWEEN 20000 AND 30000

/****** Task 14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS Name, e.[Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE (e.[Salary] = 25000 OR e.[Salary] = 14000 OR e.[Salary] = 12500 OR e.[Salary] = 23600)
	ORDER BY e.Salary

/****** Task 15. Write a SQL query to find all employees that do not have manager. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS Name
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[ManagerID] IS NULL

/****** Task 16. Write a SQL query to find all employees that have salary more than 50000.
		 Order them in decreasing order by salary. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS Name, e.[Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
	WHERE e.[Salary] > 50000
	ORDER BY e.[Salary] DESC

/****** Task 17. Write a SQL query to find the top 5 best paid employees. ******/
SELECT TOP 5 e.[FirstName] + ' ' + e.[LastName] AS Name, e.[Salary]
	FROM [TelerikAcademy].[dbo].[Employees] e
	ORDER BY e.[Salary] DESC

/****** Task 18. Write a SQL query to find all employees along with their address. Use inner join with ON clause. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [FullName], a.[AddressText] AS [Address]
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON e.[AddressID] = a.[AddressID]

/****** Task 19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [FullName], a.[AddressText] AS [Address]
	FROM [TelerikAcademy].[dbo].[Employees] e, [TelerikAcademy].[dbo].[Addresses] a
	WHERE e.[AddressID] = a.[AddressID]

/****** Task 20. Write a SQL query to find all employees along with their manager. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS  [ManagerName]
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]

/****** Task 21. Write a SQL query to find all employees, along with their manager and their address.
		Join the 3 tables: Employees e, Employees m and Addresses a. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName],
		 m.[FirstName] + ' ' + m.[LastName] AS  [ManagerName],
		 a.[AddressText] AS [Address]
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]
			INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON e.[AddressID] = a.[AddressID]

/****** Task 22. Write a SQL query to find all departments and all town names as a single list. Use UNION. ******/
SELECT d.[Name]
	FROM [TelerikAcademy].[dbo].[Departments] d
	UNION
SELECT t.[Name] 
	FROM [TelerikAcademy].[dbo].[Towns] t

/****** Task 23. Write a SQL query to find all the employees and the manager for each of them
		along with the employees that do not have manager. Use right outer join.
		Rewrite the query to use left outer join. ******/

--RIGHT OUTER JOIN.
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS  [ManagerName]
	FROM [TelerikAcademy].[dbo].[Employees] e
		RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]

--LEFT OUTER JOIN
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS  [ManagerName]
	FROM [TelerikAcademy].[dbo].[Employees] e
		LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.[ManagerID] = m.[EmployeeID]

/****** Task 24. Write a SQL query to find the names of all employees from the departments 
		"Sales" and "Finance" whose hire year is between 1995 and 2005. ******/
SELECT e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName],
		d.[Name] AS  [DepartamentName],
		e.[HireDate]
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.[DepartmentID] = d.[DepartmentID]
	WHERE (d.[Name] = 'Sales' OR d.[Name] = 'Finance') AND 
	(YEAR(e.[HireDate]) > 1995 	AND YEAR(e.[HireDate]) < 2005)

--Little tricky that last one.