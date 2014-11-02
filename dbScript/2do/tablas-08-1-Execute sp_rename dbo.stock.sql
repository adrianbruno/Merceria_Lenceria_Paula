USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'stock.fabricante', 'id_fabricante', 'COLUMN';
GO

ALTER TABLE dbo.stock ALTER COLUMN id_fabricante INT NOT NULL;
GO

EXEC sp_rename 'stock.Descripcion', 'descripcion', 'COLUMN';
GO

EXEC sp_rename 'stock.dato1', 'dato_principal', 'COLUMN';
GO

EXEC sp_rename 'stock.datos2', 'dato_secundario', 'COLUMN';
GO