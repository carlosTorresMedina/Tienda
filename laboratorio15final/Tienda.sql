create database Tienda

create table Clientes(
cliDocumento varchar(30) primary key,
cliNombre varchar(30) not null,
cliDireccion varchar(30) not null,
cliTelefono varchar(30) not null,
cliCorreo varchar(30) not null
) 

create table Vendedor (
venUsuario varchar(30) primary key,
venContrasena varchar(30) not null,
)

create table Facturas(
facNumero varchar(30)  primary key,
facFecha Date not null,
facCliente varchar(30) foreign key references Clientes(cliDocumento),
facValorTotal float not null,
facVendedor varchar(30) foreign key references Vendedor(venUsuario)
)


create table Productos(
proCodigo varchar(30) primary key,
proDescripcion varchar(200) not null,
proValor float not null,
proCantidad int not null

)

create table FacturaDetalle(
facNumero varchar(30) foreign key references Facturas(facNumero),
facProducto varchar(30) foreign key references Productos(proCodigo),
facCantidad int not null,
primary key(facNumero,facProducto)

)