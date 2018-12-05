use master
go
if exists(select * from sysdatabases  where name = 'Hotel')
DROP DATABASE Hotel
GO

create database Hotel
go

use Hotel
GO

create table TB_USUARIO(
	CODIGO_USUARIO int identity(1,1) primary key,
	NOMBRE_USUARIO varchar(25),
	CORREO_USUARIO VARCHAR(100),
	PASSWORD_USUARIO VARBINARY(50),
	DIRECCION_USUARIO VARCHAR(100),
	TELEFONO_USUARIO VARCHAR(11)
)
go

SELECT * FROM TB_USUARIO
GO

create proc sp_AgregarUsuario(@nombre varchar(25),@correo varchar(100),
@password char(8),@direccion VARCHAR(100),@telefono VARCHAR(11))
as
begin
	insert into TB_USUARIO (NOMBRE_USUARIO,CORREO_USUARIO,PASSWORD_USUARIO
	,DIRECCION_USUARIO,TELEFONO_USUARIO) values (@nombre,@correo,cast(@password as varbinary(50)),@direccion,@telefono)
end
go

exec sp_AgregarUsuario 'Adrian','adrian@gmail.com','12345678',null,null
go

create proc sp_Login(@correo varchar(100),@password char(8))
as
begin
	select CODIGO_USUARIO,NOMBRE_USUARIO,CORREO_USUARIO,DIRECCION_USUARIO,TELEFONO_USUARIO
	from TB_USUARIO
	where CORREO_USUARIO = @correo and PASSWORD_USUARIO = cast(@password as varbinary(50))
end
go

EXEC sp_Login 'adrian@gmail.com','12345678'
GO




create table TB_EMPLEADO(
	CODIGO_EMPLEADO int identity(1,1) primary key,
	NOMBRE_EMPLEADO varchar(25),
	APELLIDOS_EMPLEADO varchar(50),
	DNI_EMPLEADO VARCHAR(8),
	CARGO_EMPLEADO VARCHAR(50),
	DIRECCION_EMPLEADO VARCHAR(100),
	TELEFONO_EMPLEADO VARCHAR(11)
)
go

SELECT * FROM TB_EMPLEADO
GO

create proc sp_LoginEmpleado(@nombre varchar(25),@dni varchar(8))
as
begin
	select CODIGO_EMPLEADO,NOMBRE_EMPLEADO,CARGO_EMPLEADO
	from TB_EMPLEADO
	where NOMBRE_EMPLEADO = @nombre and DNI_EMPLEADO = @dni 
end
go

EXEC sp_Login 'adrian@gmail.com','12345678'
GO

create proc sp_AgregarEmpleado(@nombre varchar(25),@apellidos varchar(50),
@dni VARCHAR(8),@cargo varchar(50),
@direccion VARCHAR(100),@telefono VARCHAR(11))
as
begin
	insert into TB_EMPLEADO(NOMBRE_EMPLEADO,APELLIDOS_EMPLEADO,
	DNI_EMPLEADO,CARGO_EMPLEADO,
	DIRECCION_EMPLEADO,TELEFONO_EMPLEADO) values (@nombre,@apellidos,@dni,@cargo
	,@direccion,@telefono)
end
go

exec sp_AgregarEmpleado 'Adrian','Matos','99999999','administrador',null,null
go

create proc sp_ActualizarEmpleado(@id int,@nombre varchar(25),@apellidos varchar(50),
@dni VARCHAR(8),@cargo varchar(50),
@direccion VARCHAR(100),@telefono VARCHAR(11))
as
begin
	update TB_EMPLEADO set NOMBRE_EMPLEADO = @nombre,
	APELLIDOS_EMPLEADO = @apellidos,DNI_EMPLEADO = @dni,
	CARGO_EMPLEADO = @cargo,
	DIRECCION_EMPLEADO = @direccion,TELEFONO_EMPLEADO=@telefono
	 where CODIGO_EMPLEADO = @id
end
go

exec sp_ActualizarEmpleado 1,'Adrian','Matos','99999999','administrador',null,null
go

create proc sp_EliminarEmpleado(@id int)
as
begin
	delete from TB_EMPLEADO where CODIGO_EMPLEADO = @id
end
go

EXEC sp_EliminarEmpleado 1
GO


create proc sp_ListarEmpleadoXDni(@dni varchar(8))
as
begin
	select CODIGO_EMPLEADO,NOMBRE_EMPLEADO,APELLIDOS_EMPLEADO,DNI_EMPLEADO,CARGO_EMPLEADO,
	DIRECCION_EMPLEADO,TELEFONO_EMPLEADO from TB_EMPLEADO 
	where DNI_EMPLEADO  like @dni+'%'
end
go

EXEC sp_ListarEmpleadoXDni '9'
GO


create proc sp_ListarEmpleadoXId(@id int)
as
begin
	select CODIGO_EMPLEADO,NOMBRE_EMPLEADO,APELLIDOS_EMPLEADO,DNI_EMPLEADO,CARGO_EMPLEADO,
	DIRECCION_EMPLEADO,TELEFONO_EMPLEADO from TB_EMPLEADO 	
	where CODIGO_EMPLEADO = @id
