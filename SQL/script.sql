USE master
GO
CREATE DATABASE [DBPRUEBAS]
GO
USE [DBPRUEBAS]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Producto](
    [id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Clave primaria y autoincremental
    [nombre] VARCHAR(50) NOT NULL,              -- Nombre del producto
    [descripcion] VARCHAR(255) NULL,            -- Descripción del producto
    [precio] DECIMAL(10,2) NOT NULL,            -- Precio con 2 decimales
    [cantidad] INT NOT NULL                     -- Cantidad disponible
)
ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
