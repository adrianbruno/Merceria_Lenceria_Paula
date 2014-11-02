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