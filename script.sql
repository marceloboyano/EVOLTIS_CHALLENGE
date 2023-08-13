create database MyDataBase
go

use MyDataBase
go

CREATE TABLE Employee (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Email VARCHAR(320) NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL
);

insert into Employee (Name,LastName,Email,Salary)
VALUES 
('Marcelo','Boyanosky', 'marceloboyanosky@gmail.com','300000.00'),
('Juan','Perez', 'juan@gmail.com','150.00'),
('Pedro','Gonzalez', 'fra@gmail.com','44400.00')




