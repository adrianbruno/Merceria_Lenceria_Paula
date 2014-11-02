USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[stock] Fecha del script: 10/16/2014 10:01:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[stock] (
    [Id_codigo]        VARCHAR (20)    NOT NULL,
    [fabricante]       VARCHAR (50)    NOT NULL,
    [Descripcion]      VARCHAR (50)    NOT NULL,
    [precio]           DECIMAL (18, 2) NOT NULL,
    [cod_barra]        VARCHAR (MAX)   NULL,
    [imagen]           IMAGE           NULL,
    [fecha_modificado] DATETIME        NULL,
    [cant_actual]      INT             NULL,
    [unidad_medida]    VARCHAR (50)    NULL,
    [dato1]            VARCHAR (50)    NULL,
    [datos2]           VARCHAR (50)    NULL,
    [hash]             NVARCHAR (MAX)  NOT NULL
);


