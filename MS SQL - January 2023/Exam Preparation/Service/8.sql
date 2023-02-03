 SELECT u.Username
		,c.Name
 FROM Users AS u
 JOIN Reports AS r
 ON
 u.Id = r.UserId
 JOIN Categories AS c
 ON
 r.CategoryId = c.Id
 WHERE DATEPART(MONTH,r.OpenDate) = DATEPART(MONTH,u.Birthdate) AND
 DATEPART(DAY,r.OpenDate) = DATEPART(DAY,u.Birthdate)
 ORDER BY u.Username,c.Name