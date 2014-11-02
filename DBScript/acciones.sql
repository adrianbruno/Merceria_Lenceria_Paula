/*
   domingo, 02 de noviembre de 201415:55:27
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
CREATE TABLE dbo.Tmp_acciones
	(
	id tinyint NOT NULL IDENTITY (1, 1),
	descripcion varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_acciones SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_acciones ON
GO
IF EXISTS(SELECT * FROM dbo.acciones)
	 EXEC('INSERT INTO dbo.Tmp_acciones (id, descripcion)
		SELECT id, descripcion FROM dbo.acciones WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_acciones OFF
GO
DROP TABLE dbo.acciones
GO
EXECUTE sp_rename N'dbo.Tmp_acciones', N'acciones', 'OBJECT' 
GO
ALTER TABLE dbo.acciones ADD CONSTRAINT
	PK_id_acciones PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.acciones', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.acciones', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.acciones', 'Object', 'CONTROL') as Contr_Per 