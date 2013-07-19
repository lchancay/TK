create database prueba
go
use prueba
go
create schema seguridad
go
create table seguridad.genero(
codigo int primary key,
nombre varchar(50)
)
go
create table seguridad.persona(
codigo varchar(5) primary key,
nombre varchar(20)not null,
apellido varchar(20) not null,
genero int references seguridad.genero,
fechaNacimiento date,
telefono varchar(20)
)
go










