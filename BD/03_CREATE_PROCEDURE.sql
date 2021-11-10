USE [TestRecepcionGSC]
GO
/****** Object:  StoredProcedure [dbo].[PA_Ins_Permiso_Circulacion]    Script Date: 08/11/2021 23:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PA_Ins_Permiso_Circulacion]
	@placa					VARCHAR(50),
	@numeroMotor			VARCHAR(50),
	@codigoResultado		INT,
	@descripcionResultado	VARCHAR(MAX),
	@tamanioPermiso			INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @nuevo_id		INT				= NULL,
			@resultado		INT				= 1,			-- 1 = OK	2 = Existente	3 = Error
			@codigo_error	INT				= NULL,
			@mensaje_error	NVARCHAR(4000)	= NULL,
			@fecha			DATETIME		= GETDATE()

	BEGIN TRY
		INSERT INTO permiso_circulacion (placa, numeroMotor, codigoResultado, descripcionResultado, tamanioPermiso)
								 VALUES (@placa, @numeroMotor, @codigoResultado, @descripcionResultado, @tamanioPermiso)

		SET @nuevo_id=SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		SET @resultado		= 3
		SET @codigo_error	= ERROR_NUMBER()
		SET @mensaje_error	= ERROR_MESSAGE()
	END CATCH

	SELECT	@nuevo_id		AS id,
			@resultado		AS resultado,
			@codigo_error	AS codigo_error,
			@mensaje_error	AS mensaje_error

END
GO
/****** Object:  StoredProcedure [dbo].[PA_Sel_Permiso_Circulacion]    Script Date: 08/11/2021 23:33:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PA_Sel_Permiso_Circulacion]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT p.id_permiso_circulacion
		  ,p.placa
		  ,p.numeroMotor
		  ,p.codigoResultado
		  ,p.descripcionResultado
		  ,p.tamanioPermiso
	  FROM permiso_circulacion p

END
GO
