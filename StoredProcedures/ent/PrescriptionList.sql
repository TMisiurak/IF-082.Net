-- GetAllPrescriptionLists
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetAllPrescriptionLists]
GO

CREATE PROCEDURE [dbo].[sp_GetAllPrescriptionLists] AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM PrescriptionLists

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------

-- GetPrescriptionListById
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_GetPrescriptionListById]
GO

CREATE PROCEDURE [dbo].[sp_GetPrescriptionListById]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;

	SELECT * FROM [dbo].PrescriptionLists WHERE Id = @Id

	RETURN 0
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------

-- CreatePrescriptionList
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_CreatePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_CreatePrescriptionList]
	@ProcedureId int,
	@DrugId int,
	@PrescriptionId int
AS
BEGIN TRY
	SET NOCOUNT ON;

	INSERT INTO [dbo].PrescriptionLists (ProcedureId, DrugId, PrescriptionId)
    VALUES (@ProcedureId, @DrugId, @PrescriptionId)

	RETURN @@IDENTITY
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------

-- UpdatePrescriptionList
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_UpdatePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_UpdatePrescriptionList]
	@Id int,
	@ProcedureId int,
	@DrugId int,
	@PrescriptionId int
AS

IF NOT EXISTS (SELECT 1 FROM PrescriptionLists WHERE Id=@Id)
BEGIN
	RETURN -1
END

BEGIN TRY
	SET NOCOUNT ON;

    UPDATE [dbo].PrescriptionLists
		SET	[ProcedureId] = @ProcedureId, DrugId = @DrugId, [PrescriptionId] = @PrescriptionId
		WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
----------------------------------------------------------

-- DeletePrescriptionList
USE [ClinicDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP PROCEDURE IF EXISTS [dbo].[sp_DeletePrescriptionList]
GO

CREATE PROCEDURE [dbo].[sp_DeletePrescriptionList]
	@Id int
AS
BEGIN TRY
	SET NOCOUNT ON;
	
	DELETE FROM PrescriptionLists WHERE Id = @Id

	RETURN @@ROWCOUNT
END TRY
BEGIN CATCH
	RETURN -1
END CATCH
GO
