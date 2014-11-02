USE [MerceriaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ins_fabricante]
	@id_fabricante int,
	@descripcion nvarchar(50)
	
AS
	INSERT INTO fabricantes([id],
						[descripcion]
						)
				VALUES (@id_fabricante,
						@descripcion
						)
RETURN 0
