USE [MerceriaDB]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_del_fabricante]
	@id_fabricante int 
AS
	DELETE FROM fabricantes WHERE id=@id_fabricante
RETURN 0
