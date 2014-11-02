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

ALTER TABLE dbo.acciones 
ADD CONSTRAINT PK_id_acciones PRIMARY KEY CLUSTERED (id);
GO