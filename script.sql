USE [master]
GO
/****** Object:  Database [ServicesDb]    Script Date: 23/05/2020 12:26:43 p. m. ******/
CREATE DATABASE [ServicesDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ServicesDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ServicesDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ServicesDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ServicesDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ServicesDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ServicesDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ServicesDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ServicesDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ServicesDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ServicesDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ServicesDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ServicesDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ServicesDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ServicesDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ServicesDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ServicesDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ServicesDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ServicesDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ServicesDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ServicesDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ServicesDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ServicesDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ServicesDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ServicesDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ServicesDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ServicesDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ServicesDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ServicesDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ServicesDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ServicesDb] SET  MULTI_USER 
GO
ALTER DATABASE [ServicesDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ServicesDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ServicesDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ServicesDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ServicesDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ServicesDb] SET QUERY_STORE = OFF
GO
USE [ServicesDb]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 23/05/2020 12:26:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[Id_Cita] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Id_Punto] [int] NULL,
	[Id_Empleado] [int] NULL,
	[Id_Cliente] [int] NULL,
	[Id_EstadoCita] [int] NULL,
	[Id_Disponibilidad] [int] NULL,
	[Fecha] [datetime] NULL,
	[Hora_Inicial] [time](7) NULL,
	[Hora_fina] [time](7) NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres_Cliente] [varchar](100) NULL,
	[Apellidos_Cliente] [varchar](100) NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disponibilidad]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disponibilidad](
	[Id_Disponibilidad] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Id_Punto] [int] NULL,
	[Id_Empleado] [int] NULL,
	[Id_Estado] [int] NULL,
	[Fecha_Disponibilidad] [datetime] NULL,
	[Hora_Inicial] [time](7) NULL,
	[Hora_Fin] [time](7) NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Disponibilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id_empleado] [int] IDENTITY(1,1) NOT NULL,
	[Id_TipoDocumento] [int] NULL,
	[NoDocumento] [numeric](20, 0) NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [numeric](20, 0) NULL,
	[Correo] [varchar](100) NULL,
	[Id_Estado] [int] NULL,
	[Fotos] [varchar](200) NULL,
	[RedesSociales] [varchar](200) NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadosEmpresas]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadosEmpresas](
	[Id_EmpleadosEmpresas] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Id_Empleado] [int] NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_EmpleadosEmpresas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadosPuntos]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadosPuntos](
	[Id_Punto] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empleado] [int] NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Punto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Empresa] [varchar](100) NULL,
	[Nit] [int] NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [int] NULL,
	[Id_Estado] [int] NULL,
	[Id_redesSociales] [varchar](100) NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCitas]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCitas](
	[Id_EstadoCita] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstadoCita] [varchar](100) NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_EstadoCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id_Estado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_estado] [varchar](50) NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puntos]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puntos](
	[Id_Punto] [int] IDENTITY(1,1) NOT NULL,
	[Id_Empresa] [int] NULL,
	[Nombre_Punto] [varchar](100) NULL,
	[Direccion_Punto] [varchar](100) NULL,
	[Telefono] [int] NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Punto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[Id_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Servicio] [varchar](100) NULL,
	[Id_TipoServicio] [int] NULL,
	[Id_estado] [int] NULL,
	[Fecha_Ingreso] [datetime] NULL,
	[Usuario_Ingreso] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modifica] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiciosEmpresa]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiciosEmpresa](
	[Id_ServicioEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[Id_Servicio] [int] NULL,
	[Id_Estado] [int] NULL,
	[Fecha_Ingreso] [datetime] NULL,
	[Usuario_Ingreso] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modifica] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_ServicioEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiciosEmpresasPuntos]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiciosEmpresasPuntos](
	[Id_ServicioEmpresaPunto] [int] IDENTITY(1,1) NOT NULL,
	[Id_ServicioEmpresa] [int] NULL,
	[Detalles] [varchar](100) NULL,
	[Precio] [numeric](18, 2) NULL,
	[Id_Estado] [int] NULL,
	[Fecha_Ingreso] [datetime] NULL,
	[Usuario_Ingreso] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modifica] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_ServicioEmpresaPunto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCalificacion]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCalificacion](
	[Id_TipoCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Calificacion] [varchar](100) NULL,
	[Id_estado] [int] NULL,
	[Fecha_Ingreso] [datetime] NULL,
	[Usuario_Ingreso] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modifica] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TipoCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[Id_TipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_TipoDocumento] [varchar](50) NULL,
	[Id_Estado] [int] NULL,
	[Login_Creacion] [varchar](20) NULL,
	[Fecha_creacion] [datetime] NULL,
	[Login_Modificacion] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposServicios]    Script Date: 23/05/2020 12:26:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposServicios](
	[Id_TipoServicio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_TipoServicio] [varchar](100) NULL,
	[Id_estado] [int] NULL,
	[Fecha_Ingreso] [datetime] NULL,
	[Usuario_Ingreso] [varchar](20) NULL,
	[Fecha_Modificacion] [datetime] NULL,
	[Usuario_Modifica] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TipoServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Citas] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Clientes] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Clientes_Citas]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Disponibilidad_Citas] FOREIGN KEY([Id_Disponibilidad])
