drop procedure db_registro

CREATE PROCEDURE db_registro
    @Nombre varchar(50),
    @Apellidos varchar(50),
    @Telefono varchar(30),
    @Sexo varchar(20),
    @Domicilio varchar(50),
    @Edad int,
    @Correo_Electronico varchar(30),
    @ID_Seguro int,
    @ID_AreaMedica int

AS
BEGIN

    INSERT INTO Pacientes VALUES (@Nombre, @Apellidos, @Telefono, @Sexo, @Domicilio, @Edad, @Correo_Electronico, @ID_Seguro, @ID_AreaMedica);
END