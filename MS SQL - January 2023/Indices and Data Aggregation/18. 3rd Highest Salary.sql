 SELECT DISTINCT
        DepartmentID
        ,Salary
		AS ThirdHighestSalary
 FROM(
 SELECT  
       DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC ) AS RANK
        ,Salary
		,DepartmentID
 FROM(
 SELECT DepartmentID
	   ,Salary
	   ,EmployeeID
 FROM Employees
 ) AS Selecting_Employees_Sub) 
 AS Ranking_Sub
 WHERE RANK = 3 
 ORDER BY DepartmentID