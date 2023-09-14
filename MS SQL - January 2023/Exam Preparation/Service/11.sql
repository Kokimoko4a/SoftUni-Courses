 CREATE OR ALTER  FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) RETURNS INT
 AS
  BEGIN
   IF @StartDate IS NULL
    BEGIN
	 RETURN 0
	END

	ELSE IF @EndDate IS NULL
	 BEGIN
	  RETURN 0
	END
		
      DECLARE @DAYS INT = CONVERT(INT,@ENDDATE - @STARTDATE)
      RETURN 24*@DAYS
  END