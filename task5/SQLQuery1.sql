create database CafeteriaDB;

create table Categorie(
ID int primary key IDENTITY(1,1),
Name varchar(50) not null,
Description varchar(250) 
);

create table Supplier(
ID int primary key IDENTITY(1,1),
Name varchar(50) not null,
Email varchar(150) not null unique,
Phone int not null
);

create table Product(
ID int primary key IDENTITY(1,1),
Name varchar(50) not null,
Price DECIMAL not null,
Quantity decimal not null,
CategoryId int foreign key references  Categorie(id),
SupplierId int foreign key references Supplier(id)
);
create table PurchaseOrders(
ID int primary key IDENTITY(1,1),
OrderDate DATETIME not null,
Status varchar(50) not null,
SupplierId int foreign key references Supplier(id)
);
create table PurchaseOrderItems(
ID int primary key IDENTITY(1,1),
PurchaseOrderId int foreign key references  PurchaseOrders(id),
ProductId int foreign key references Product(id),
Quantity decimal not null,
UnitPrice DECIMAL not null,
);

