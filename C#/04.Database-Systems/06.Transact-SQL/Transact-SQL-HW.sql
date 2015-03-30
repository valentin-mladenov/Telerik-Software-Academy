/****** TASK 1: Create a database with two tables: Persons(Id(PK), FirstName,
				LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
				Insert few records for testing. Write a stored procedure that
				selects the full names of all persons.  ******/

CREATE DATABASE [TransactSQL-HomeWork]
GO

USE [TransactSQL-HomeWork]
GO

CREATE TABLE [TransactSQL-HomeWork].[dbo].[Persons](
	PersonID int PRIMARY KEY IDENTITY,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	SSN int NOT NULL
)
GO

CREATE TABLE [TransactSQL-HomeWork].[dbo].[Accounts](
	AccountID int PRIMARY KEY IDENTITY,
	PersonID int FOREIGN KEY REFERENCES Persons(PersonID),
	Balance money
)
GO

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Persons] (FirstName, LastName, SSN)
VALUES ('Pencho', 'Penchev', 789456) 

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Persons] (FirstName, LastName, SSN)
VALUES ('Kumcho', 'Gunchev', 123569) 

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Persons] (FirstName, LastName, SSN)
VALUES ('Pesho', 'Denev', 845623) 
GO

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Accounts] (PersonID, Balance)
VALUES (1, 789456.23) 

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Accounts] (PersonID, Balance)
VALUES (2, 189456.23) 

INSERT INTO  [TransactSQL-HomeWork].[dbo].[Accounts] (PersonID, Balance)
VALUES (3, 489456.23) 
GO

CREATE PROCEDURE usp_SelectFullNamesOfAllPersons
AS
	SELECT p.[FirstName] + ' ' + p.[LastName] AS Name
	FROM [TransactSQL-HomeWork].[dbo].[Persons] p
GO

EXEC [TransactSQL-HomeWork].[dbo].[usp_SelectFullNamesOfAllPersons]
GO

/****** TASK 2: Create a stored procedure that accepts a number as a parameter and
				returns all persons who have more money in their accounts than the
				supplied number.  ******/

CREATE PROCEDURE usp_PersonsWithMoreMoneyThan(@Money money)
AS
	SELECT p.[FirstName] + ' ' + p.[LastName] AS Name, a.[Balance] AS Balance
	FROM [TransactSQL-HomeWork].[dbo].[Persons] p
	JOIN [TransactSQL-HomeWork].[dbo].[Accounts] a
		ON a.[PersonID] = p.[PersonID]
	WHERE a.[Balance] > @Money
	ORDER BY a.[Balance]
GO

EXEC [TransactSQL-HomeWork].[dbo].[usp_PersonsWithMoreMoneyThan] 200000
GO

/****** TASK 3: Create a function that accepts as parameters ñ sum,
				yearly interest rate and number of months. It should
				calculate and return the new sum. Write a SELECT to test
				whether the function works as expected.  ******/

CREATE FUNCTION fn_CalculateInterstForDuration
		(@Money money, @YearInterestRatePrecentage money, @Months money)
		RETURNS money
AS
	BEGIN
		DECLARE @Years money = @Months / 12
		DECLARE @Interest money = @Money * (@YearInterestRatePrecentage/100) * @Years
		DECLARE @ActualSum money = @Money + @Interest
		RETURN @ActualSum
	END
GO

SELECT [TransactSQL-HomeWork].[dbo].[fn_CalculateInterstForDuration] 
	(200000, 20, 15)
GO

/****** TASK 4: Create a stored procedure that uses the function from the
				previous example to give an interest to a person's account
				for one month. It should take the AccountId and the interest
				rate as parameters.  ******/

CREATE PROCEDURE usp_CalculateInterstForAccountPerMonth
	(@InterestRatePrecentage money, @AccountID int)
AS
	SELECT p.FirstName + ' ' + p.LastName AS FullName, 
		a.Balance, 
		[TransactSQL-HomeWork].[dbo].[fn_CalculateInterstForDuration]
		(a.Balance, @InterestRatePrecentage, 1) AS WithInterest
	FROM [TransactSQL-HomeWork].[dbo].[Persons] p
	JOIN [TransactSQL-HomeWork].[dbo].[Accounts] a
	ON p.[PersonID] = a.[PersonID]
	WHERE a.AccountID = @AccountID 
