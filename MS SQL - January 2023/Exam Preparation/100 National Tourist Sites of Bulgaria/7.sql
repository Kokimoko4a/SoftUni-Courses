 SELECT l.Province
		,l.Municipality
		,l.Name
		AS [Location]
		,COUNT(*)
		AS CountOfSites
 FROM Sites AS s
 JOIN Locations AS l
 ON
 s.LocationId = l.Id
 WHERE l.Province = 'Sofia'
 GROUP BY l.Id,l.Province,l.Municipality,l.Name
 ORDER BY COUNT(*) DESC,l.Name