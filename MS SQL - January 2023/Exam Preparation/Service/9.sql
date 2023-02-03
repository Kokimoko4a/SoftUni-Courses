 SELECT  CONCAT(e.FirstName,' ',e.LastName)
		AS FullName
		,COUNT(r.UserId)
		AS UsersCount
 FROM Reports AS r 
 RIGHT JOIN Employees AS e
 ON
 r.EmployeeId = e.Id
 GROUP BY CONCAT(e.FirstName,' ',e.LastName) 
 ORDER BY UsersCount DESC,FullName

