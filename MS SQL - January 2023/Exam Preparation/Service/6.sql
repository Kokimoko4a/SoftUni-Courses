 SELECT Description,
		c.Name
 FROM Reports AS r
 JOIN Categories AS c
 ON
 r.CategoryId = c.Id
 ORDER BY r.Description,c.Name