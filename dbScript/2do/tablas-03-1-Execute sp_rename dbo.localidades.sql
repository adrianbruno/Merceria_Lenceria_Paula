USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'localidades.Id', 'id', 'COLUMN';
GO

EXEC sp_rename 'localidades.Descripcion', 'descripcion', 'COLUMN';
GO

ALTER TABLE dbo.localidades 
DROP COLUMN Id_loc;
GO

ALTER TABLE dbo.localidades 
ADD CONSTRAINT PK_id_localidades PRIMARY KEY CLUSTERED (id);
GO

ALTER TABLE dbo.localidades 
ADD CONSTRAINT FK_loc_provincias FOREIGN KEY (id_prov) 
    REFERENCES dbo.provincias (id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO