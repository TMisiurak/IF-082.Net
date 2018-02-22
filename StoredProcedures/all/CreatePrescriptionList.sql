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
