USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'dbo.log_acceso_usuario', 'log_accesos_usuarios';
GO

EXEC sp_rename 'log_accesos_usuarios.Id', 'id', 'COLUMN';
GO