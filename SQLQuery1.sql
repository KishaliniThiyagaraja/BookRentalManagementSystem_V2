create database BookManagement;

use BookManagement;

create table Books(
	BookId nvarchar primary key(10),
	Title nvarchar(50),
	Author nvarchar(50),
	RentalPrice decimal(10,2)
);