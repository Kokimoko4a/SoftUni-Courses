 SELECT TOP(5) c.Name, COUNT(*)
 FROM Reports AS r
 JOIN Categories AS c
 ON
 r.CategoryId = c.Id
 GROUP BY r.CategoryId,c.Name
 ORDER BY COUNT(*) DESC,c.Name




