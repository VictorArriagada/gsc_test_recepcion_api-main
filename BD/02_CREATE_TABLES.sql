USE [TestRecepcionGSC]
GO
/****** Object:  Table [dbo].[permiso_circulacion]    Script Date: 08/11/2021 23:32:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_circulacion](
	[id_permiso_circulacion] [int] IDENTITY(1,1) NOT NULL,
	[placa] [varchar](50) NULL,
	[numeroMotor] [varchar](50) NULL,
	[codigoResultado] [int] NULL,
	[descripcionResultado] [varchar](max) NULL,
	[tamanioPermiso] [int] NULL,
 CONSTRAINT [PK_permiso_circulacion] PRIMARY KEY CLUSTERED 
(
	[id_permiso_circulacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
