 CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(MAX))
 RETURNS INT
  AS
   BEGIN
    DECLARE @Count INT = 0

	SELECT @Count = COUNT(*) 
	FROM Clients AS c
	JOIN ClientsCigars AS cc
	ON
	c.Id = cc.ClientId
	WHERE c.FirstName = @name
	GROUP BY c.Id

	RETURN(@Count)
   END

   