REFERENCES [dbo].[Disponibilidad] ([Id_Disponibilidad])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Disponibilidad_Citas]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Citas] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Empleados_Citas]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Citas] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Empresas_Citas]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_EstadoCitas_Citas] FOREIGN KEY([Id_EstadoCita])
REFERENCES [dbo].[EstadoCitas] ([Id_EstadoCita])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_EstadoCitas_Citas]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Puntos_Citas] FOREIGN KEY([Id_Punto])
REFERENCES [dbo].[Puntos] ([Id_Punto])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Puntos_Citas]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Estados_Clientes] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Estados_Clientes]
GO
ALTER TABLE [dbo].[Disponibilidad]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Disponibilidad] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[Disponibilidad] CHECK CONSTRAINT [FK_Empleados_Disponibilidad]
GO
ALTER TABLE [dbo].[Disponibilidad]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Disponibilidad] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Disponibilidad] CHECK CONSTRAINT [FK_Empresas_Disponibilidad]
GO
ALTER TABLE [dbo].[Disponibilidad]  WITH CHECK ADD  CONSTRAINT [FK_Estados_Disponibilidad] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Disponibilidad] CHECK CONSTRAINT [FK_Estados_Disponibilidad]
GO
ALTER TABLE [dbo].[Disponibilidad]  WITH CHECK ADD  CONSTRAINT [FK_Puntos_Disponibilidad] FOREIGN KEY([Id_Punto])
REFERENCES [dbo].[Puntos] ([Id_Punto])
GO
ALTER TABLE [dbo].[Disponibilidad] CHECK CONSTRAINT [FK_Puntos_Disponibilidad]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Estados_Empleados] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Estados_Empleados]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_TiposDocumentos_Empleados] FOREIGN KEY([Id_TipoDocumento])
REFERENCES [dbo].[TiposDocumentos] ([Id_TipoDocumento])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_TiposDocumentos_Empleados]
GO
ALTER TABLE [dbo].[EmpleadosEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_EmpleadosEmpresas] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[EmpleadosEmpresas] CHECK CONSTRAINT [FK_Empleados_EmpleadosEmpresas]
GO
ALTER TABLE [dbo].[EmpleadosEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_EmpleadosEmpresas] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[EmpleadosEmpresas] CHECK CONSTRAINT [FK_Empresa_EmpleadosEmpresas]
GO
ALTER TABLE [dbo].[EmpleadosEmpresas]  WITH CHECK ADD  CONSTRAINT [FK_Estados_EmpleadosEmpresas] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[EmpleadosEmpresas] CHECK CONSTRAINT [FK_Estados_EmpleadosEmpresas]
GO
ALTER TABLE [dbo].[EmpleadosPuntos]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_EmpleadosPuntos] FOREIGN KEY([Id_Empleado])
REFERENCES [dbo].[Empleados] ([Id_empleado])
GO
ALTER TABLE [dbo].[EmpleadosPuntos] CHECK CONSTRAINT [FK_Empleados_EmpleadosPuntos]
GO
ALTER TABLE [dbo].[EmpleadosPuntos]  WITH CHECK ADD  CONSTRAINT [FK_Estados_EmpleadosPuntos] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[EmpleadosPuntos] CHECK CONSTRAINT [FK_Estados_EmpleadosPuntos]
GO
ALTER TABLE [dbo].[EmpleadosPuntos]  WITH CHECK ADD  CONSTRAINT [FK_Puntos_EmpleadosPuntos] FOREIGN KEY([Id_Punto])
REFERENCES [dbo].[Puntos] ([Id_Punto])
GO
ALTER TABLE [dbo].[EmpleadosPuntos] CHECK CONSTRAINT [FK_Puntos_EmpleadosPuntos]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Estados_Empresa] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Estados_Empresa]
GO
ALTER TABLE [dbo].[EstadoCitas]  WITH CHECK ADD  CONSTRAINT [FK_Estados_EstadoCitas] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[EstadoCitas] CHECK CONSTRAINT [FK_Estados_EstadoCitas]
GO
ALTER TABLE [dbo].[Puntos]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Puntos] FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([Id_Empresa])
GO
ALTER TABLE [dbo].[Puntos] CHECK CONSTRAINT [FK_Empresa_Puntos]
GO
ALTER TABLE [dbo].[Puntos]  WITH CHECK ADD  CONSTRAINT [FK_Estados_Puntos] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Puntos] CHECK CONSTRAINT [FK_Estados_Puntos]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [fk_Estados_Servicios] FOREIGN KEY([Id_estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [fk_Estados_Servicios]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [fk_Estados_TipoServicio] FOREIGN KEY([Id_TipoServicio])
REFERENCES [dbo].[TiposServicios] ([Id_TipoServicio])
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [fk_Estados_TipoServicio]
GO
ALTER TABLE [dbo].[ServiciosEmpresa]  WITH CHECK ADD  CONSTRAINT [fk_Estados_ServiciosEmpresa] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[ServiciosEmpresa] CHECK CONSTRAINT [fk_Estados_ServiciosEmpresa]
GO
ALTER TABLE [dbo].[ServiciosEmpresa]  WITH CHECK ADD  CONSTRAINT [fk_Servicios_ServiciosEmpresa] FOREIGN KEY([Id_Servicio])
REFERENCES [dbo].[Servicios] ([Id_Servicio])
GO
ALTER TABLE [dbo].[ServiciosEmpresa] CHECK CONSTRAINT [fk_Servicios_ServiciosEmpresa]
GO
ALTER TABLE [dbo].[ServiciosEmpresasPuntos]  WITH CHECK ADD  CONSTRAINT [fk_Estados_ServiciosEmpresasPuntos] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[ServiciosEmpresasPuntos] CHECK CONSTRAINT [fk_Estados_ServiciosEmpresasPuntos]
GO
ALTER TABLE [dbo].[ServiciosEmpresasPuntos]  WITH CHECK ADD  CONSTRAINT [fk_ServiciosEmpresa_ServiciosEmpresasPuntos] FOREIGN KEY([Id_ServicioEmpresa])
REFERENCES [dbo].[ServiciosEmpresa] ([Id_ServicioEmpresa])
GO
ALTER TABLE [dbo].[ServiciosEmpresasPuntos] CHECK CONSTRAINT [fk_ServiciosEmpresa_ServiciosEmpresasPuntos]
GO
ALTER TABLE [dbo].[TipoCalificacion]  WITH CHECK ADD  CONSTRAINT [fk_Estados_TipoCalificacion] FOREIGN KEY([Id_estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[TipoCalificacion] CHECK CONSTRAINT [fk_Estados_TipoCalificacion]
GO
ALTER TABLE [dbo].[TiposDocumentos]  WITH CHECK ADD  CONSTRAINT [FK_Estados_TiposDocumentos] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[TiposDocumentos] CHECK CONSTRAINT [FK_Estados_TiposDocumentos]
GO
ALTER TABLE [dbo].[TiposServicios]  WITH CHECK ADD  CONSTRAINT [fk_Estados_TiposServicios] FOREIGN KEY([Id_estado])
REFERENCES [dbo].[Estados] ([Id_Estado])
GO
ALTER TABLE [dbo].[TiposServicios] CHECK CONSTRAINT [fk_Estados_TiposServicios]
GO
USE [master]
GO
ALTER DATABASE [ServicesDb] SET  READ_WRITE 
GO
