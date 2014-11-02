USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[usuarios] Fecha del script: 10/16/2014 10:02:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[usuarios] (
    [login]                VARCHAR (50)  NOT NULL,
    [pass]                 VARCHAR (MAX) NOT NULL,
    [Nombre]               CHAR (15)     NOT NULL,
    [Apellido]             CHAR (15)     NOT NULL,
    [nivel]                INT           NOT NULL,
    [cuenta_activa]        TINYINT       NULL,
    [cant_intento_fallido] TINYINT       NULL
);


