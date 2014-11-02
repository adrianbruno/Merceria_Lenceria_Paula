USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'provincias.Id_prov', 'id', 'COLUMN';
GO

EXEC sp_rename 'provincias.Descripcion', 'descripcion', 'COLUMN';
GO

ALTER TABLE dbo.provincias 
ADD CONSTRAINT PK_id_provincias PRIMARY KEY CLUSTERED (id);
GO