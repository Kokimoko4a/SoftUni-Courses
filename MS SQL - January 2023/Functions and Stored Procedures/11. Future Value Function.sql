 CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,4), @YearlyInterestRate FLOAT,@NumberOfYears INT)
 RETURNS DECIMAL(18,4)
 AS
  BEGIN
  RETURN @Sum*POWER(1+@YearlyInterestRate,@NumberOfYears)
  END