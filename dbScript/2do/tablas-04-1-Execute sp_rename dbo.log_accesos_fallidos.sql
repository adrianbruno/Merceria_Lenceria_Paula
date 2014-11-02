USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'dbo.log_acceso_fallido', 'log_accesos_fallidos';
GO

EXEC sp_rename 'log_accesos_fallidos.Id', 'id', 'COLUMN';
GO