CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50) NULL,
	Birthdate DATETIME NULL,
	Age INT CHECK(Age>=14 AND Age<=110) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(25) NULL,
	LastName VARCHAR(25) NULL,
	Birthdate DATETIME NULL,
	Age INT CHECK(Age>=18 AND Age <=110) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Label] VARCHAR(20) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME NULL,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)