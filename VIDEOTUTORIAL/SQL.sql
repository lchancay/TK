
create table Empresa(
IdEmpresa int primary key,
nombre varchar(50)
)
go
create table Departamento(
IdEmpresa int references Empresa,
IdDepartameto int,
nombre varchar(50),
primary key (IdEmpresa,IdDepartameto)
)
go
create table Empleado(
IdEmpresa int references Empresa,
IdEmpleado int,
nombre varchar(50),
primary key (IdEmpresa,IdEmpleado)
)
go
create table Usuario(
IdEmpresa int references Empresa,
IdUsuario int,
IdDepartamento int ,
IdEmpleado int ,
nombre varchar(50),
foreign key (IdEmpresa,IdDepartamento) references Departamento,
foreign key (IdEmpresa,IdEmpleado) references Empleado,
primary key (IdEmpresa,IdUsuario)
)







