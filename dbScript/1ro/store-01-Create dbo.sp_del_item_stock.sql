USE [MerceriaDB]
GO

/****** Objeto: SqlProcedure [dbo].[sp_del_item_stock] Fecha del script: 10/16/2014 9:53:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_del_item_stock]
	@id_codigo nvarchar(20) 
AS
	DELETE FROM stock WHERE id_codigo=@id_codigo
RETURN 0
