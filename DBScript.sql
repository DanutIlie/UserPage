create database [UsersLibrary]

create table[Users]
(
[Id] [int] primary key identity (1,1) not null,
[FirstName] [varchar] (50) ,
[LastName] [varchar] (50),
[Gender] [varchar] (50),
[DateOfBirth] [varchar] (50),
[ImageName] [varchar] (50)
)
