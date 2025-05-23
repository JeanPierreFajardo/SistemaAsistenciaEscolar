
CREATE DATABASE CONTROL_ASISTENCIA;
GO

USE CONTROL_ASISTENCIA;
GO

CREATE TABLE Usuarios
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(50) NOT NULL,
    Contrase�a VARCHAR(50) NOT NULL,
    TipoUsuario VARCHAR(50) NOT NULL
);
GO

SELECT * FROM USUARIOS


CREATE TABLE ESTUDIANTE
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    Telefono VARCHAR(15),
    Grado VARCHAR(20) NOT NULL,
	Turno varchar(10),
    FechaNacimiento DATE,
    Correo VARCHAR(50),
    Sexo VARCHAR(10),
    DNI VARCHAR(10) NOT NULL,
    Direccion VARCHAR(100)
);
GO
select * from ESTUDIANTE


CREATE TABLE PADRES
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    NombreCompletoPadre VARCHAR(100) NOT NULL,
    TelefonoPadre VARCHAR(15),
    CorreoPadre VARCHAR(50),
    NombreCompletoMadre VARCHAR(100) NOT NULL,
    TelefonoMadre VARCHAR(15),
    CorreoMadre VARCHAR(50)
);
GO
select * from PADRES     

--creando vista para unir las tablas PADRES y ESTUDIANTE

CREATE VIEW VistaEstudiantesPadres AS
SELECT E.*, P.NombreCompletoPadre, P.TelefonoPadre, P.CorreoPadre, P.NombreCompletoMadre, P.TelefonoMadre, P.CorreoMadre
FROM ESTUDIANTE E
INNER JOIN PADRES P ON E.ID = P.ID;

select * from VistaEstudiantesPadres

CREATE TABLE FOTOS
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Imagen VARBINARY(MAX)	
);
GO
SELECT * FROM FOTOS


CREATE TABLE ReportesEstudiantes
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT, -- Clave for�nea para vincular con la tabla Estudiante
    NombreEstudiante VARCHAR(100), -- Nombre del estudiante correspondiente al reporte
    FechaReporte DATE,
    TipoReporte NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    
    -- Agregar una restricci�n de clave for�nea para vincular Estudiante con ReportesEstudiantes
	FOREIGN KEY (EstudianteID) REFERENCES Estudiante(ID)    
);


drop PROCEDURE InsertarReporteEstudiante

CREATE PROCEDURE InsertarReporteEstudiante
(
    @EstudianteID INT,
    @FechaReporte DATE,
    @TipoReporte NVARCHAR(255),
    @Descripcion NVARCHAR(MAX)
)
AS
BEGIN
    -- Declarar una variable para almacenar el nombre del estudiante
    DECLARE @NombreEstudiante VARCHAR(100);

    -- Obtener el nombre y apellidos del estudiante
    SELECT @NombreEstudiante = Nombre + ' ' + Apellidos
    FROM Estudiante
    WHERE ID = @EstudianteID;

    -- Insertando datos a la tabla ReportesEstudiantes
    INSERT INTO ReportesEstudiantes (EstudianteID, NombreEstudiante, FechaReporte, TipoReporte, Descripcion)
    VALUES (@EstudianteID, @NombreEstudiante, @FechaReporte, @TipoReporte, @Descripcion);
END;



-- Llamar al procedimiento para insertar un reporte
EXEC InsertarReporteEstudiante 1, '2023-10-04', 'Tarde', 'Lleg� tarde a clases';
EXEC InsertarReporteEstudiante 1002, '2023-10-04', 'FALTA', 'No asistio a clases';
EXEC InsertarReporteEstudiante 1003, '2023-10-04', 'Tarde', 'Lleg� borracho a clases';



SELECT * FROM ReportesEstudiantes
drop table ReportesEstudiantes



                      