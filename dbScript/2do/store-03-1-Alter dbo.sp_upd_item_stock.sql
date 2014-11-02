USE [MerceriaDB]
GO

/****** Objeto: SqlProcedure [dbo].[sp_upd_item_stock] Fecha del script: 10/16/2014 9:54:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_upd_item_stock]
	@id_cod varchar(20),
	@id_fabricante int,
	@descripcion nvarchar(50),
	@precio decimal (18,2),
	@cant_actual int,
	@hash nvarchar(max)
AS
	UPDATE stock SET [id_fabricante]=@id_fabricante,
                     [descripcion]=@descripcion,
					 [precio]=@precio,
					 [cant_actual]=@cant_actual,
					 [hash]=@hash
			WHERE [id_codigo]=@id_cod
RETURN 0
