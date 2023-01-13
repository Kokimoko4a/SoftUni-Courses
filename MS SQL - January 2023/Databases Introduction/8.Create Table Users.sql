/*•	Id – unique number for every user. There will be no more than 263-1 users (auto incremented).
•	Username – unique identifier of the user. It will be no more than 30 characters (non Unicode)  (required).
•	Password – password will be no longer than 26 characters (non Unicode) (required).
•	ProfilePicture – image with size up to 900 KB. 
•	LastLoginTime
•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
Make the Id a primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.
*/

CREATE TABLE Users(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT,
)

INSERT INTO Users VALUES
('A','DDDD',NULL,01-01-2023,1),
('A','DDDD',NULL,01-01-2023,1),
('A','DDDD',NULL,01-01-2023,1),
('A','DDDD',NULL,01-01-2023,1),
('A','DDDD',NULL,01-01-2023,1)



