/*
CREATE DATABASE db_salones;
GO

USE db_salones;
GO

CREATE TABLE [Usuarios] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(50) NULL,
    [Contraseña] NVARCHAR(100) NULL
);
GO
      

CREATE TABLE [Estudiantes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Codigo] NVARCHAR(20) NULL,
    [Nombre] NVARCHAR(50) NULL,
    [Edad] INT NOT NULL,
    [Peso] DECIMAL(18, 2) NOT NULL,
    [Usuario] INT NOT NULL, 
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);
GO

CREATE TABLE [Auditorias] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Descripcion] NVARCHAR(500) NULL,
    [Fecha] SMALLDATETIME NOT NULL
);
GO

INSERT INTO [Usuarios] ([Nombre], [Contraseña])
VALUES 
    ('admin', 'Admin123'),
    ('Kevin', 'kevin123'),
    ('andy', 'profe');
GO

INSERT INTO [Estudiantes] ([Codigo], [Nombre], [Edad], [Peso], [Usuario])
VALUES 
    ('P001', 'Juan jose', 19, 60.50, 1),
    ('P002', 'Kevin ', 19, 74.40, 3),
    ('P003', 'stefanny', 20, 56.60, 3);
GO


*/