USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[log_acceso_fallido] Fecha del script: 10/16/2014 9:53:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[log_acceso_fallido] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [login]        VARCHAR (50) NOT NULL,
    [password]     VARCHAR (50) NOT NULL,
    [fecha_accion] DATETIME     NOT NULL,
    [accion_tipo]  TINYINT      NOT NULL,
    [ip_pc]        VARCHAR (50) NOT NULL
);


