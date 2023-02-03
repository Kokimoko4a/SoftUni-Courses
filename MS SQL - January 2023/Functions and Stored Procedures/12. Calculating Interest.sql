 CREATE OR ALTER PROC usp_CalculateFutureValueForAccount @acountId INT, @interest DECIMAL(18,4)
  AS
   BEGIN
   SELECT a.Id
		AS [Account Id]
		,ah.FirstName,
		ah.LastName,
		a.Balance,
		dbo.ufn_CalculateFutureValue(a.Balance,@interest,5) AS J
   FROM Accounts AS a
   JOIN AccountHolders AS ah
   ON
   a.AccountHolderId = ah.Id
   WHERE a.Id = @acountId
   END

   EXEC dbo.usp_CalculateFutureValueForAccount 1,0.1