

create procedure db_registro
@Nombre varchar (50),
@Apellidos varchar (50),
@Telefono varchar (50),
@Sexo varchar (30),
@Domicilio varchar (50),
@Edad int,
@Correo_Electronico varchar (30),
@Seguro varchar (30),
@ID_AreaMedica int

as begin 

insert into Pacientes values (@Nombre, @Apellidos, @Telefono, @Sexo, @Domicilio, @Edad, @Correo_Electronico, @Seguro, @ID_AreaMedica)
end

create procedure db_vista
as begin
select * from Pacientes
end
