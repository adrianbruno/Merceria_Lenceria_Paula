USE [MerceriaDB]
GO

/****** Objeto: Table [dbo].[Proovedores] Fecha del script: 10/16/2014 10:01:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Proovedores] (
    [Id_proveedor] INT           NOT NULL,
    [RazonSocial]  NCHAR (20)    NOT NULL,
    [Direccion]    NVARCHAR (30) NULL,
    [id_Loc]       INT           NOT NULL,
    [id_prov]      INT           NOT NULL,
    [tel1]         NVARCHAR (15) NULL,
    [tel2]         NVARCHAR (15) NULL,
    [contacto]     CHAR (15)     NULL,
    [email]        VARCHAR (50)  NULL,
    [web_page]     VARCHAR (50)  NULL
);


