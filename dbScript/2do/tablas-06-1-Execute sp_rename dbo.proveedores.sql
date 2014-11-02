USE [MerceriaDB] 
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

EXEC sp_rename 'dbo.Proovedores', 'proveedores';
GO

EXEC sp_rename 'proveedores.Id_proveedor', 'id', 'COLUMN';
GO

EXEC sp_rename 'proveedores.RazonSocial', 'razon_social', 'COLUMN';
GO

EXEC sp_rename 'proveedores.Direccion', 'direccion', 'COLUMN';
GO

EXEC sp_rename 'proveedores.id_Loc', 'id_loc', 'COLUMN';
GO

ALTER TABLE dbo.proveedores
ALTER COLUMN id_loc INT NULL;
GO

EXEC sp_rename 'proveedores.tel1', 'tel_celular', 'COLUMN';
GO

EXEC sp_rename 'proveedores.tel2', 'tel_fijo', 'COLUMN';
GO

ALTER TABLE dbo.proveedores
DROP COLUMN id_prov
GO

ALTER TABLE dbo.proveedores 
ADD CONSTRAINT PK_id_proveedores PRIMARY KEY CLUSTERED (id);
GO

ALTER TABLE dbo.proveedores ADD cuit char(11) NOT NULL;
GO

ALTER TABLE dbo.proveedores 
ADD CONSTRAINT FK_proveed_localidades FOREIGN KEY (id_loc) 
    REFERENCES dbo.localidades (id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
;
GO

ALTER TABLE dbo.proveedores 
ADD CONSTRAINT AK_cuit_proveedores UNIQUE (cuit); 
GO

-----------------------------------------------------------------------------
-- CUIT QUEDA AL FINAL DE LA TABLA, TENER EN CUENTA AL EJECUTAR SELECT
-----------------------------------------------------------------------------