GO

EXEC [TransactSQL-HomeWork].[dbo].[usp_CalculateInterstForAccountPerMonth] 20, 2
GO

/****** TASK 5: Add two more stored procedures WithdrawMoney
				(AccountId, money) and DepositMoney (AccountId, money)
				that operate in transactions.  ******/
CREATE PROCEDURE usp_WithdrawMoney
	(@AccountID int, @Money money)
AS
	DECLARE @AfterWithdraw money
	BEGIN TRAN
	UPDATE [TransactSQL-HomeWork].[dbo].[Accounts]
	SET @AfterWithdraw = Balance - @Money,
		Balance = Balance - @Money
	WHERE AccountID = @AccountID
		IF (@AfterWithdraw < 0)
			ROLLBACK TRAN
		ELSE
			COMMIT TRAN
GO

CREATE PROCEDURE usp_DepositMoney
	(@AccountID int, @Money money)
AS
	BEGIN TRAN
		IF (@Money <= 0)
			ROLLBACK TRAN
		ELSE
			UPDATE [TransactSQL-HomeWork].[dbo].[Accounts]
			SET Balance = Balance + @Money
			WHERE AccountID = @AccountID		
			COMMIT TRAN
GO

EXEC [TransactSQL-HomeWork].[dbo].[usp_WithdrawMoney] 2, 3000
GO

EXEC [TransactSQL-HomeWork].[dbo].[usp_DepositMoney] 2, 3000
GO

/****** TASK 6: Create another table ñ Logs(LogID, AccountID, OldSum, NewSum).
				Add a trigger to the Accounts table that enters a new entry
				into the Logs table every time the sum on an account changes.  ******/
CREATE TABLE [TransactSQL-HomeWork].[dbo].[Logs] (
	LogID int IDENTITY PRIMARY KEY,
	AccountID int FOREIGN KEY REFERENCES Accounts(AccountID),
	OldSum money,
	NewSum money
)
GO

CREATE TRIGGER tr_TransactionLog 
	ON [TransactSQL-HomeWork].[dbo].[Accounts] FOR UPDATE
AS
	DECLARE @CorrectedID int;
	SET @CorrectedID = (
		SELECT AccountID 
		FROM Inserted)
	INSERT INTO [TransactSQL-HomeWork].[dbo].[Logs] 
	(AccountID, OldSum, NewSum)
	VALUES (@CorrectedID, 
			(SELECT Balance FROM Deleted),
			(SELECT Balance FROM Inserted))
GO

/****** TASK 7: Define a function in the database TelerikAcademy that returns
				all Employee's names (first or middle or last name) and all
				town's names that are comprised of given set of letters.
				Example 'oistmiahf' will return 'Sofia', 'Smith', Ö but not
				'Rob' and 'Guy'.  ******/
USE [TelerikAcademy]
GO

CREATE FUNCTION [dbo].fn_IsWordContainsLetters
	(@Word nvarchar(50), @Letters nvarchar(50))
	RETURNS bit
AS
BEGIN
	IF (@Word IS NULL)
		RETURN 0
	ELSE
	BEGIN
		DECLARE @Result bit, @Count int
		SET @Count = 1
		SET @Result = 1
		WHILE(@Count <= LEN(@Word))
		BEGIN
			IF (CHARINDEX(SUBSTRING(@Word, @Count, 1), @Letters) = 0)
			BEGIN
				SET @Result = 0
				BREAK
			END
			SET @Count = @Count + 1
		END		
	END
	RETURN @Result
END
GO

SELECT e.FirstName
FROM [TelerikAcademy].[dbo].Employees e
WHERE [dbo].fn_IsWordContainsLetters(e.FirstName, 'oistmiahf') = 1

SELECT e.MiddleName
FROM [TelerikAcademy].[dbo].Employees e
WHERE [dbo].fn_IsWordContainsLetters(e.MiddleName, 'oistmiahf') = 1 

SELECT e.LastName
FROM [TelerikAcademy].[dbo].Employees e
WHERE [dbo].fn_IsWordContainsLetters(e.LastName, 'oistmiahf') = 1

SELECT t.Name AS TownName
FROM [TelerikAcademy].[dbo].[Towns] t
WHERE [dbo].fn_IsWordContainsLetters(t.Name, 'oistmiahf') = 1

