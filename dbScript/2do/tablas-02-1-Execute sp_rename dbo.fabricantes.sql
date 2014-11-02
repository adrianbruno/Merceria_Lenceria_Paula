USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'dbo.fabricante', 'fabricantes';
GO

EXEC sp_rename 'fabricantes.Id_fabricante', 'id', 'COLUMN';
GO
