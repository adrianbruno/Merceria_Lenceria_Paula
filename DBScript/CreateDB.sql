USE [master]
GO
/****** Object:  Database [MerceriaDB]    Script Date: 03/11/2014 2:14:16 ******/
CREATE DATABASE [MerceriaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MerceriaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MerceriaDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MerceriaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MerceriaDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MerceriaDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MerceriaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MerceriaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MerceriaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MerceriaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MerceriaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MerceriaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MerceriaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MerceriaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MerceriaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MerceriaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MerceriaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MerceriaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MerceriaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MerceriaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MerceriaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MerceriaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MerceriaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MerceriaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MerceriaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MerceriaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MerceriaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MerceriaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MerceriaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MerceriaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MerceriaDB] SET  MULTI_USER 
GO
ALTER DATABASE [MerceriaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MerceriaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MerceriaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MerceriaDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MerceriaDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MerceriaDB]
GO
/****** Object:  Table [dbo].[acciones]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[acciones](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_id_acciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fabricantes]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fabricantes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_id_fabricantes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[localidades]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[localidades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_prov] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_id_localidades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[log_accesos_fallidos]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[log_accesos_fallidos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[fecha_accion] [datetime] NOT NULL,
	[accion_tipo] [tinyint] NOT NULL,
	[ip_pc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_id_log_accesos_fallidos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[log_accesos_usuarios]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[log_accesos_usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varbinary](8000) NOT NULL,
	[fecha_accion] [datetime] NOT NULL,
	[accion_tipo] [tinyint] NOT NULL,
	[ip_pc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_id_log_accesos_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuit] [char](11) NOT NULL,
	[razon_social] [nchar](50) NOT NULL,
	[direccion] [nvarchar](50) NULL,
	[id_loc] [int] NULL,
	[tel_celular] [nvarchar](15) NULL,
	[tel_fijo] [nvarchar](15) NULL,
	[contacto] [char](15) NULL,
	[email] [varchar](50) NULL,
	[web_page] [varchar](50) NULL,
 CONSTRAINT [PK_id_proveedores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[provincias]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_id_provincias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stock]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_codigo] [varchar](20) NOT NULL,
	[id_fabricante] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[cod_barra] [varchar](max) NULL,
	[imagen] [image] NULL,
	[fecha_modificado] [datetime] NULL,
	[cant_actual] [int] NULL,
	[unidad_medida] [varchar](50) NULL,
	[dato_principal] [varchar](50) NULL,
	[dato_secundario] [varchar](50) NULL,
	[hash] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_stock] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[pass] [varchar](max) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nivel] [int] NOT NULL,
	[cuenta_activa] [tinyint] NULL CONSTRAINT [DF__usuarios__cuenta__6754599E]  DEFAULT ((1)),
	[cant_intento_fallido] [tinyint] NULL CONSTRAINT [DF__usuarios__cant_i__68487DD7]  DEFAULT ((0)),
 CONSTRAINT [PK__usuarios__3213E83F0475F2F3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[fabricantes] ON 

GO
INSERT [dbo].[fabricantes] ([id], [descripcion]) VALUES (1, N'colage')
GO
INSERT [dbo].[fabricantes] ([id], [descripcion]) VALUES (2, N'chloe')
GO
INSERT [dbo].[fabricantes] ([id], [descripcion]) VALUES (3, N'selu')
GO
SET IDENTITY_INSERT [dbo].[fabricantes] OFF
GO
SET IDENTITY_INSERT [dbo].[log_accesos_fallidos] ON 

GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (1, N'abruno', N'adrianlp', CAST(N'2014-02-11 14:43:16.000' AS DateTime), 6, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (2, N'abruno', N'adrianlp', CAST(N'2014-02-11 14:43:29.000' AS DateTime), 6, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (3, N'abruno', N'adrianlp', CAST(N'2014-02-11 14:51:28.000' AS DateTime), 6, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (4, N'abruno', N'adrianlp', CAST(N'2014-02-11 16:28:25.000' AS DateTime), 3, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (5, N'abruno', N'adrianlp', CAST(N'2014-02-11 16:28:32.000' AS DateTime), 3, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (6, N'abruno', N'adrianlp', CAST(N'2014-02-11 16:31:19.000' AS DateTime), 3, N'192.168.0.103,usuario-PC')
GO
INSERT [dbo].[log_accesos_fallidos] ([id], [login], [password], [fecha_accion], [accion_tipo], [ip_pc]) VALUES (7, N'', N'', CAST(N'2014-02-11 18:14:38.000' AS DateTime), 6, N'192.168.0.103,usuario-PC')
GO
SET IDENTITY_INSERT [dbo].[log_accesos_fallidos] OFF
GO
SET IDENTITY_INSERT [dbo].[stock] ON 

GO
INSERT [dbo].[stock] ([id], [id_codigo], [id_fabricante], [descripcion], [precio], [cod_barra], [imagen], [fecha_modificado], [cant_actual], [unidad_medida], [dato_principal], [dato_secundario], [hash]) VALUES (1, N'12345', 1, N'producto1', CAST(55.00 AS Decimal(18, 2)), NULL, NULL, NULL, 10, NULL, NULL, NULL, N'F49D455D1C2F2FBEACE87C8A29489B77')
GO
INSERT [dbo].[stock] ([id], [id_codigo], [id_fabricante], [descripcion], [precio], [cod_barra], [imagen], [fecha_modificado], [cant_actual], [unidad_medida], [dato_principal], [dato_secundario], [hash]) VALUES (2, N'76897', 2, N'producto2', CAST(89.00 AS Decimal(18, 2)), NULL, NULL, NULL, 5, NULL, NULL, NULL, N'5F229484546CE0F09504BFF188AFEB8A')
GO
SET IDENTITY_INSERT [dbo].[stock] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

GO
INSERT [dbo].[usuarios] ([id], [login], [pass], [nombre], [apellido], [nivel], [cuenta_activa], [cant_intento_fallido]) VALUES (1, N'abruno', N'4ceAqAoynTZhKFgFTNO7at49dLKJ3OEzw/zqolQg4g1spZzFGLSEfk0eP3MQGT1xfoTsZfhR/rWSJ2Fy75TThQ==', N'Adrian         ', N'Bruno          ', 7, 1, 0)
GO
INSERT [dbo].[usuarios] ([id], [login], [pass], [nombre], [apellido], [nivel], [cuenta_activa], [cant_intento_fallido]) VALUES (2, N'rosa', N'WKcF8FhXKb2WBjdLC0fq0dDCDEMrOUqaBuRiZ8Ei7JSgMvwymE8aB0JddCK4Nx1bH2sF5kLQLhfv6NQRwSGVKQ==', N'Rosa           ', N'Montivero      ', 3, 1, 0)
GO
INSERT [dbo].[usuarios] ([id], [login], [pass], [nombre], [apellido], [nivel], [cuenta_activa], [cant_intento_fallido]) VALUES (3, N'venta', N'VyW45EtWi4j4W98+nEpylReiQ7mkUWlHUeWuPG4dXxBki7taXMSNLmjOxIkYeVUDjPuw93kvSVOseXRx2nKRAw==', N'Raquel         ', N'Manchini       ', 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_cuit_proveedores]    Script Date: 03/11/2014 2:14:16 ******/
ALTER TABLE [dbo].[proveedores] ADD  CONSTRAINT [AK_cuit_proveedores] UNIQUE NONCLUSTERED 
(
	[cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [AK_id_codigo_stock]    Script Date: 03/11/2014 2:14:16 ******/
ALTER TABLE [dbo].[stock] ADD  CONSTRAINT [AK_id_codigo_stock] UNIQUE NONCLUSTERED 
(
	[id_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [PK_id_stock]    Script Date: 03/11/2014 2:14:16 ******/
CREATE NONCLUSTERED INDEX [PK_id_stock] ON [dbo].[stock]
(
	[id_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[localidades]  WITH CHECK ADD  CONSTRAINT [FK_prov_localidades] FOREIGN KEY([id_prov])
REFERENCES [dbo].[provincias] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[localidades] CHECK CONSTRAINT [FK_prov_localidades]
GO
ALTER TABLE [dbo].[proveedores]  WITH CHECK ADD  CONSTRAINT [FK_proveed_localidades] FOREIGN KEY([id_loc])
REFERENCES [dbo].[localidades] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[proveedores] CHECK CONSTRAINT [FK_proveed_localidades]
GO
ALTER TABLE [dbo].[stock]  WITH CHECK ADD  CONSTRAINT [FK_stock_fabricantes] FOREIGN KEY([id_fabricante])
REFERENCES [dbo].[fabricantes] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[stock] CHECK CONSTRAINT [FK_stock_fabricantes]
GO
/****** Object:  StoredProcedure [dbo].[sp_del_fabricante]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_del_fabricante]
	@id_fabricante int 
AS
	DELETE FROM fabricantes WHERE id=@id_fabricante
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_del_item_stock]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_del_item_stock]
	@id_codigo nvarchar(20) 
AS
	DELETE FROM stock WHERE id_codigo=@id_codigo
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_ins_fabricante]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ins_fabricante]
	@id_fabricante int,
	@descripcion nvarchar(50)
	
AS
	INSERT INTO fabricantes([id],
						[descripcion]
						)
				VALUES (@id_fabricante,
						@descripcion
						)
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_ins_item_stock]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ins_item_stock]
	@id_cod varchar(20),
	@id_fabricante int,
	@descripcion nvarchar(50),
	@precio decimal (18,2),
	@cant_actual int,
	@hash nvarchar(max)
AS
	INSERT INTO stock ([id_codigo],
						[id_fabricante],
						[descripcion],
						[precio],
						[cant_actual],
						[hash])
				VALUES (@id_cod, 
						@id_fabricante,
						@descripcion,
						@precio,
						@cant_actual,
						@hash)
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_list_fabricantes]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_list_fabricantes]
	AS
	SELECT id AS 'CODIGO', descripcion AS 'NOMBRE' FROM dbo.fabricantes ORDER BY descripcion

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_desc2id_Fab]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_desc2id_Fab]
	@desc varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT id FROM fabricantes WHERE descripcion=@desc
END

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_fabricante]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_fabricante]
	@id_fabricante INT 
AS
	SELECT id AS 'Codigo', descripcion AS 'Nombre' FROM fabricantes WHERE id=@id_fabricante ORDER BY id
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_item_stock_basico]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_item_stock_basico]
	@id_codigo INT 
AS
	SELECT a.id_codigo AS 'Codigo', b.descripcion AS 'Fabricante', a.descripcion AS 'Descripcion', a.precio AS 'Precio', a.cant_actual 'Cantidad'
	FROM dbo.stock AS a, dbo.fabricantes AS b
	WHERE a.id_codigo=@id_codigo AND a.id_fabricante=b.id;
	
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_item_stock_full]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_item_stock_full]
	@id_codigo INT 
AS
	SELECT a.id, a.id_codigo, a.descripcion, a.precio, a.cod_barra, a.imagen, a.fecha_modificado, a.cant_actual, a.unidad_medida, a.dato_principal, a.dato_secundario, a.hash, b.id AS 'Codigo Fab', b.descripcion AS 'Nombre Fab'
	FROM dbo.stock AS a JOIN dbo.fabricantes AS b
	ON id_codigo = @id_codigo AND a.id_fabricante = b.id;
	
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_sel_stock_basico]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_sel_stock_basico]
	
AS
	SELECT a.id_codigo AS 'Codigo', b.descripcion AS 'Fabricante', a.descripcion AS 'Nombre', a.precio AS 'Precio', a.cant_actual AS 'Cantidad'
	FROM dbo.stock AS a JOIN dbo.fabricantes AS b
	ON a.id_fabricante = b.id;
	
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[sp_upd_item_stock]    Script Date: 03/11/2014 2:14:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_upd_item_stock]
	@id_cod varchar(20),
	@id_fabricante int,
	@descripcion nvarchar(50),
	@precio decimal (18,2),
	@cant_actual int,
	@hash nvarchar(max)
AS
	UPDATE stock SET [id_fabricante]=@id_fabricante,
                     [descripcion]=@descripcion,
					 [precio]=@precio,
					 [cant_actual]=@cant_actual,
					 [hash]=@hash
			WHERE [id_codigo]=@id_cod
RETURN 0

GO
USE [master]
GO
ALTER DATABASE [MerceriaDB] SET  READ_WRITE 
GO
