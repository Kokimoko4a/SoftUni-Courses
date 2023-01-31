 SELECT SUM(w1.DepositAmount - w2.DepositAmount)
		AS [Difference]
 FROM WizzardDeposits AS w1
 JOIN WizzardDeposits AS w2
 ON
 w1.Id + 1 = w2.Id
 