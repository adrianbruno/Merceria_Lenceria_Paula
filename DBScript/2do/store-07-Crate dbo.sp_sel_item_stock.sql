USE [MerceriaDB]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_item_stock]
	@id_codigo INT 
AS
	SELECT * FROM stock WHERE id_codigo=@id_codigo
RETURN 0
