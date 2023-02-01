 CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
 RETURNS VARCHAR(10)
 AS
 BEGIN
  DECLARE @Output VARCHAR(10) = 'Average' 
  IF @salary < 30000
   BEGIN
   SET @Output = 'Low'
   END

  ELSE IF @salary > 50000
   BEGIN
    SET @Output = 'High'
   END

   RETURN @Output
 END

 SELECT Salary,dbo.ufn_GetSalaryLevel(Salary) FROM Employees