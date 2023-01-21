/*whose department ID is 3 or 10, and the hire year is between 1995 and 2005 inclusive.*/
USE SoftUni

 SELECT [FirstName] 
  FROM Employees
   WHERE DepartmentID IN (3,10)
    AND YEAR(HireDate) BETWEEN 1995 AND 2005