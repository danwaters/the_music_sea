delete from Department where true;
insert into Department (Name, Description) VALUES ("Guitars", "Acoustic and electric guitars, banjos, and others");
insert into Department (Name, Description) VALUES ("Bass Guitars", "Acoustic and electric bass guitars");
insert into Department (Name, Description) VALUES ("Drums and Percussion", "Drums, cymbals, hardware and percussion");
insert into Department (Name, Description) VALUES ("Keyboards", "Pianos and keyboards");
insert into Department (Name, Description) VALUES ("Pro Audio", "Interfaces, DJ equipment, mixers, and more");

delete from Category where true;
insert into Category (Name) VALUES ("6-String Electric Guitars");
insert into Category (Name) VALUES ("7-String Electric Guitars");
insert into Category (Name) VALUES ("6-String Acoustic Guitars");
insert into Category (Name) VALUES ("Ukeleles");
insert into Category (Name) VALUES ("4-String Bass Guitars");
insert into Category (Name) VALUES ("5-String Bass Guitars");
insert into Category (Name) VALUES ("Acoustic Bass Guitars");

delete from SalesEngineer where true;
insert into SalesEngineer (FirstName, LastName, Email, Phone, SpecialtyDepartmentID, PhotoURI)
	VALUES('Dan', 'Waters', 'danwaters@my.unt.edu', '469-993-3300', 1, 'dan_hs.jpg');