USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


EXEC sp_rename 'usuarios.Nombre', 'nombre', 'COLUMN';
GO

EXEC sp_rename 'usuarios.Apellido', 'apellido', 'COLUMN';
GO

ALTER TABLE dbo.usuarios
ADD id int NOT NULL IDENTITY
GO

ALTER TABLE dbo.usuarios 
ADD CONSTRAINT PK_id_usuarios PRIMARY KEY CLUSTERED (id);
GO

----------------------------------------------------------------
--ID QUEDA AL FINAL DE LA TABLA TENER EN CUENTA AL SELECCIONAR
----------------------------------------------------------------