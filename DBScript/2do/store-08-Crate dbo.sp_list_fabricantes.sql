USE [MerceriaDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_list_fabricantes]
	AS
	SELECT * FROM fabricantes ORDER BY descripcion
RETURN 0