end
go


create table TB_HABITACION(
	CODIGO_HABITACION int identity(1,1) primary key,
	DESCRIPCION_HABITACION varchar(250),
	ESTADO_HABITACION varchar(50),
	HUESPEDES_HABITACION INT,
	IMAGEN_HABITACION VARCHAR(500),
	PRECIO_HABITACION DECIMAL(10,2)
)
go

SELECT * FROM TB_HABITACION
GO


create proc sp_ListarHabitacion
as
begin
	select CODIGO_HABITACION,DESCRIPCION_HABITACION,ESTADO_HABITACION,PRECIO_HABITACION 
	from TB_HABITACION
end
go

create proc sp_ListarHabitacionXId(@id int)
as
begin
	select CODIGO_HABITACION,DESCRIPCION_HABITACION,
	ESTADO_HABITACION,
	HUESPEDES_HABITACION,
	IMAGEN_HABITACION ,
	PRECIO_HABITACION 
	from TB_HABITACION where CODIGO_HABITACION = @id
end
go



create proc sp_AgregarHabitacion(@descripcion varchar(250),
	@huespedes INT,
	@imagen VARCHAR(500),@precio decimal (10,2))
as
begin

	insert into TB_HABITACION(DESCRIPCION_HABITACION,ESTADO_HABITACION,
	HUESPEDES_HABITACION,IMAGEN_HABITACION,PRECIO_HABITACION) 
	values (@descripcion ,
	'Libre',
	@huespedes ,
	@imagen,@precio )
end
go

exec sp_AgregarHabitacion 'descripcion',2,null,1200
go

create proc sp_ActualizarHabitacion(@id int,@descripcion varchar(250),
	
	@huespedes INT,
	@imagen VARCHAR(500),@precio decimal (10,2))
as
begin
	update TB_HABITACION set DESCRIPCION_HABITACION = @descripcion,
	HUESPEDES_HABITACION = @huespedes,
	IMAGEN_HABITACION=@imagen,PRECIO_HABITACION = @precio
	 where CODIGO_HABITACION = @id
end
go

exec sp_ActualizarHabitacion 1,'descripcion2',3,null,1500
go



create proc sp_EliminarHabitacion(@id int)
as
begin
	delete from TB_HABITACION where CODIGO_HABITACION = @id
end
go

EXEC sp_EliminarHabitacion 1
GO


create table TB_RESERVA(
	CODIGO_RESERVA int identity(1,1) primary key,
	CODIGO_HABITACION INT REFERENCES TB_HABITACION,
	CODIGO_USUARIO INT REFERENCES TB_USUARIO,
	FECHA_REALIZACION DATE,
	CANTIDAD_DIAS INT,
	FECHA_INICIO DATE,
	ESTADO INT,
	TOTAL DECIMAL(10,2)
)
go


create proc sp_AgregarReserva(@habitacion INT,
	@usuario int,
	@dias int,
	@fecha1 DATE,
	@total decimal(10,2))
as
declare @a int
begin

	insert into TB_RESERVA(CODIGO_HABITACION,FECHA_REALIZACION,CODIGO_USUARIO,CANTIDAD_DIAS,
	FECHA_INICIO,
	ESTADO ,TOTAL) values (@habitacion,GETDATE(),@usuario,@dias,
	@fecha1,
	0,@total)
	
end
go


create proc sp_CancelarReserva(@id int)
as
begin
	update TB_RESERVA set ESTADO = 2 where CODIGO_RESERVA = @id
end
go

create proc sp_PagarReserva(@id int)
as
begin
	update TB_RESERVA set ESTADO = 3 where CODIGO_RESERVA = @id
end
go

create proc sp_ListarReservaXUsuario(@usuario int)
as
begin
	select r.CODIGO_RESERVA as CODIGO_RESERVA,r.ESTADO as ESTADO,
	r.FECHA_INICIO as FECHA_INICIO,h.CODIGO_HABITACION as CODIGO_HABITACION,
	h.DESCRIPCION_HABITACION as DESCRIPCION_HABITACION,r.ESTADO as ESTADO,
	r.TOTAL as TOTAL
	from TB_RESERVA r inner join TB_HABITACION h 
	on r.CODIGO_HABITACION = h.CODIGO_HABITACION 
	where CODIGO_USUARIO = @usuario and ESTADO != 2
end
go
/*
0-reserva creada
1-reserva vigente
2-reserva cancelada
3-reserva completada
*/

create proc sp_ListarReservaxestado(@estado int)
as
begin
	select r.CODIGO_RESERVA as CODIGO_RESERVA,r.ESTADO as ESTADO,
	r.FECHA_INICIO as FECHA_INICIO,h.CODIGO_HABITACION as CODIGO_HABITACION,
	h.DESCRIPCION_HABITACION as DESCRIPCION_HABITACION,r.ESTADO as ESTADO,
	r.TOTAL as TOTAL
	from TB_RESERVA r inner join TB_HABITACION h 
	on r.CODIGO_HABITACION = h.CODIGO_HABITACION 
	where ESTADO = @estado
