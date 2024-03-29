USE [master]
GO
/****** Object:  Database [MARDOM]    Script Date: 9/10/2019 10:11:56 AM ******/
CREATE DATABASE [MARDOM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MARDOM', FILENAME = N'C:\Users\Johan Perez\Documents\SQL Server\MDF\MARDOM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MARDOM_log', FILENAME = N'C:\Users\Johan Perez\Documents\SQL Server\LDF\MARDOM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MARDOM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MARDOM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MARDOM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MARDOM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MARDOM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MARDOM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MARDOM] SET ARITHABORT OFF 
GO
ALTER DATABASE [MARDOM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MARDOM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MARDOM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MARDOM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MARDOM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MARDOM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MARDOM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MARDOM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MARDOM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MARDOM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MARDOM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MARDOM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MARDOM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MARDOM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MARDOM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MARDOM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MARDOM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MARDOM] SET RECOVERY FULL 
GO
ALTER DATABASE [MARDOM] SET  MULTI_USER 
GO
ALTER DATABASE [MARDOM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MARDOM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MARDOM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MARDOM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MARDOM] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MARDOM', N'ON'
GO
USE [MARDOM]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Ubicacion] [nvarchar](300) NOT NULL,
	[Capacidad] [int] NOT NULL,
 CONSTRAINT [PK_Alamacen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Almacen_Articulo]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen_Articulo](
	[ArticuloId] [int] NOT NULL,
	[AlmacenId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Almacen_Articulo_1] PRIMARY KEY CLUSTERED 
(
	[ArticuloId] ASC,
	[AlmacenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[PrecioCompra] [decimal](9, 2) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[MarcaId] [int] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[PrecioVenta1]  AS ([PrecioCompra]*(1.1)),
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca_Articulo]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca_Articulo](
	[ArticuloId] [int] NOT NULL,
	[MarcaId] [int] NOT NULL,
 CONSTRAINT [PK_Marca_Articulo_1] PRIMARY KEY CLUSTERED 
(
	[ArticuloId] ASC,
	[MarcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[AlmacenId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[TipoMovimientoId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor_Articulo]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor_Articulo](
	[ArticuloId] [int] NOT NULL,
	[ProveedorId] [int] NOT NULL,
 CONSTRAINT [PK_Proveedor_Articulo_1] PRIMARY KEY CLUSTERED 
(
	[ArticuloId] ASC,
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoMovimiento]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoMovimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoMovimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Inventario]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Inventario]
AS
SELECT        a.Id, a.Descripcion, SUM(aa.Cantidad) AS Cantidad, alm.Descripcion AS Almacen, alm.Capacidad
FROM            dbo.Almacen_Articulo AS aa INNER JOIN
                         dbo.Articulo AS a ON aa.ArticuloId = a.Id INNER JOIN
                         dbo.Almacen AS alm ON aa.AlmacenId = alm.Id
GROUP BY a.Id, a.Descripcion, alm.Capacidad, alm.Descripcion
GO
/****** Object:  View [dbo].[Transacciones]    Script Date: 9/10/2019 10:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Transacciones]
AS
SELECT        a.Descripcion, alm.Descripcion AS Almacen, m.Cantidad, t.Descripcion AS Movimiento, m.Fecha
FROM            dbo.Movimientos AS m INNER JOIN
                         dbo.Articulo AS a ON m.ArticuloId = a.Id INNER JOIN
                         dbo.Almacen AS alm ON m.AlmacenId = alm.Id INNER JOIN
                         dbo.TipoMovimiento AS t ON m.TipoMovimientoId = t.Id
GO
SET IDENTITY_INSERT [dbo].[Almacen] ON 

INSERT [dbo].[Almacen] ([Id], [Descripcion], [Ubicacion], [Capacidad]) VALUES (1, N'Independencia', N'Av. Independencia', 200)
INSERT [dbo].[Almacen] ([Id], [Descripcion], [Ubicacion], [Capacidad]) VALUES (2, N'Kennedy', N'Av. Jonh F. Kennedy', 300)
INSERT [dbo].[Almacen] ([Id], [Descripcion], [Ubicacion], [Capacidad]) VALUES (3, N'Lope de Vega', N'Av. Lope de Vega', 100)
SET IDENTITY_INSERT [dbo].[Almacen] OFF
INSERT [dbo].[Almacen_Articulo] ([ArticuloId], [AlmacenId], [Cantidad]) VALUES (1, 1, 90)
INSERT [dbo].[Almacen_Articulo] ([ArticuloId], [AlmacenId], [Cantidad]) VALUES (1, 2, 60)
INSERT [dbo].[Almacen_Articulo] ([ArticuloId], [AlmacenId], [Cantidad]) VALUES (2, 1, 50)
SET IDENTITY_INSERT [dbo].[Articulo] ON 

INSERT [dbo].[Articulo] ([Id], [Descripcion], [PrecioCompra], [CategoriaId], [MarcaId], [ProveedorId]) VALUES (1, N'Tubo de 1/2', CAST(25.00 AS Decimal(9, 2)), 1, 1, 1)
INSERT [dbo].[Articulo] ([Id], [Descripcion], [PrecioCompra], [CategoriaId], [MarcaId], [ProveedorId]) VALUES (2, N'barilla', CAST(35.00 AS Decimal(9, 2)), 1, 2, 2)
INSERT [dbo].[Articulo] ([Id], [Descripcion], [PrecioCompra], [CategoriaId], [MarcaId], [ProveedorId]) VALUES (3, N'Cortina Blanca', CAST(150.00 AS Decimal(9, 2)), 2, 1, 1)
INSERT [dbo].[Articulo] ([Id], [Descripcion], [PrecioCompra], [CategoriaId], [MarcaId], [ProveedorId]) VALUES (4, N'Toldo', CAST(100.00 AS Decimal(9, 2)), 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Articulo] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Descripcion]) VALUES (1, N'Construcción')
INSERT [dbo].[Categoria] ([Id], [Descripcion]) VALUES (2, N'Diseño')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([Id], [Descripcion]) VALUES (1, N'Catco')
INSERT [dbo].[Marca] ([Id], [Descripcion]) VALUES (2, N'Cargo')
SET IDENTITY_INSERT [dbo].[Marca] OFF
INSERT [dbo].[Marca_Articulo] ([ArticuloId], [MarcaId]) VALUES (1, 1)
INSERT [dbo].[Marca_Articulo] ([ArticuloId], [MarcaId]) VALUES (2, 2)
INSERT [dbo].[Marca_Articulo] ([ArticuloId], [MarcaId]) VALUES (3, 1)
INSERT [dbo].[Marca_Articulo] ([ArticuloId], [MarcaId]) VALUES (4, 2)
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([Id], [ArticuloId], [AlmacenId], [Cantidad], [TipoMovimientoId], [Fecha]) VALUES (0, 1, 1, 90, 2, CAST(N'2019-09-10T04:18:08.037' AS DateTime))
INSERT [dbo].[Movimientos] ([Id], [ArticuloId], [AlmacenId], [Cantidad], [TipoMovimientoId], [Fecha]) VALUES (1, 1, 1, 100, 2, CAST(N'2019-09-10T04:27:14.273' AS DateTime))
INSERT [dbo].[Movimientos] ([Id], [ArticuloId], [AlmacenId], [Cantidad], [TipoMovimientoId], [Fecha]) VALUES (2, 1, 1, 250, 2, CAST(N'2019-09-10T04:29:00.073' AS DateTime))
INSERT [dbo].[Movimientos] ([Id], [ArticuloId], [AlmacenId], [Cantidad], [TipoMovimientoId], [Fecha]) VALUES (3, 2, 1, 100, 2, CAST(N'2019-09-10T04:31:52.927' AS DateTime))
INSERT [dbo].[Movimientos] ([Id], [ArticuloId], [AlmacenId], [Cantidad], [TipoMovimientoId], [Fecha]) VALUES (4, 1, 1, 50, 1, CAST(N'2019-09-10T04:32:20.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([Id], [Descripcion]) VALUES (1, N'Ramon')
INSERT [dbo].[Proveedor] ([Id], [Descripcion]) VALUES (2, N'Daniel')
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
INSERT [dbo].[Proveedor_Articulo] ([ArticuloId], [ProveedorId]) VALUES (1, 1)
INSERT [dbo].[Proveedor_Articulo] ([ArticuloId], [ProveedorId]) VALUES (2, 2)
INSERT [dbo].[Proveedor_Articulo] ([ArticuloId], [ProveedorId]) VALUES (3, 1)
INSERT [dbo].[Proveedor_Articulo] ([ArticuloId], [ProveedorId]) VALUES (4, 1)
SET IDENTITY_INSERT [dbo].[TipoMovimiento] ON 

INSERT [dbo].[TipoMovimiento] ([Id], [Descripcion]) VALUES (1, N'Entrada')
INSERT [dbo].[TipoMovimiento] ([Id], [Descripcion]) VALUES (2, N'Salida')
SET IDENTITY_INSERT [dbo].[TipoMovimiento] OFF
ALTER TABLE [dbo].[Almacen_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Articulo_Alamacen] FOREIGN KEY([AlmacenId])
REFERENCES [dbo].[Almacen] ([Id])
GO
ALTER TABLE [dbo].[Almacen_Articulo] CHECK CONSTRAINT [FK_Almacen_Articulo_Alamacen]
GO
ALTER TABLE [dbo].[Almacen_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Articulo_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Almacen_Articulo] CHECK CONSTRAINT [FK_Almacen_Articulo_Articulo]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Categoria]
GO
ALTER TABLE [dbo].[Marca_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Marca_Articulo_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Marca_Articulo] CHECK CONSTRAINT [FK_Marca_Articulo_Articulo]
GO
ALTER TABLE [dbo].[Marca_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Marca_Articulo_Marca] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([Id])
GO
ALTER TABLE [dbo].[Marca_Articulo] CHECK CONSTRAINT [FK_Marca_Articulo_Marca]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Almacen_Articulo] FOREIGN KEY([ArticuloId], [AlmacenId])
REFERENCES [dbo].[Almacen_Articulo] ([ArticuloId], [AlmacenId])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Almacen_Articulo]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_TipoMovimiento] FOREIGN KEY([TipoMovimientoId])
REFERENCES [dbo].[TipoMovimiento] ([Id])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_TipoMovimiento]
GO
ALTER TABLE [dbo].[Proveedor_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor_Articulo_Articulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[Proveedor_Articulo] CHECK CONSTRAINT [FK_Proveedor_Articulo_Articulo]
GO
ALTER TABLE [dbo].[Proveedor_Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor_Articulo_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Proveedor_Articulo] CHECK CONSTRAINT [FK_Proveedor_Articulo_Proveedor]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "aa"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 136
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "alm"
            Begin Extent = 
               Top = 6
               Left = 486
               Bottom = 136
               Right = 672
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Inventario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Inventario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "m"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 264
               Bottom = 136
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "alm"
            Begin Extent = 
               Top = 6
               Left = 472
               Bottom = 136
               Right = 642
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 6
               Left = 680
               Bottom = 102
               Right = 850
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Transacciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Transacciones'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Transacciones'
GO
USE [master]
GO
ALTER DATABASE [MARDOM] SET  READ_WRITE 
GO
