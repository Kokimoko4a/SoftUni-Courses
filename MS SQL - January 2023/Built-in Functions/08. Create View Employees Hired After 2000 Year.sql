/*Create a SQL query that creates view "V_EmployeesHiredAfter2000" with the first and the last name for all employees, hired after the year 2000. */

USE SoftUni
GO
CREATE VIEW [V_EmployeesHiredAfter2000]

 AS
 (
	SELECT [FirstName]
	 ,[LastName]
	  FROM Employees
	   WHERE YEAR(HireDate) >2000
 )
 GO

 SELECT * FROM V_EmployeesHiredAfter2000