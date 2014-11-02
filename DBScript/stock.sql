/*
   domingo, 02 de noviembre de 201416:21:46
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
ALTER TABLE dbo.stock
	DROP CONSTRAINT FK_stock_fabricantes
GO
ALTER TABLE dbo.fabricantes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.fabricantes', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_stock
	(
	id int NOT NULL,
	id_codigo varchar(20) NOT NULL,
	id_fabricante int NOT NULL,
	descripcion varchar(50) NOT NULL,
	precio decimal(18, 2) NOT NULL,
	cod_barra varchar(MAX) NULL,
	imagen image NULL,
	fecha_modificado datetime NULL,
	cant_actual int NULL,
	unidad_medida varchar(50) NULL,
	dato_principal varchar(50) NULL,
	dato_secundario varchar(50) NULL,
	hash nvarchar(MAX) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_stock SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.stock)
	 EXEC('INSERT INTO dbo.Tmp_stock (id, id_codigo, id_fabricante, descripcion, precio, cod_barra, imagen, fecha_modificado, cant_actual, unidad_medida, dato_principal, dato_secundario, hash)
		SELECT id, id_codigo, id_fabricante, descripcion, precio, cod_barra, imagen, fecha_modificado, cant_actual, unidad_medida, dato_principal, dato_secundario, hash FROM dbo.stock WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.stock
GO
EXECUTE sp_rename N'dbo.Tmp_stock', N'stock', 'OBJECT' 
GO
ALTER TABLE dbo.stock ADD CONSTRAINT
	PK_stock PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.stock ADD CONSTRAINT
	AK_id_codigo_stock UNIQUE NONCLUSTERED 
	(
	id_codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX PK_id_stock ON dbo.stock
	(
	id_codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
COMMIT
select Has_Perms_By_Name(N'dbo.stock', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.stock', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.stock', 'Object', 'CONTROL') as Contr_Per 