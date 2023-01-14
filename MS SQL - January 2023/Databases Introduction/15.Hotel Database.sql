CREATE DATABASE Hotel

/*•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
•	RoomStatus (RoomStatus, Notes)
•	RoomTypes (RoomType, Notes)
•	BedTypes (BedType, Notes)
•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
*/
USE Hotel

CREATE TABLE Employees(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Title VARCHAR(50),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers(
	AccountNumber VARCHAR(34)  PRIMARY KEY ,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	PhoneNumber CHAR(10),
	EmergencyName VARCHAR(50),
	EmergencyNumber CHAR(10),
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus(
	RoomStatus VARCHAR(50) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes(
	RoomType VARCHAR(30) NOT NULL PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes(
	BedType VARCHAR(30) NOT NULL PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms(
	RoomNumber INT IDENTITY NOT NULL PRIMARY KEY,
	RoomType VARCHAR(30) NOT NULL,
	BedType VARCHAR(30) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
CREATE TABLE Payments(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME,
	AccountNumber CHAR(10) NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL NOT NULL,
	TaxRate DECIMAL,
	TaxAmount DECIMAL,
	PaymentTotal DECIMAL,
	Notes VARCHAR(MAX),
)

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE Occupancies(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber VARCHAR(34) NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL NOT NULL,
	Notes VARCHAR(MAX)
)

/*	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
•	RoomStatus (RoomStatus, Notes)
•	RoomTypes (RoomType, Notes)
•	BedTypes (BedType, Notes)
•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)*/

INSERT INTO Employees VALUES
('Kaloyan','Rusev','ff','dd'),
('Kaloyan','Rusev','ff','dd'),
('Kaloyan','Rusev','ff','dd')

INSERT INTO Customers VALUES
('WDK46ONGF8','Kaloyan','Rusev','0877077806','SalihOnFire','0877077806',NULL),
('WDK46ONGK8','Kaloyan','Rusev','0877077806','SalihOnFire','0877077806',NULL),
('WDK46ONGL8','Kaloyan','Rusev','0877077806','SalihOnFire','0877077806',NULL)

INSERT INTO RoomStatus VALUES
('LLL','MNOGO YAKO'),
('LLK','MNOGO YAKO'),
('LLG','MNOGO YAKO')

INSERT INTO RoomTypes VALUES
('Apartmnet','golqm'),
('Studio',' malko po-negolqm'),
('Baraka','malko po-ne golqma ot malko po-negolqmata')

INSERT INTO BedTypes VALUES	
('CARSKO','CARSKO E'),
('NECARSKO','NE CARSKO E'),
('SELSKO','SELSKO E')

INSERT INTO Rooms VALUES
('DDD','F',1,'DDD','DDD'),
('DDD','F',1,'DDD','DDD'),
('DDD','F',1,'DDD','DDD')

INSERT INTO Payments VALUES
(1,01-01-2021,'FFFFFFFFFF',01-01-2000,01-01-1999,1,1.2,1.1,1,1,NULL),
(1,01-01-2021,'FFFFFFFFFF',01-01-2000,01-01-1999,1,1.2,1.1,1,1,NULL),
(1,01-01-2021,'FFFFFFFFFF',01-01-2000,01-01-1999,1,1.2,1.1,1,1,NULL)

INSERT INTO Occupancies VALUES
(1,01-01-2020,'JJJJJJ',12,1,1,NULL),
(1,01-01-2020,'JJJJJJ',12,1,1,NULL),
(1,01-01-2020,'JJJJJJ',12,1,1,NULL)

SELECT * FROM Occupancies