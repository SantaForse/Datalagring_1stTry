CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	PostalCode char (6) not null,
	City nvarchar (100) not null
)
GO

CREATE TABLE Customers (
	Id uniqueidentifier not null primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(100) not null unique,
	PhoneNumber char(13) null,

	AddressId int not null references Addresses(Id)
)
GO

INSERT INTO Addresses VALUES
	('Rålambsvägen 3', '234 34', 'Stockholm'),
	('Rålambsvägen 16', '234 32', 'Stockholm'),
	('Rålambsvägen 78', '234 98', 'Stockholm')
GO

INSERT INTO Customers VALUES 
	('b311e882-84f4-4b60-8ce9-597a1307662e', 'Santa', 'Forsell', 'santaforsell@domain.com', '098 876 76 89', 1),
	('6af9e3de-1b01-4d5c-8768-62f80589db95', 'Luna', 'Forsell', 'jesperforsell@domain.com', '765 987 23 23', 1),
	('804b070d-dceb-4647-a311-8a9cfc3ac035', 'Sven', 'Svensson', 'svensvernsson@domain.com', '875 435 72 34', 2)
GO