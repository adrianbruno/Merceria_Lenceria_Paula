﻿USE [MerceriaDB]
GO

/****** Objeto: SqlProcedure [dbo].[sp_ins_item_stock] Fecha del script: 10/16/2014 9:54:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_ins_item_stock]
	@id_cod varchar(20),
	@id_fabricante int,
	@descripcion nvarchar(50),
	@precio decimal (18,2),
	@cant_actual int,
	@hash nvarchar(max)
AS
	INSERT INTO stock ([id_codigo],
						[id_fabricante],
						[descripcion],
						[precio],
						[cant_actual],
						[hash])
				VALUES (@id_cod, 
						@id_fabricante,
						@descripcion,
						@precio,
						@cant_actual,
						@hash)
RETURN 0