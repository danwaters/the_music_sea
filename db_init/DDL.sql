drop table if exists OrderItem;
drop table if exists ItemCategory;
drop table if exists Item;
drop table if exists Category;
drop table if exists CustomerOrder;
drop table if exists OrderStatus;
drop table if exists Customer;
drop table if exists SalesEngineer;
drop table if exists Department;

create table Department (
    ID int not null auto_increment,
    Name varchar (20),
    Description varchar(50),

    primary key (ID)
);

create table SalesEngineer (
    ID int not null auto_increment,
    FirstName varchar(25),
    LastName varchar(25),
    Email varchar(50),
    Phone varchar(20),
    SpecialtyDepartmentID int not null,
    PhotoURI varchar(255),

    primary key (ID),

    foreign key (SpecialtyDepartmentID)
        references Department(ID)
        on delete cascade
        on update cascade
);

create table Customer (
    ID int not null auto_increment,
    FirstName varchar(25),
    LastName varchar(25),
    Email varchar(50),
    Phone varchar(20),
    AddressLine1 varchar(20),
    AddressLine2 varchar(20),
    City varchar(20),
    StateProvince varchar(20),
    Country varchar(20),
	SalesEngineerID int not null,
    
    primary key (ID),
    
    foreign key (SalesEngineerID)
		references SalesEngineer(ID)
        on delete restrict
        on update cascade
);

create table OrderStatus (
    ID int not null auto_increment,
    Status varchar(10),

    primary key (ID)
);

create table CustomerOrder (
    ID int not null auto_increment,
    CustomerID int not null,
    SalesEngineerID int not null,
    PlacedDate datetime,
    ShippedDate datetime,
    OrderStatusID int not null,
    Subtotal decimal(7, 2),
    Tax decimal(7, 2),
    Total decimal(7, 2),
    TrackingCode varchar(30),

    primary key (ID),
    foreign key (OrderStatusID)
        references OrderStatus(ID)
        on delete restrict
        on update cascade,
        
	foreign key (CustomerID)
		references Customer(ID)
        on delete restrict
		on update cascade,
        
	foreign key (SalesEngineerID)
		references SalesEngineer(ID)
        on delete no action
        on update cascade
);

create table Category (
    ID int not null auto_increment,
    Name varchar(40),

    primary key(ID)
);

create table Item (
    ID int not null auto_increment,
    SKU varchar(20),
    Name varchar(100),
    Description varchar(255),
    MSRP decimal(7, 2),
    Price decimal(7, 2),
    PhotoURI varchar(255),
    InventoryCount int,

    DepartmentID int not null,

    primary key (ID),

    foreign key (DepartmentID)
        references Department(ID)
        on delete restrict
        on update cascade
);

create table ItemCategory (
    ID int not null auto_increment,
    ItemID int not null,
    CategoryID int not null,

    primary key (ID),

    foreign key (ItemID)
        references Item(ID)
        on delete cascade
        on update cascade,

    foreign key (CategoryID)
        references Category(ID)
        on delete cascade
        on update cascade
);

create table OrderItem (
    ID int not null auto_increment,
    OrderID int not null,
    ItemID int not null,
    Quantity int not null,

    primary key(ID),

    foreign key (OrderID)
        references CustomerOrder(ID)
        on delete cascade
        on update cascade,

    foreign key (ItemID)
        references Item(ID)
        on delete cascade
        on update cascade
);
