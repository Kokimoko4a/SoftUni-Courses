 CREATE OR ALTER PROC usp_GetEmployeesFromTown @TownName VARCHAR(MAX)
 AS

 SELECT FirstName
		AS [First Name]
		,LastName
		AS [Last Name]
 FROM Employees AS e
 JOIN Addresses AS a
 ON
 e.AddressID = a.AddressID
 JOIN Towns AS t
 ON a.TownID = t.TownID 
 WHERE t.Name = @TownName

 EXEC usp_GetEmployeesFromTown 'Sofia'