USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'localidades.Id', 'id', 'COLUMN';
GO

EXEC sp_rename 'localidades.Id_loc', 'id_loc', 'COLUMN';
GO

EXEC sp_rename 'localidades.Descripcion', 'descripcion', 'COLUMN';
GO