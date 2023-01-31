 SELECT s.Name
		AS Site
		,l.Name
		AS Location
		,l.Municipality
		,l.Province
		,s.Establishment
 FROM Sites AS s
 JOIN Locations AS l
 ON
 s.LocationId = l.Id
 WHERE LEFT(s.Name,1) != 'B'
 AND LEFT(s.Name,1) !='M'
 AND LEFT(s.Name,1) !='D' 
 AND s.Establishment LIKE '%BC%'
 ORDER BY s.Name