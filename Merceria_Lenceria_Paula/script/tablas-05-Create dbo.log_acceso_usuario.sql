USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[log_acceso_usuario] Fecha del script: 10/16/2014 10:00:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[log_acceso_usuario] (
    [Id]           INT              IDENTITY (1, 1) NOT NULL,
    [login]        VARBINARY (8000) NOT NULL,
    [fecha_accion] DATETIME         NOT NULL,
    [accion_tipo]  TINYINT          NOT NULL,
    [ip_pc]        VARCHAR (50)     NOT NULL
);


