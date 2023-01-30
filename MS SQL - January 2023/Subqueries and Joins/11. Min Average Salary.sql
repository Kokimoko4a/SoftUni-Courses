USE SoftUni
 SELECT TOP(1) 
        Salary
		AS [MinAverageSalary]
        
 FROM
 (SELECT AVG(Salary) AS [Salary] 
 FROM [Employees]
 GROUP BY DepartmentID
 ) AS [Avg_Salary_By_Departments]
  ORDER BY Salary