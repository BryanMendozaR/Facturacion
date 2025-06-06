USE [master]
GO
CREATE DATABASE [facturacion]
GO
USE [facturacion]
GO
CREATE TABLE [dbo].[cliente](
	[cli_id] [int] IDENTITY(1,1) NOT NULL,
	[cli_identificacion] [nvarchar](13) NULL,
	[cli_nombre] [nvarchar](200) NULL,
	[cli_telefono] [nvarchar](50) NULL,
	[cli_correo] [nvarchar](60) NULL,
	[cli_direccion] [nvarchar](400) NULL,
	[cli_estado] [bit] NOT NULL,
	[cli_fecha_creacion] [datetime] NOT NULL,
	[cli_eliminado] [bit] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[cli_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[configuracion]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[configuracion](
	[conf_id] [int] IDENTITY(1,1) NOT NULL,
	[conf_clave] [nvarchar](50) NULL,
	[conf_valor] [nvarchar](max) NULL,
 CONSTRAINT [PK_configuracion] PRIMARY KEY CLUSTERED 
(
	[conf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_factura]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_factura](
	[det_fact_id] [int] IDENTITY(1,1) NOT NULL,
	[det_fact_cantidad] [int] NOT NULL,
	[det_fact_precio] [decimal](18, 2) NOT NULL,
	[fact_id] [int] NOT NULL,
	[prod_id] [int] NOT NULL,
 CONSTRAINT [PK_detalle_factura] PRIMARY KEY CLUSTERED 
(
	[det_fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura](
	[fact_id] [int] IDENTITY(1,1) NOT NULL,
	[fact_valor_iva] [decimal](18, 2) NULL,
	[fact_porcentaje] [decimal](18, 2) NOT NULL,
	[fact_subtotal] [decimal](18, 2) NOT NULL,
	[fact_total] [decimal](18, 2) NOT NULL,
	[fact_estado] [nvarchar](50) NOT NULL,
	[fact_fecha] [datetime] NOT NULL,
	[cli_id] [int] NOT NULL,
	[usuario_id] [int] NOT NULL,
	[pag_id] [int] NOT NULL,
 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED 
(
	[fact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[log]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[log_numero] [int] NULL,
	[log_severidad] [int] NULL,
	[log_procedimiento] [nvarchar](max) NULL,
	[log_linea] [int] NULL,
	[log_mensaje] [nvarchar](max) NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago](
	[pag_id] [int] IDENTITY(1,1) NOT NULL,
	[pag_descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_pago] PRIMARY KEY CLUSTERED 
(
	[pag_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[prod_id] [int] IDENTITY(1,1) NOT NULL,
	[prod_codigo_producto] [nvarchar](15) NULL,
	[prod_nombre] [nvarchar](100) NULL,
	[prod_precio] [decimal](18, 2) NULL,
	[prod_estado] [bit] NOT NULL,
	[prod_fecha_creacion] [datetime] NOT NULL,
	[prod_eliminado] [bit] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[prod_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[usuario_id] [int] IDENTITY(1,1) NOT NULL,
	[usuario_nombre] [nvarchar](200) NULL,
	[usuario_usuario] [nvarchar](30) NOT NULL,
	[usuario_clave] [nvarchar](max) NOT NULL,
	[usuario_correo] [nvarchar](200) NULL,
	[usuario_fecha_creacion] [datetime] NOT NULL,
	[usuario_estado] [bit] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (1, N'2300732275', N'JUAN PEREZ', N'0999324557', N'JUANPEREZ@GMAIL.COM', N'Quito, calle naciones unidas', 1, CAST(N'2025-04-20T21:15:15.257' AS DateTime), 1)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (2, N'1723456789', N'MARIA LOPEZ', N'0987654321', N'maria.lopez@gmail.com', N'Guayaquil, Av. 9 de Octubre', 1, CAST(N'2025-04-20T21:16:17.803' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (3, N'1802233445', N'CARLOS MENDEZ', N'0978123456', N'carlos.mendez@yahoo.com', N'Cuenca, Calle Larga 123', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (4, N'0911122334', N'LUISA MARTINEZ', N'0999888777', N'luisa.martinez@hotmail.com', N'Ambato, Av. Cevallos', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (5, N'1104433221', N'FERNANDO CASTRO', N'0987001122', N'fcastro@outlook.com', N'Loja, Av. Universitaria', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (6, N'1009876543', N'ANA RAMIREZ', N'0965432109', N'ana.ramirez@gmail.com', N'Riobamba, Calle Primera', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (7, N'1755511223', N'JORGE VERA', N'0991122334', N'jorge.vera@live.com', N'Machala, Av. Ferroviaria', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (8, N'0922334455', N'ISABEL MORENO', N'0987650987', N'isabel.moreno@gmail.com', N'Portoviejo, Calle 10', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (9, N'1409988776', N'PABLO JARA', N'0956781234', N'pablo.jara@gmail.com', N'Manta, Av. Malecón', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (10, N'1603344556', N'CECILIA RIVERA', N'0967892345', N'cecilia.rivera@hotmail.com', N'Ibarra, Calle Sucre', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (11, N'1234567890', N'GABRIEL TORRES', N'0976543210', N'gabriel.torres@gmail.com', N'Tulcán, Av. Bolívar', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (12, N'1855566778', N'MONICA SALAZAR', N'0995566778', N'monica.salazar@yahoo.com', N'Latacunga, Calle Quito', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (13, N'1022334455', N'DIEGO NAVARRO', N'0954321890', N'dnavarro@outlook.com', N'Quevedo, Calle Olmedo', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (14, N'1123456789', N'PATRICIA REYES', N'0987012345', N'patricia.reyes@gmail.com', N'Esmeraldas, Av. Libertad', 1, CAST(N'2025-04-20T21:16:17.807' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (15, N'1344556677', N'RICARDO GOMEZ', N'0978901234', N'ricardo.gomez@hotmail.com', N'Santo Domingo, Calle Colombia', 1, CAST(N'2025-04-20T21:16:17.810' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (16, N'1556677889', N'VALERIA PONCE', N'0967801234', N'valeria.ponce@gmail.com', N'Tena, Calle Amazonas', 1, CAST(N'2025-04-20T21:16:17.810' AS DateTime), 0)
INSERT [dbo].[cliente] ([cli_id], [cli_identificacion], [cli_nombre], [cli_telefono], [cli_correo], [cli_direccion], [cli_estado], [cli_fecha_creacion], [cli_eliminado]) VALUES (17, N'2300159825', N'DANIEL BONILLA', N'0999324552', N'juancarlos123@gmail.com', N'Manabí. Av, la costa', 1, CAST(N'2025-04-20T22:25:41.637' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (1, N'12345', N'DESTORNILLADOR', CAST(25.00 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:08:55.950' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (2, N'12346', N'MARTILLO', CAST(22.65 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.730' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (3, N'12347', N'LLAVE INGLESA', CAST(19.99 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.730' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (4, N'12348', N'ALICATE', CAST(15.75 AS Decimal(18, 2)), 0, CAST(N'2025-04-18T14:10:21.730' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (5, N'12349', N'SIERRA MANUAL', CAST(30.10 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.730' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (6, N'12350', N'CINTA MÉTRICA', CAST(8.90 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (7, N'12351', N'TALADRO', CAST(75.00 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (8, N'12352', N'SIERRA ELÉCTRICA', CAST(120.45 AS Decimal(18, 2)), 0, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (9, N'12353', N'PINZAS', CAST(9.99 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (10, N'12354', N'LIMA METÁLICA', CAST(6.80 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (11, N'12355', N'ESPÁTULA', CAST(4.50 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (12, N'12356', N'DESTORNILLADOR DE ESTRELLA', CAST(17.30 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (13, N'12357', N'DESTORNILLADOR PLANO', CAST(16.90 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (14, N'12358', N'JUEGO DE DESTORNILLADORES', CAST(34.00 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (15, N'12359', N'CAJA DE HERRAMIENTAS', CAST(55.60 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (16, N'12360', N'NIVEL DE BURBUJA', CAST(12.70 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (17, N'12361', N'ESCALERA PLEGABLE', CAST(89.99 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (18, N'12362', N'GUANTES DE TRABAJO', CAST(6.99 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (19, N'12363', N'GAFAS DE SEGURIDAD', CAST(5.49 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.733' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (20, N'12364', N'CASCO DE SEGURIDAD', CAST(22.00 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (21, N'12365', N'MASCARILLA PROTECTORA', CAST(3.99 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (22, N'12366', N'BROCHA', CAST(2.50 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (23, N'12367', N'RODILLO PARA PINTAR', CAST(4.20 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (24, N'12368', N'CÚTER', CAST(3.10 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (25, N'12369', N'SOPORTE PARA TV', CAST(39.90 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (26, N'12370', N'TORNILLOS SURTIDOS', CAST(7.25 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (27, N'12371', N'TUERCAS Y ARANDELAS', CAST(5.75 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (28, N'12372', N'SILICONA', CAST(3.60 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (29, N'12373', N'PISTOLA DE SILICONA', CAST(14.85 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (30, N'12374', N'ESCARPIA', CAST(1.20 AS Decimal(18, 2)), 1, CAST(N'2025-04-18T14:10:21.737' AS DateTime), 1)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (31, N'11111', N'PLAYO PEQUEÑO', CAST(2.75 AS Decimal(18, 2)), 1, CAST(N'2025-04-20T21:06:15.667' AS DateTime), 0)
INSERT [dbo].[producto] ([prod_id], [prod_codigo_producto], [prod_nombre], [prod_precio], [prod_estado], [prod_fecha_creacion], [prod_eliminado]) VALUES (32, N'11777', N'AGARRADERA DE MADERA', CAST(3.75 AS Decimal(18, 2)), 1, CAST(N'2025-04-21T09:21:21.563' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([usuario_id], [usuario_nombre], [usuario_usuario], [usuario_clave], [usuario_correo], [usuario_fecha_creacion], [usuario_estado]) VALUES (1, N'Bryan Mendoza', N'bmendoza', N'12345', N'bmendozari@gmail.com', CAST(N'2025-04-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuario] ([usuario_id], [usuario_nombre], [usuario_usuario], [usuario_clave], [usuario_correo], [usuario_fecha_creacion], [usuario_estado]) VALUES (2, N'Juan Manobanda', N'Juan', N'1234', N'juanmanobanda123@gmail.com', CAST(N'2025-04-17T11:52:34.470' AS DateTime), 1)
INSERT [dbo].[usuario] ([usuario_id], [usuario_nombre], [usuario_usuario], [usuario_clave], [usuario_correo], [usuario_fecha_creacion], [usuario_estado]) VALUES (3, N'Pedritooo', N'pepeee', N'123456', N'pepe@gmail.com', CAST(N'2025-04-17T12:46:04.303' AS DateTime), 1)
INSERT [dbo].[usuario] ([usuario_id], [usuario_nombre], [usuario_usuario], [usuario_clave], [usuario_correo], [usuario_fecha_creacion], [usuario_estado]) VALUES (4, N'Mario Calderon', N'mariocale', N'12345', N'segurityeducation@gmail.com', CAST(N'2025-04-21T12:31:32.420' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Detalle_Factura] FOREIGN KEY([fact_id])
REFERENCES [dbo].[factura] ([fact_id])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_Factura_Detalle_Factura]
GO
ALTER TABLE [dbo].[detalle_factura]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Detalle_Factura] FOREIGN KEY([prod_id])
REFERENCES [dbo].[producto] ([prod_id])
GO
ALTER TABLE [dbo].[detalle_factura] CHECK CONSTRAINT [FK_Producto_Detalle_Factura]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Factura] FOREIGN KEY([cli_id])
REFERENCES [dbo].[cliente] ([cli_id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_Cliente_Factura]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Factura] FOREIGN KEY([pag_id])
REFERENCES [dbo].[pago] ([pag_id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_Pago_Factura]
GO
ALTER TABLE [dbo].[factura]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Factura] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([usuario_id])
GO
ALTER TABLE [dbo].[factura] CHECK CONSTRAINT [FK_Usuario_Factura]
GO
/****** Object:  StoredProcedure [dbo].[spd_cliente]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spd_cliente]
(
	@i_identificacion NVARCHAR(13)
)
AS
BEGIN TRAN
BEGIN TRY
	UPDATE cliente SET cli_eliminado=1 WHERE cli_identificacion=@i_identificacion and  cli_eliminado=0
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spd_producto]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spd_producto]
(
	@i_id INT
)
AS
BEGIN TRAN
BEGIN TRY
	UPDATE producto SET prod_eliminado = 1 WHERE prod_id=@i_id
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spd_usuario]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spd_usuario]
(
	@i_codigo_usuario INT
)
AS
BEGIN TRAN
BEGIN TRY
	UPDATE usuario SET usuario_estado=0 WHERE usuario_id=@i_codigo_usuario
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spi_cliente]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spi_cliente]
(
	@i_identificacion NVARCHAR(13),
	@i_nombre NVARCHAR(200),
	@i_telefono NVARCHAR(50),
	@i_correo NVARCHAR(60),
	@i_direccion NVARCHAR(400)
)
AS
BEGIN TRAN
BEGIN TRY
 IF NOT EXISTS (SELECT * FROM cliente WHERE cli_eliminado = 0 and cli_identificacion = @i_identificacion)
 BEGIN
	INSERT INTO cliente (cli_identificacion, cli_nombre, cli_telefono, cli_correo, cli_direccion, cli_fecha_creacion, cli_estado, cli_eliminado)
	VALUES (@i_identificacion, @i_nombre, @i_telefono, @i_correo,@i_direccion, GETDATE(), 1,0)
 END
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spi_producto]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spi_producto]
(
	@i_codigo NVARCHAR(15),
	@i_nombre NVARCHAR(100),
	@i_precio DECIMAL(18,2)
)
AS
BEGIN TRAN
BEGIN TRY
 IF NOT EXISTS (SELECT * FROM producto WHERE prod_eliminado = 0 and prod_codigo_producto = @i_codigo)
 BEGIN
	INSERT INTO producto( prod_codigo_producto, prod_nombre, prod_precio, prod_fecha_creacion, prod_estado, prod_eliminado)
	VALUES (@i_codigo, @i_nombre, @i_precio, GETDATE(), 1, 0)
 END
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spi_usuario]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spi_usuario]
(
	@i_nombre NVARCHAR(200),
	@i_usuario NVARCHAR(30),
	@i_clave NVARCHAR(max),
	@i_correo NVARCHAR(max)
)
AS
BEGIN TRAN
BEGIN TRY
 IF NOT EXISTS (SELECT * FROM usuario WHERE usuario_estado = 1 and usuario_usuario = @i_usuario)
 BEGIN
	INSERT INTO usuario (usuario_nombre, usuario_usuario, usuario_clave, usuario_correo, usuario_fecha_creacion, usuario_estado)
	VALUES (@i_nombre, @i_usuario, @i_clave, @i_correo, GETDATE(), 1)
 END
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[sps_cliente]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_cliente]
(
	@i_nombre NVARCHAR(200) = '',
	@i_numero_registros INT,
	@i_tamanio_pagina INT,
	@o_total_registros INT OUTPUT
)
AS
BEGIN
	SELECT @o_total_registros = COUNT(*) FROM cliente WHERE cli_nombre  LIKE '%' + @i_nombre + '%' and cli_eliminado=0

	SELECT cli_id as codigo, cli_identificacion as identificacion, cli_nombre as nombre, cli_telefono as telefono, cli_correo as correo, cli_direccion as direccion, cli_estado as estado
	FROM cliente  WHERE cli_nombre  LIKE '%' + @i_nombre + '%' and cli_eliminado=0
	ORDER BY CAST(cli_fecha_creacion AS DATE) DESC
	OFFSET (@i_numero_registros - 1) * @i_tamanio_pagina ROWS
	FETCH NEXT @i_tamanio_pagina ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[sps_iniciar_sesion]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_iniciar_sesion]
(
	@i_usuario NVARCHAR(30),
	@i_clave NVARCHAR(MAX),
	@o_respuesta_inicio_sesion BIT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
    SET @o_respuesta_inicio_sesion = 0;
	IF EXISTS(SELECT * FROM usuario WHERE usuario_usuario=@i_usuario AND usuario_clave=@i_clave AND usuario_estado=1 )
	BEGIN
		SELECT usuario_id as codigo, usuario_nombre as nombre, usuario_usuario as usuario, usuario_correo as correo FROM usuario WHERE usuario_usuario=@i_usuario AND usuario_clave=@i_clave AND usuario_estado=1
		SET @o_respuesta_inicio_sesion = 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sps_producto]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_producto]
(
	@i_nombre NVARCHAR(200) = '',
	@i_numero_registros INT,
	@i_tamanio_pagina INT,
	@o_total_registros INT OUTPUT
)
AS
BEGIN
	SELECT @o_total_registros = COUNT(*) FROM producto  WHERE prod_eliminado = 0 AND (prod_nombre  LIKE '%' + @i_nombre + '%' OR prod_codigo_producto LIKE '%' + @i_nombre + '%' )

	SELECT prod_id AS Identificador, prod_codigo_producto AS Codigo, prod_nombre AS Nombre, prod_precio AS Precio, prod_estado AS Estado, prod_fecha_creacion AS Fecha 
	FROM producto WHERE prod_eliminado = 0 AND (prod_nombre  LIKE '%' + @i_nombre + '%' OR prod_codigo_producto LIKE '%' + @i_nombre + '%' )
	ORDER BY CAST(prod_fecha_creacion AS DATE) DESC
	OFFSET (@i_numero_registros - 1) * @i_tamanio_pagina ROWS
	FETCH NEXT @i_tamanio_pagina ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[sps_usuario]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_usuario]
(
	@i_nombre NVARCHAR(200) = '',
	@i_numero_registros INT,
	@i_tamanio_pagina INT,
	@o_total_registros INT OUTPUT
)
AS
BEGIN
	SELECT @o_total_registros = COUNT(*) FROM usuario WHERE usuario_nombre LIKE '%' + @i_nombre + '%'  AND usuario_estado=1

	SELECT usuario_id AS codigo, usuario_nombre AS nombre, usuario_usuario AS usuario, usuario_correo AS correo, usuario_fecha_creacion AS fecha
	FROM usuario WHERE usuario_nombre LIKE '%' + @i_nombre + '%' AND usuario_estado=1
	ORDER BY CAST(usuario_fecha_creacion AS DATE) DESC
	OFFSET (@i_numero_registros - 1) * @i_tamanio_pagina ROWS
	FETCH NEXT @i_tamanio_pagina ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [dbo].[spu_cliente]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spu_cliente]
(
	@i_identificacion NVARCHAR(13),
	@i_nombre NVARCHAR(200),
	@i_telefono NVARCHAR(50),
	@i_correo NVARCHAR(60),
	@i_direccion NVARCHAR(400)
)
AS
BEGIN TRAN
BEGIN TRY
	UPDATE cliente SET cli_nombre= @i_nombre, cli_telefono= @i_telefono, cli_correo=@i_correo, cli_direccion=@i_direccion WHERE cli_identificacion=@i_identificacion and cli_eliminado=0
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spu_producto]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spu_producto]
(
	@i_id INT,
	@i_codigo NVARCHAR(15),
	@i_nombre NVARCHAR(100),
	@i_precio DECIMAL(18,2),
	@i_estado BIT
)
AS
DECLARE @v_codigo NVARCHAR(15)
BEGIN TRAN
BEGIN TRY
	SELECT @v_codigo=prod_codigo_producto FROM producto WHERE prod_id=@i_id
	IF((@i_codigo = @v_codigo) OR (@i_codigo <> @v_codigo AND NOT EXISTS(SELECT * FROM producto WHERE prod_codigo_producto = @i_codigo)) )
	BEGIN
		UPDATE producto SET prod_codigo_producto=@i_codigo, prod_nombre=@i_nombre, prod_precio=@i_precio, prod_estado=@i_estado WHERE prod_id=@i_id
	END
	
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[spu_usuario]    Script Date: 21/4/2025 15:44:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spu_usuario]
(
	@i_codigo_usuario INT,
	@i_nombre NVARCHAR(200) = '',
	@i_usuario NVARCHAR(30) = '',
	@i_correo NVARCHAR(max) = '',
	@i_clave NVARCHAR(max) = '',
	@i_accion BIT
)
AS
BEGIN TRAN
BEGIN TRY
	IF (@i_accion = 1)
	BEGIN
		UPDATE usuario SET usuario_nombre= @i_nombre, usuario_usuario= @i_usuario, usuario_correo=@i_correo WHERE usuario_id=@i_codigo_usuario
	END
	ELSE
	BEGIN
		UPDATE usuario SET usuario_clave=@i_clave WHERE usuario_id=@i_codigo_usuario
	END
COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorNumber INT = ERROR_NUMBER();
    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
    DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
    DECLARE @ErrorLine INT = ERROR_LINE();
    DECLARE @ErrorProcedure NVARCHAR(200) = ERROR_PROCEDURE();
	INSERT INTO dbo.[log](log_numero,log_severidad,log_procedimiento,log_linea,log_mensaje)
	VALUES(@ErrorNumber,@ErrorSeverity,@ErrorProcedure,@ErrorLine,@ErrorMessage)
	ROLLBACK TRAN
END CATCH
GO
USE [master]
GO
ALTER DATABASE [facturacion] SET  READ_WRITE 
GO
