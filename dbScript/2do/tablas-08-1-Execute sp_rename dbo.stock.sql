USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
EXEC sp_rename 'stock.Id_codigo', 'id_codigo', 'COLUMN';
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

ALTER TABLE dbo.stock 
ADD CONSTRAINT PK_id_codigo_stock PRIMARY KEY CLUSTERED (id_codigo);
GO

ALTER TABLE dbo.stock 
ADD CONSTRAINT FK_stock_fabricantes FOREIGN KEY (id_fabricante) 
    REFERENCES dbo.fabricantes (id)
    ON UPDATE CASCADE
;
GO