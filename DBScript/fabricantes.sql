/*
   domingo, 02 de noviembre de 201416:10:03
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
CREATE TABLE dbo.Tmp_fabricantes
	(
	id int NOT NULL IDENTITY (1, 1),
	descripcion varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_fabricantes SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_fabricantes ON
GO
IF EXISTS(SELECT * FROM dbo.fabricantes)
	 EXEC('INSERT INTO dbo.Tmp_fabricantes (id, descripcion)
		SELECT id, descripcion FROM dbo.fabricantes WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_fabricantes OFF
GO
ALTER TABLE dbo.stock
	DROP CONSTRAINT FK_stock_fabricantes
GO
DROP TABLE dbo.fabricantes
GO
EXECUTE sp_rename N'dbo.Tmp_fabricantes', N'fabricantes', 'OBJECT' 
GO
ALTER TABLE dbo.fabricantes ADD CONSTRAINT
	PK_id_fabricantes PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.stock ADD CONSTRAINT
	FK_stock_fabricantes FOREIGN KEY
	(
	id_fabricante
	) REFERENCES dbo.fabricantes
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.stock SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.stock', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.stock', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.stock', 'Object', 'CONTROL') as Contr_Per 