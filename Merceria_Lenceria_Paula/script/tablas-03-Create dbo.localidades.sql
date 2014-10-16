USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[localidades] Fecha del script: 10/16/2014 9:52:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[localidades] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Id_loc]      INT          NOT NULL,
    [id_prov]     INT          NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL
);


