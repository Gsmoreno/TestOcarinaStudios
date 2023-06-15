create database OcarinaTest;

use OcarinaTest;

create table Users(
		IdUser int primary key identity,
		Name varchar(255) NOT NULL,
		Email varchar (255) NOT NULL UNIQUE,
		Password varchar(35) NOT NULL,
		CaloriesDay varchar(255) NOT NULL,
		IdTypeUser int foreign key references TypeUsers(IdTypeUser)
);

create table TypeUsers(
		IdTypeUser int primary key identity,
		Role VARCHAR(255)
);

create table Exercise(
		IdExercise int primary key identity,
		Name VARCHAR(255) NOT NULL,
		Finished DateTime, 
		CaloriesBurned int,
		IdUser int foreign key references Users(IdUser)
);

DROP TABLE TypeUsers;


INSERT INTO Users(Name, Email, Password, CaloriesDay, IdTypeUser)
VALUES('Alexandre', 'alexandre@gmail.com', 'ale123', '300', 2);

INSERT INTO TypeUsers(Role)
VALUES('Normal');




