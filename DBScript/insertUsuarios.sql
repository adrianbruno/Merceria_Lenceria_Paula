USE [MerceriaDB]
GO

INSERT INTO [dbo].[usuarios]
           ([login]
           ,[pass]
           ,[Nombre]
           ,[Apellido]
           ,[nivel]
           ,[cuenta_activa]
           ,[cant_intento_fallido])
     VALUES
           ('abruno',
           '4ceAqAoynTZhKFgFTNO7at49dLKJ3OEzw/zqolQg4g1spZzFGLSEfk0eP3MQGT1xfoTsZfhR/rWSJ2Fy75TThQ==',
           'Adrian',
           'Bruno',
           7,
           1,
           0)
GO

INSERT INTO [dbo].[usuarios]
           ([login]
           ,[pass]
           ,[Nombre]
           ,[Apellido]
           ,[nivel]
           ,[cuenta_activa]
           ,[cant_intento_fallido])
     VALUES
           ('rosa',
           'WKcF8FhXKb2WBjdLC0fq0dDCDEMrOUqaBuRiZ8Ei7JSgMvwymE8aB0JddCK4Nx1bH2sF5kLQLhfv6NQRwSGVKQ==',
           'Rosa',
           'Montivero',
           3,
           1,
           0)
GO

INSERT INTO [dbo].[usuarios]
           ([login]
           ,[pass]
           ,[Nombre]
           ,[Apellido]
           ,[nivel]
           ,[cuenta_activa]
           ,[cant_intento_fallido])
     VALUES
           ('venta',
           'VyW45EtWi4j4W98+nEpylReiQ7mkUWlHUeWuPG4dXxBki7taXMSNLmjOxIkYeVUDjPuw93kvSVOseXRx2nKRAw==',
           'Raquel',
           'Manchini',
           1,
           1,
           0)
GO