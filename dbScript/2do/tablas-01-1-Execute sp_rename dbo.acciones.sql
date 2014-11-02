USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'acciones.id_accion', 'id', 'COLUMN';
GO

EXEC sp_rename 'acciones.Descripcion', 'descripcion', 'COLUMN';
GO