end
go



exec sp_AgregarEmpleado 'Adrian','Matos','99999999','administrador',null,null
go

create proc sp_ListarTopReserva
as
begin

	select top 10 h.CODIGO_HABITACION as CODIGO_HABITACION
	,h.DESCRIPCION_HABITACION as DESCRIPCION_HABITACION
	,h.PRECIO_HABITACION as PRECIO_HABITACION
	from TB_RESERVA r inner join TB_HABITACION h 
	on r.CODIGO_HABITACION = h.CODIGO_HABITACION
	group by h.CODIGO_HABITACION,h.DESCRIPCION_HABITACION,h.PRECIO_HABITACION
	order by count(r.CODIGO_HABITACION) desc
end
go



create table TB_TIPO_TARJETA(
	ID_TIPO_TARJETA int identity(1,1) primary key,
	NOMBRE_TIPO_TARJETA VARCHAR(20)
)
go

INSERT INTO TB_TIPO_TARJETA VALUES ('Visa')
INSERT INTO TB_TIPO_TARJETA VALUES ('MasterCard')
INSERT INTO TB_TIPO_TARJETA VALUES ('Discover')

select * from TB_TIPO_TARJETA
go

create table TB_TARJETA(
	ID_TARJETA int identity(1,1) primary key,
	ID_TIPO_TARJETA int foreign key references TB_TIPO_TARJETA,
	NUMERO_TARJETA VARCHAR(16),
	NOMBRE_TARJETA VARCHAR(50),
	SECURITY_CODE_TARJETA CHAR(3),
	MES_EXPIRACION_TARJETA CHAR(2),
	AÑO_EXPIRACION_TARJETA CHAR(4),
	TARJETA_HABILITADA BIT,
	LINEA_CREDITO DECIMAL(10,2),
	CREDITO_DISPONIBLE DECIMAL(10,2)
)
go
INSERT INTO TB_TARJETA VALUES (1,'1234567812345678','Adrian Matos','111','01','2021',1,100000,50000)
INSERT INTO TB_TARJETA VALUES (1,'1111111122222222','Jaime Medina','222','02','2022',1,100,50)
INSERT INTO TB_TARJETA VALUES (1,'2222222233333333','Roger duglio','333','03','2023',1,100,12)
go

create proc sp_GetTarjetaByInfo(@idTipoTarjeta int,@numeroTarjeta varchar(16),
@nombreTarjeta varchar(50),@securityCodeTarjeta char(3),
@mesExpiracionTarjeta char(2),@añoExpiracionTarjeta char(4))
as
begin
	select tar.NUMERO_TARJETA as NUMERO_TARJETA,tar.NOMBRE_TARJETA as NOMBRE_TARJETA,tar.TARJETA_HABILITADA as TARJETA_HABILITADA,tar.CREDITO_DISPONIBLE as CREDITO_DISPONIBLE
	from TB_TARJETA tar where tar.ID_TIPO_TARJETA = @idTipoTarjeta
	and tar.NUMERO_TARJETA = @numeroTarjeta
	and tar.NOMBRE_TARJETA = @nombreTarjeta
	and tar.SECURITY_CODE_TARJETA = @securityCodeTarjeta
	and tar.MES_EXPIRACION_TARJETA = @mesExpiracionTarjeta
	and tar.AÑO_EXPIRACION_TARJETA = @añoExpiracionTarjeta
end
go
exec sp_GetTarjetaByInfo 1,'1234567812345678','Adrian Matos','111','01','2021'
go


create proc sp_ListarReservaxhabitacion(@habitacion int)
as
begin
	select r.CODIGO_RESERVA as CODIGO_RESERVA,
	r.FECHA_INICIO as FECHA_INICIO,h.CODIGO_HABITACION as CODIGO_HABITACION,
	r.CANTIDAD_DIAS as CANTIDAD_DIAS
	from TB_RESERVA r inner join TB_HABITACION h 
	on r.CODIGO_HABITACION = h.CODIGO_HABITACION 
	where r.CODIGO_HABITACION = @habitacion and ESTADO !=2 and ESTADO !=3
end
go
select * from TB_RESERVA
go

create proc sp_CheckIn(@id int)
as
declare @a int
begin
	
	 update TB_RESERVA set ESTADO = 1 where CODIGO_RESERVA=@id
	 
	 select @a = CODIGO_HABITACION from TB_RESERVA

	 update TB_HABITACION set ESTADO_HABITACION = 'Ocupada'
	 where CODIGO_HABITACION = @a
end
go

create proc sp_CheckOut(@id int)
as
declare @a int
begin
	update TB_RESERVA set ESTADO = 3 where CODIGO_RESERVA=@id
	 
	 select @a = CODIGO_HABITACION from TB_RESERVA

	 update TB_HABITACION set ESTADO_HABITACION = 'Libre'
	 where CODIGO_HABITACION = @a
end
go
