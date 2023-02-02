 SELECT CONCAT(c.FirstName,' ',c.LastName)
		AS FullName,
		a.Country,
		a.ZIP,
		CONCAT('$',MAX(cg.PriceForSingleCigar))
		AS CigarPrice
 FROM Clients AS c
 JOIN ClientsCigars AS cc
 ON
 c.Id = cc.ClientId
 JOIN Addresses AS a
 ON
 c.AddressId = a.Id
 JOIN Cigars AS cg
 ON
 cc.CigarId = cg.Id
 WHERE a.ZIP LIKE '[0-9][0-9][0-9][0-9][0-9]'
 GROUP BY c.Id,c.FirstName,c.LastName,a.ZIP,a.Country
 ORDER BY CONCAT(c.FirstName,c.LastName)