/****** TASK 8: Using database cursor write a T-SQL script that scans all
				employees and their addresses and prints all pairs of
				employees that live in the same town.  ******/
DECLARE employeesInSameTownCursor CURSOR READ_ONLY FOR
	SELECT e1.FirstName, e1.LastName, t1.Name AS Town, e2.FirstName, e2.LastName		
	FROM [TelerikAcademy].[dbo].[Employees] e1
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a1
		ON e1.AddressID = a1.AddressID
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t1
		ON t1.TownID = a1.TownID,
	[TelerikAcademy].[dbo].[Employees] e2
	JOIN [TelerikAcademy].[dbo].[Addresses] a2
		ON e2.AddressID = a2.AddressID
	JOIN [TelerikAcademy].[dbo].[Towns] t2
		ON t2.TownID = a2.TownID

OPEN employeesInSameTownCursor
DECLARE @e1fname NVARCHAR(50), @e1lname NVARCHAR(50), @e2fname NVARCHAR(50),
		 @e2lname NVARCHAR(50), @town NVARCHAR(50)
FETCH NEXT FROM employeesInSameTownCursor 
	 INTO @e1fname, @e1lname, @town, @e2fname, @e2lname

WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF (@e1fname = @e2fname)
		FETCH NEXT FROM employeesInSameTownCursor INTO @e1fname, @e1lname, @town, @e2fname, @e2lname
	ELSE
	BEGIN
		PRINT @e1fname + ' ' + @e1lname + ' is in pair with ' + @e2fname + ' ' + @e2lname +	' from town ' + @town
		FETCH NEXT FROM employeesInSameTownCursor 
				INTO @e1fname, @e1lname, @town, @e2fname, @e2lname
	END
END

CLOSE employeesInSameTownCursor
DEALLOCATE employeesInSameTownCursor

/****** TASK 9*: Write a T-SQL script that shows for each town a list of
				 all employees that live in it. Sample output:
				 Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
				 Ottawa -> Jose Saraiva ******/
DECLARE employeesInSameTownCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName +' '+ e.LastName AS EmployeeName, t.Name AS Town	
	FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t
		ON t.TownID = a.TownID
	ORDER BY t.Name
	

OPEN employeesInSameTownCursor
DECLARE @EmployeeName NVARCHAR(50), @Town NVARCHAR(50),
		@AllEmployees NVARCHAR(1000), @PrevousTown NVARCHAR(50)
FETCH NEXT FROM employeesInSameTownCursor INTO @EmployeeName, @Town

WHILE (@@FETCH_STATUS = 0)
BEGIN
	IF (@PrevousTown = @Town)
	BEGIN
		SET @AllEmployees = @AllEmployees + '; ' + @EmployeeName
	END
	ELSE
	BEGIN
		PRINT @PrevousTown + ' -> ' + @AllEmployees
		SET @PrevousTown = @Town
		SET @AllEmployees = @EmployeeName
	END
		
	FETCH NEXT FROM employeesInSameTownCursor INTO @EmployeeName, @Town	
END
PRINT @PrevousTown + ' -> ' + @AllEmployees

CLOSE employeesInSameTownCursor
DEALLOCATE employeesInSameTownCursor

/****** TASK 10: Define a .NET aggregate function StrConcat that takes as input a
				 sequence of strings and return a single string that consists of
				 the input strings separated by ','. For example the following 
				 SQL statement should return a single string: 
				 SELECT StrConcat(FirstName + ' ' + LastName)
				 FROM Employees ******/
--I just follow a tutorial, not 100% sure what i did. :)
USE TelerikAcademy
GO

sp_configure 'clr enabled', 1
GO

RECONFIGURE
GO

-- This file path works on my PC must be changed in order to work on other.
CREATE ASSEMBLY StrConcat
FROM 'E:\ƒŒ ”Ã≈Õ“»\TELERIK SOFT\Software Academy\Database-Systems\06.Transact-SQL\Transact-SQL-HW\StrConcat.dll'
GO

CREATE AGGREGATE StrConcat(@Input NVARCHAR(max))
	RETURNS NVARCHAR(max)
	EXTERNAL NAME StrConcat.Concatenate
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName) AS AllEmplyees
FROM Employees
GO