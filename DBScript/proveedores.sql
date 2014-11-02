/*
   domingo, 02 de noviembre de 201416:24:47
   Usuario: sa
   Servidor: USUARIO-PC\SQLEXPRESS
   Base de datos: MerceriaDB
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.proveedores
	DROP CONSTRAINT FK_proveed_localidades
GO
ALTER TABLE dbo.localidades SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.localidades', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.localidades', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.localidades', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_proveedores
	(
	id int NOT NULL IDENTITY (1, 1),
	razon_social nchar(20) NOT NULL,
	direccion nvarchar(30) NULL,
	id_loc int NULL,
	tel_celular nvarchar(15) NULL,
	tel_fijo nvarchar(15) NULL,
	contacto char(15) NULL,
	email varchar(50) NULL,
	web_page varchar(50) NULL,
	cuit char(11) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_proveedores SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_proveedores ON
GO
IF EXISTS(SELECT * FROM dbo.proveedores)
	 EXEC('INSERT INTO dbo.Tmp_proveedores (id, razon_social, direccion, id_loc, tel_celular, tel_fijo, contacto, email, web_page, cuit)
		SELECT id, razon_social, direccion, id_loc, tel_celular, tel_fijo, contacto, email, web_page, cuit FROM dbo.proveedores WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_proveedores OFF
GO
DROP TABLE dbo.proveedores
GO
EXECUTE sp_rename N'dbo.Tmp_proveedores', N'proveedores', 'OBJECT' 
GO
ALTER TABLE dbo.proveedores ADD CONSTRAINT
	PK_id_proveedores PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.proveedores ADD CONSTRAINT
	AK_cuit_proveedores UNIQUE NONCLUSTERED 
	(
	cuit
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.proveedores ADD CONSTRAINT
	FK_proveed_localidades FOREIGN KEY
	(
	id_loc
	) REFERENCES dbo.localidades
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.proveedores', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.proveedores', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.proveedores', 'Object', 'CONTROL') as Contr_Per 