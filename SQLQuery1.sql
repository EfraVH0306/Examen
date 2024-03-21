drop database Cuestionario_UPI
go
create database Cuestionario_UPI
go
Use Cuestionario_UPI

create table informacion
( 
   Numero_Encuesta INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Participante VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Fecha_Nacimiento DATE NOT NULL,
    Edad INT NOT NULL CHECK (Edad >= 18 AND Edad <= 50),
    Correo_Electronico VARCHAR(100) NOT NULL,
    Carro_Propio VARCHAR(3) NOT NULL CHECK (Carro_Propio IN ('Si', 'No'))
)
go
CREATE TABLE PersonalEncuestador 
(
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    FechaContratacion DATE NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL
)
INSERT INTO PersonalEncuestador (Nombre, Apellido, CorreoElectronico, FechaContratacion, Salario) 
VALUES ('Juan', 'Pérez', 'juan@example.com', '2023-01-01', 2500.00);