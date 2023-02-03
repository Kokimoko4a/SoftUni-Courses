 CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
 RETURNS BIT
  AS
   BEGIN
   DECLARE @index INT = 1

   WHILE @index <=LEN(@word)
    BEGIN
	 
	 IF CHARINDEX(SUBSTRING(@word,@index,1),@setOfLetters) = 0
	  BEGIN

	  RETURN 0

	  END

	SET @index+=1

	END

	RETURN 1

   END

   SELECT dbo.ufn_IsWordComprised('pppp'	,'Guy')