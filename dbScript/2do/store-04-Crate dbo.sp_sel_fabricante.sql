USE [MerceriaDB]
GO

/****** Objeto: SqlProcedure [dbo].[sp_sel_fabricante] Fecha del script: 11/02/2014 2:53:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_fabricante]
	@id_fabricante INT 
AS
	SELECT * FROM fabricantes WHERE id=@id_fabricante
RETURN 0
